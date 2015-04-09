using System.Linq;
using EFC.Samples.Service.Contracts;
using EFC.Samples.Service.Contracts.Dto;
using Microsoft.Practices.Unity;

namespace Unity.Wcf.Example
{
    public class CustomerService : ICustomerService
    {
        private IUnityContainer unityContainer;

        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository, IUnityContainer container )
        {
            unityContainer = container;
            _customerRepository = customerRepository;
        }

        public GetCustomerResponse GetCustomer(GetCustomerRequest request)
        {
            var query = from customer in _customerRepository.Query()
                        where customer.Id == request.CustomerId
                        select new GetCustomerResponse
                                   {
                                       FirstName = customer.FirstName,
                                       LastName = customer.LastName
                                   };

            return query.FirstOrDefault();
        }

        public BeatPlanDto GetBeatPlan()
        {
            var service = unityContainer.Resolve<IRouteService>();
            return service.GetAllRoutes().FirstOrDefault();
        }
    }
}
