namespace Experion.TTS.Client.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using Experion.TTS.Client.Models;
    using Experion.TTS.Service.Model;

    using Infragistics.Olap;

    public static class DataExtensions
    {
        public static Timesheet ToEntity(this SheetModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new Timesheet
                   {

                       ActivityId = model.Activity == null ? 0 : model.Activity.ActivityId,
                       Duration = model.Duration,
                       Task = model.Task,
                       Project = model.ProjectName,
                       ProjectId = model.ProjectName == null ? 0 : model.ProjectName.ProjectId,
                       TimesheetDate = model.Date,
                       UserId = model.UserID,
                       TimesheetId = model.ID
                   };
        }

        /// <summary>
        /// To the project status model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static ProjectStatusModel ToProjectStatusModel(this ProjectStatu entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ProjectStatusModel
                   {
                       ProjectStatus = entity.ProjectStatus,
                       ProjectStatusId = entity.ProjectStatusId
                   };
        }

        /// <summary>
        /// To the project status models.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        public static IEnumerable<ProjectStatusModel> ToProjectStatusModels(this IEnumerable<ProjectStatu> entities)
        {
            if (entities == null)
            {
                return null;
            }

            return entities.Select(x => x.ToProjectStatusModel());
        }


        /// <summary>
        /// To the project model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static Project ToProjectEntity(this ProjectModel entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new Project
                   {
                       ProjectId = entity.ProjectId,
                       ProjectStatus = entity.ProjectStatus,
                       Code = entity.Code,
                       CostBudget = entity.CostBudget,
                       Description = entity.Description,
                       EffortBudget = entity.EffortBudget,
                       StartDate = entity.StartDate,
                       Status = entity.Status
                   };

        }

    }
}
