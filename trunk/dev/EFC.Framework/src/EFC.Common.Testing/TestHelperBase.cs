namespace EFC.Common.Testing
{
    using System.Configuration;

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    using Rhino.Mocks;

    /// <summary>
    /// TestHelperBase.
    /// </summary>
    public abstract class TestHelperBase
    {
        
        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public IUnityContainer Container { get; set; }

        /// <summary>
        /// Gets the unity container.
        /// </summary>
        /// <value>
        /// The unity container.
        /// </value>
        public IUnityContainer UnityContainer
        {
            get
            {
                if (this.Container == null)
                {
                    this.Container = MockRepository.GenerateStub<IUnityContainer>();
                }

                return this.Container;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestHelperBase"/> class.
        /// </summary>
        protected TestHelperBase()
        {
           // InitalizeUnity();
        }

        /// <summary>
        /// Gets the configuration file.
        /// </summary>
        /// <returns></returns>
        protected abstract string GetConfigurationFile();
       
        /// <summary>
        /// Initalizes the unity.
        /// </summary>
        private void InitalizeUnity()
        {
            var unitySection = this.LoadConfiguration();

            this.Container = new UnityContainer();
            unitySection.Configure(this.Container, "parent");
        }

        /// <summary>
        /// Loads the configuration.
        /// </summary>
        /// <returns></returns>
        private UnityConfigurationSection LoadConfiguration()
        {
            var fileMap = new ConfigurationFileMap(this.GetConfigurationFile());
            var configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
            return (UnityConfigurationSection)configuration.GetSection("unity");
        }
    }
}
