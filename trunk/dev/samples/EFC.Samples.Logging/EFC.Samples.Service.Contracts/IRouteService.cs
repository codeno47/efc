using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Samples.Service.Contracts.Dto;

namespace EFC.Samples.Service.Contracts
{
    public interface IRouteService
    {
        IEnumerable<BeatPlanDto> GetAllRoutes();

        BeatPlanDto GetBeatPlan(BeatPlanDto beatPlan);
    }
}
