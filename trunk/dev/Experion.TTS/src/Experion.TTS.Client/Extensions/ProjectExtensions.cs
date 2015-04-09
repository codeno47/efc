using System.Collections.Generic;
using System.Linq;

namespace Experion.TTS.Client.Extensions
{
    using Experion.TTS.Client.Models;
    using Experion.TTS.Service.Model;

    public static class ProjectExtensions
    {
        public static ProjectModel ToProjectModel(this Project entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ProjectModel
                   {
                       Code = entity.Code,
                       CostBudget = entity.CostBudget,
                       Description = entity.Description,
                       EffortBudget = entity.EffortBudget,
                       ProjectId = entity.ProjectId,
                       ProjectStatus = entity.ProjectStatus,
                       StartDate = entity.StartDate,
                       Status = entity.Status
                   };
        }

        /// <summary>
        /// To the member models.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public static IEnumerable<ProjectModel> ToMemberModels(this IEnumerable<Project> entities)
        {
            if (entities == null)
            {
                return null;
            }
            return entities.Select(x => x.ToProjectModel());
        }
    }
}
