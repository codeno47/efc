//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Experion.TTS.Service.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Activity
    {
        public Activity()
        {
            this.Timesheets = new HashSet<Timesheet>();
        }
    
        public int ActivityId { get; set; }
        public string ActivityCode { get; set; }
        public string ActivityDescription { get; set; }
        public bool IsActive { get; set; }
    
        public virtual ICollection<Timesheet> Timesheets { get; set; }
    }
}
