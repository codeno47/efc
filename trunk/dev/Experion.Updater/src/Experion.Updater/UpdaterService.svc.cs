using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Experion.Updater
{
    using Experion.Updater.Contracts;
    using Experion.Updater.Dto;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UpdaterService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UpdaterService.svc or UpdaterService.svc.cs at the Solution Explorer and start debugging.
    public class UpdaterService : IService1, IHealthService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public string GetMemoryUsage()
        {
            Int64 phav = PerformanceInfo.GetPhysicalAvailableMemoryInMiB();
            Int64 tot = PerformanceInfo.GetTotalMemoryInMiB();
            decimal percentFree = ((decimal)phav / (decimal)tot) * 100;
            decimal percentOccupied = 100 - percentFree;
            Console.WriteLine("Available Physical Memory (MiB) " + phav.ToString());
            Console.WriteLine("Total Memory (MiB) " + tot.ToString());
            Console.WriteLine("Free (%) " + percentFree.ToString());
            Console.WriteLine("Occupied (%) " + percentOccupied.ToString());
            Console.ReadLine();

            return percentOccupied.ToString();
        }
    }
}
