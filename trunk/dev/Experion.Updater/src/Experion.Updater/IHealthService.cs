using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Experion.Updater.Contracts
{
    using System.Drawing.Printing;
    using System.ServiceModel;

    [ServiceContract]
    public interface IHealthService
    {
        [OperationContract]
        string GetMemoryUsage();
    }
}