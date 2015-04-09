using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.Samples.Service.Contracts.Dto
{
    public class BeatPlanDto
    {
        public int Id { get; set; }
        public string PlanName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ExipryDate { get; set; }
        public int? OrganizationId { get; set; }
        public decimal? Target { get; set; }
        
       
    }
}
