namespace Experion.HealthService
{
    using System.Collections.Generic;
    using System.ServiceModel;

    using Experion.HealthService.Dto;

    [ServiceContract]
    public interface IHealthService
    {
        [OperationContract]
        MachineMemoryInfo GetMemoryUsage();

        [OperationContract]
        MachineProcessInfo GetAllMemoryStatics();

        [OperationContract]
        bool RestartIIS();
    }
}