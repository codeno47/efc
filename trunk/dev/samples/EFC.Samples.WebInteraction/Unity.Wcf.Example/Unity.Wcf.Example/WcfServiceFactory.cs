using System.Configuration;
using EFC.Samples.Service;
using EFC.Samples.Service.Contracts;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Unity.Wcf.Example
{
	public class WcfServiceFactory : UnityServiceHostFactory
	{
	    protected override void ConfigureContainer(IUnityContainer container)
        {
            var unityConfigurationSection = LoadUnityConfigurationFile();
           unityConfigurationSection.Configure(container, "parent");

            container.RegisterInstance(container, new PerThreadLifetimeManager());

			container.RegisterType<ICustomerService, CustomerService>().RegisterType<ICustomerRepository, CustomerRepository>();

            container.RegisterType<IRouteService, RouteService>();
        }

        /// <summary>
        /// Loads the unity configuration file.
        /// </summary>
        /// <returns>UnityConfigurationSection.</returns>
        private UnityConfigurationSection LoadUnityConfigurationFile()
        {
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            return section;
        }
    }    
}