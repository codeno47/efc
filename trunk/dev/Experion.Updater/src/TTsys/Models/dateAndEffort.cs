using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTsys.Models
{
    public class dateAndEffort
    {
        public DateTime effortDate { get; set; }

        public double netEffort { get; set; }

        public List<logDetails> LogDetailsList { get; set; }
    }
}