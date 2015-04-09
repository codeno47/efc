using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Experion.HealthService.Dto
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ProcessInfo
    {
        [DataMember]
        public long WorkingSet { get; set; }

         [DataMember]
        public string Name { get; set; }

    }
}