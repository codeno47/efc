using System.Collections.Generic;
using System.Linq;
using EFC.Samples.Service.Contracts.Dto;

namespace EFC.Samples.Service.Extension
{
    public static class DataContractExtensions
    {
        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static BeatPlanDto ToDto(this Model.BeatPlan entity)
        {
            return new BeatPlanDto
                {
                    Id = entity.BeatPlanId,
                    Description = entity.Description,
                    ExipryDate = entity.ExipryDate,
                    IsActive = entity.IsActive,
                    OrganizationId = entity.OrganizationId,
                    PlanName = entity.PlanName,
                    Target = entity.Target
                };
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="entityCollection">The entity collection.</param>
        /// <returns></returns>
        public static IEnumerable<BeatPlanDto> ToDto(this IEnumerable<Model.BeatPlan> entityCollection)
        {
            return entityCollection.ToList().Select(beatplan => beatplan.ToDto());
        }
    }
}
