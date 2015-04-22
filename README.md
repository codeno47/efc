## EFC
#Enterprise Foundation Classes

Enterprise Foundation classes are set of Pattern implementations which suits bests for any enterprise grade application development in Microsoft platform.

**Introduction**

An expert developer always play around best in coding practice, best tools, best methodologies etc. But when he/she comes to an enterprise application where coding gives less importance than any other. They might not be successful without a flexible architecture. We have seen over years about many layers of architecture and sometimes quiet confused which one to choose.

**N-Tire Architecture**

Since 2009 there was significant changes introduced in database technologies, such as ORM, Document database etc. Let us take a look at how we can solve above problems with the help these technologies.

**Client**

Same as 3-tier architecture, but the rules used access other layers has been redefined. Client should not refer Business service layer directly, instead it should use Service contract layer (Interfaces) to access services, and this makes sense when client requirement changes often and service did not. Use IoC containers to access service objects. Popular IoCs are Unity, Spring etc.

As we see in 3-tier architecture, database objects navigates till client, this might not be a good idea when you are developing a web based application. Your object need to travel over network, and also schema changes will result change in entire layers , and more over these classes need to implement special attributes such as DataContract for using with technology like WCF. So client can access these object via DTO (data transfer object) from a data contract layer. Where all dto’s and its extensions are defined.

**Business Service**

Here you will have all business rules/logics. It doesn’t offer CURD operation that is the job of application services. In simple terms a business can use on or more application service to build business logic/use case. Business service cannot call another business service, this is to avoid cyclic reference. If you have such requirement where business logic need to be shared between more than one service, either split business service into more generic way or move it to application service.

*code sample for Business service*
```
    public class AuthenticationService : BusinessService
    {
        /// <summary>
        /// Gets or sets the asynchronous authentication service.
        /// </summary>
        /// <value>
        /// The asynchronous authentication service.
        /// </value>
        [Dependency]
        public ASAuthenticationService ASAuthenticationService { get; set; }

        /// <summary>
        /// Gets or sets as user service.
        /// </summary>
        /// <value>
        /// As user service.
        /// </value>
        [Dependency]
        public ASUserService AsUserService { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        public AuthenticationService(IUnityContainer unity)
            : base(unity)
        {
        }
        
         /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MobileUser> GetAllUsers()
        {
            return AsUserService.GetAllUsers();
        }
    }
```
**Application Service**

An application service is one which is close to database technologies such as ORM. ( eg entity framework,NH etc). It talks to DataContext to perform CURD operations requested by Business services.

Any application service will have at least one Repository instance in it, there is no limit the number it can have. But make sure you don’t duplicate functionalities. As mentioned earlier, Application services can be shared amount different business services, an application service can call another application service.  This is to make sure maximum code reusability hence best in maintainability. It deals with POCO or entities to ensure separation from database technologies.

*Code sample for an Application Service created with Entity Framework 6.1*
```
public class AsUserMobile : ApplicationService<SampleEFContainer>, IAsUserMobile
    {
        /// <summary>
        /// Gets the users mobile repository.
        /// </summary>
        private IRepository<UsersMobile, int> UsersMobileRepository
        {
            get { return DataContext.GetRepository<UsersMobile, int>(); }
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="AsUserMobile"/> class.
        /// </summary>
        /// <param name="unity">
        /// The unity.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        public AsUserMobile(IUnityContainer unity, IRepositoryContext context)
            : base(unity, context)
        {
        }
        
         /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="userId">
        /// The user Id.
        /// </param>
        /// <returns>
        /// The <see cref="UsersMobile"/>.
        /// </returns>
        public UsersMobile GetById(int userId)
        {
            return this.UsersMobileRepository.GetById(userId);
        }
        
        /// <summary>
        /// The get by user name.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// The <see cref="UserMobile" />.
        /// </returns>
        private UsersMobile GetByUserName(string username, string password)
        {
            var specification = new Specification<UsersMobile>(x => x.UserName == username && x.Password == password);
            return this.UsersMobileRepository.GetBySpecification(specification).FirstOrDefault();
        }
        
         /// <summary>
        /// Adds mobile user.
        /// </summary>
        public void Add(UsersMobile user)
        {
            UsersMobileRepository.Add(user);
            Save();
        }
    }
```

**ORM (Object Relational Mapping)**

This is a WOW part in entire architecture, a layer which completely ignores how database stuff works. It fires native queries for you in backend ( eg in case of SQL Server it fires T-SQL commands). All you need to manage object in DataContext which is a virtual database.  When there an infrastructure requirement change, you can easily switch to any database engine with minimum configuration, absolutely no code change in above layers.

*code sample for Entity Framework Repository implementation*

```
     /// <summary>
    ///     The Sample repository context.
    /// </summary>
    public class SampleRepositoryContext : EFRepositoryContext<Entities>
    {
        #region Fields

        /// <summary>
        ///     The connection string.
        /// </summary>
        private readonly string connectionString;

        #endregion

        public SampleRepositoryContext(IUnityContainer container)
        {
            connectionString = container.Resolve<string>("EFCEntities");
        }
        /// <summary>
        /// Creates the context.
        /// </summary>
        /// <returns></returns>
        protected override Entities CreateContext()
        {
            return new Entities(connectionString);
        }
    }
```
**Configurations**

EFC execution models starts with configuration file. In case of desktop applicaitons , it will be App.config for web applicationcations , it will be web.config. In Both of these, it injects same section details.

*sample App.config*
```
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <configSections>
    <section name="exceptionHandling"     type="Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration.ExceptionHandlingSettings, Microsoft.Practices.EnterpriseLibrary.ExceptionHandling, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
    
    <section name="policyInjection" type="Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration.PolicyInjectionSettings, Microsoft.Practices.EnterpriseLibrary.PolicyInjection, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
    
    <section name="loggingConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.LoggingSettings, Microsoft.Practices.EnterpriseLibrary.Logging, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
    
    <section name="unity" type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection, Microsoft.Practices.Unity.Configuration" />
    
    <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />

    </sectionGroup>
   
  </configSections>
  <policyInjection />
  <unity configSource="config\unity.config" />
  <loggingConfiguration configSource="config\logging.config" />
  <exceptionHandling configSource="config\exceptionHandling.config" />
  
  </configuration>
```
*Sample Unity configurations*

```
<?xml version="1.0" encoding="utf-8"?>

<unity >
  <typeAliases>
    <typeAlias alias="singleton" type="Microsoft.Practices.Unity.ContainerControlledLifetimeManager, Microsoft.Practices.Unity" />
    <typeAlias alias="bool" type="System.Boolean" />
    <typeAlias alias="string" type="System.String" />
    <typeAlias alias="object" type="System.Object" />
    <typeAlias alias="int" type="System.Int32" />
    <typeAlias alias="type" type="System.Type" />
    <typeAlias alias="perThread" type="Microsoft.Practices.Unity.PerThreadLifetimeManager, Microsoft.Practices.Unity" />
    <typeAlias alias="external" type="Microsoft.Practices.Unity.ExternallyControlledLifetimeManager, Microsoft.Practices.Unity" />
    <typeAlias alias="typeName" type="System.Configuration.TypeNameConverter, System.Configuration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" />
    <typeAlias alias="viewModel" type="EFC.Client.Common.Base.ViewModel, EFC.Common.Client" />

  </typeAliases>
  <containers>
    <container name="parent">
          <instance type="string" name="EFCEntities" value="metadata=res://*/Model.TTSModel.csdl|res://*/Model.TTSModel.ssdl|res://*/Model.TTSModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=localhost;initial catalog=EFC; MultipleActiveResultSets=True;App=EntityFramework&quot;"/>

      <types>

        <!--Repository Start-->

        <type type="EFC.Components.Data.IRepositoryContext, EFC.Components"
              mapTo="Sample.TTS.Service.Data.SampleRepositoryContext, Sample.TTS.Service">
          <lifetime type="singleton" />
        </type>

        <!--Repository End-->

        <!--Controller Start-->


        <!--Controller End-->

        <!--Services Start-->

        <register type="Sample.TTS.Service.ADService, EFC.TTS.Service" mapTo="Sample.TTS.Service.ADService,       Sample.TTS.Service">
        </register>

        <!--Services End-->

        <!--Application Services Start-->
        
        
        <register type="Sample.TTS.Service.Application.ASUserService, Sample.TTS.Service" mapTo="Sample.TTS.Service.Application.ASUserService, Sample.TTS.Service"/>

        <!--Application Services End-->

        <!--ViewModel Start-->

        <register name="LoginView" type="object" mapTo="Sample.TTS.Client.Views.LoginView, Sample.TTS.Client"/>
        <register type="Sample.TTS.Client.ViewModels.LoginViewModel, Sample.TTS.Client" mapTo="Sample.TTS.Client.ViewModels.LoginViewModel, Sample.TTS.Client">
          <property name="View">
            <dependency name="LoginView" />
          </property>
          <lifetime type="singleton" />
        </register>

        <!--ViewModel End-->

      </types>
    </container>
  </containers>
</unity>
```

*Sample Logging configuration*

```
<?xml version="1.0" encoding="utf-8" ?>

<loggingConfiguration name="experionlogging" tracingEnabled="true" defaultCategory="General">
  <listeners>
    
    <add name="logDefault" type="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.FlatFileTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
      listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.FlatFileTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
      fileName="Logs\trace.log" traceOutputOptions="LogicalOperationStack, DateTime, Timestamp, ProcessId, Callstack" />
    
    <add name="Rolling Flat File Trace Listener" type="Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners.RollingFlatFileTraceListener, Microsoft.Practices.EnterpriseLibrary.Logging, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
      listenerDataType="Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.RollingFlatFileTraceListenerData, Microsoft.Practices.EnterpriseLibrary.Logging, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
      fileName="Logs\activity.log" formatter="Text Formatter" rollInterval="Week"
      rollSizeKB="20480" maxArchivedFiles="20" traceOutputOptions="DateTime, Timestamp, Callstack" />
  </listeners>
  <formatters>
    <add type="Microsoft.Practices.EnterpriseLibrary.Logging.Formatters.TextFormatter, Microsoft.Practices.EnterpriseLibrary.Logging, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
      template="Timestamp: {timestamp}{newline}&#xA;&#xA;Message: {message}{newline}&#xA;&#xA;Category: {category}{newline}&#xA;&#xA;Priority: {priority}{newline}&#xA;&#xA;EventId: {eventid}{newline}&#xA;&#xA;Severity: {severity}{newline}&#xA;&#xA;Title:{title}{newline}&#xA;&#xA;Machine: {localMachine}{newline}&#xA;&#xA;App Domain: {localAppDomain}{newline}&#xA;&#xA;Process Name: {localProcessName}{newline}&#xA;&#xA;Thread Name: {threadName}{newline}&#xA;&#xA;Win32 ThreadId:{win32ThreadId}{newline}&#xA;&#xA;Extended Properties: {dictionary({key} - {value}{newline})}"
      name="Text Formatter" />
  </formatters>
  <categorySources>
    <add switchValue="ActivityTracing" name="General">
      <listeners>
        <add name="Rolling Flat File Trace Listener" />
      </listeners>
    </add>
  </categorySources>
  <specialSources>
    <allEvents switchValue="All" name="All Events">
      <listeners>
        <add name="Rolling Flat File Trace Listener" />
      </listeners>
    </allEvents>
    <notProcessed switchValue="All" name="Unprocessed Category">
      <listeners>
        <add name="Rolling Flat File Trace Listener" />
      </listeners>
    </notProcessed>
    <errors switchValue="All" name="Logging Errors &amp; Warnings">
      <listeners>
        <add name="Rolling Flat File Trace Listener" />
      </listeners>
    </errors>
  </specialSources>
</loggingConfiguration>
```

*Sample Exception Handling Configuration*

```
<?xml version="1.0" encoding="utf-8"?>

<exceptionHandling>
  <exceptionPolicies>
    <add name="ApplicationPolicy">
      <exceptionTypes>
        <add name="All Exceptions" type="System.Exception, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
          postHandlingAction="NotifyRethrow" />
      </exceptionTypes>
    </add>
  </exceptionPolicies>
</exceptionHandling>
```
