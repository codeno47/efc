using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Experion.HealthService.Dto
{
    using System.Runtime.Serialization;

    [DataContract]
    public class MachineProcessInfo
    {
        [DataMember]
        public List<ProcessInfo> ProcessInfos { get; set; }

        [DataMember]
        public string MachineName { get; set; }

        public MachineProcessInfo()
        {
            ProcessInfos = new List<ProcessInfo>();
        }
    }
}