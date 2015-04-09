using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Experion.HealthService.Dto
{
    using System.Runtime.Serialization;

    [DataContract]
    public class MachineMemoryInfo
    {
        [DataMember]
        public string MachineName { get; set; }

        [DataMember]
        public decimal AvailablePhysicalMemory { get; set; }

        [DataMember]
        public decimal TotalMemory { get; set; }

        [DataMember]
        public decimal FreeMemory { get; set; }

        [DataMember]
        public decimal Occupied { get; set; }
    }
}