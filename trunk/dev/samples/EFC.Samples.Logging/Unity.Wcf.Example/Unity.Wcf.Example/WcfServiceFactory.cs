using EFC.Samples.Service;
using EFC.Samples.Service.Contracts;
using Microsoft.Practices.Unity;

namespace Unity.Wcf.Example
{
	public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterInstance(container, new PerThreadLifetimeManager());

			container.RegisterType<ICustomerService, CustomerService>().RegisterType<ICustomerRepository, CustomerRepository>();

            container.RegisterType<IRouteService, RouteService>();
        }
    }    
}