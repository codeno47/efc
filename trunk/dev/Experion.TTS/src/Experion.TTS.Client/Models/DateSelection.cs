using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.TTS.Client.Models
{
    public class DateSelection
    {
        public DateSelection()
        {
            AddedDates = new List<DateTime>();
            RemovedDates = new List<DateTime>();
        }

        public List<DateTime> AddedDates { get; set; }

        public List<DateTime> RemovedDates { get; set; }
    }
}
