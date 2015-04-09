using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTsys.Models
{
    public class LeaveTracker
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public double NetEffort { get; set; }

        public double Leave{ get; set; }

        public List<logDetails> LogDetailsList { get; set; }
    }
}