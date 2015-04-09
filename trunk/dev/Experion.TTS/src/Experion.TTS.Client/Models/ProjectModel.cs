using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Patterns.Model;

namespace Experion.TTS.Client.Models
{
    /// <summary>
    /// 
    /// </summary>
    [NotifyPropertyChanged]
    public class ProjectModel
    {
        public int ProjectId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public byte Status { get; set; }
        public decimal EffortBudget { get; set; }
        public decimal CostBudget { get; set; }
        public int ProjectStatus { get; set; }
    }
}
