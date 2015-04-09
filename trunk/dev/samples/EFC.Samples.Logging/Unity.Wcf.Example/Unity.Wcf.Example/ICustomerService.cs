using System.ServiceModel;
using EFC.Samples.Service.Contracts.Dto;

namespace Unity.Wcf.Example
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        GetCustomerResponse GetCustomer(GetCustomerRequest request);

        [OperationContract]
        BeatPlanDto GetBeatPlan();
    }
}
