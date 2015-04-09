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
    
    public partial class USER_DEFN
    {
        public USER_DEFN()
        {
            this.ProjectMembers = new HashSet<ProjectMember>();
            this.Timesheets = new HashSet<Timesheet>();
        }
    
        public int UserId { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public byte Status { get; set; }
        public bool Management { get; set; }
        public bool IsActive { get; set; }
        public string SUN_OPR { get; set; }
        public Nullable<int> COLOR_TMPL { get; set; }
        public string DEFAULT_COUNTRY { get; set; }
        public string AREA { get; set; }
        public string DATACASH_LOGIN { get; set; }
    
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
        public virtual ICollection<Timesheet> Timesheets { get; set; }
    }
}
