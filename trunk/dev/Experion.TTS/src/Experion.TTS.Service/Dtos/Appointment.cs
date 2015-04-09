using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.TTS.Service.Dtos
{
    public class Appointment
    {
        public string Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string OwningResourceId { get; set; }
        public string OwningCalendarId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
