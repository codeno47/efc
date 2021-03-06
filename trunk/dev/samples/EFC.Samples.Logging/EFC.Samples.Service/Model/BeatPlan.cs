//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFC.Samples.Service.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class BeatPlan
    {
        public BeatPlan()
        {
            this.BeatPlanSettings = new HashSet<BeatPlanSetting>();
        }
    
        public int BeatPlanId { get; set; }
        public string PlanName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> ExipryDate { get; set; }
        public Nullable<int> OrganizationId { get; set; }
        public Nullable<decimal> Target { get; set; }
    
        public virtual ICollection<BeatPlanSetting> BeatPlanSettings { get; set; }
    }
}
