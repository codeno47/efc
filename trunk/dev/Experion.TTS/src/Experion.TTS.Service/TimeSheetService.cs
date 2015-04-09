using EFC.Common.Service;
using Experion.TTS.Service.Application;
using Experion.TTS.Service.Model;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;

namespace Experion.TTS.Service
{
    using System.Threading.Tasks;

    /// <summary>
    /// Business Service
    /// </summary>
    public class TimeSheetService : BusinessService
    {
        /// <summary>
        /// Gets or sets the asynchronous time sheet service.
        /// </summary>
        /// <value>
        /// The asynchronous time sheet service.
        /// </value>
        [Dependency]
        public ASTimeSheetService ASTimeSheetService { get; set; }

        /// <summary>
        /// Gets or sets the asynchronous acvivity service.
        /// </summary>
        /// <value>
        /// The asynchronous acvivity service.
        /// </value>
        [Dependency]
        public ASAcvivityService ASAcvivityService { get; set; }

        [Dependency]
        public RepositoryService RepositoryService { get; set; }

        /// <summary>
        /// Gets or sets the asynchronous project service.
        /// </summary>
        /// <value>
        /// The asynchronous project service.
        /// </value>
        [Dependency]
        public ASProjectService ASProjectService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSheetService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        public TimeSheetService(IUnityContainer unity)
            : base(unity)
        {
        }

        public void AddTimeSheet(Timesheet timesheet)
        {
            ASTimeSheetService.Add(timesheet);
        }

        public void BulkAdd(IEnumerable<Timesheet> timesheets)
        {
            ASTimeSheetService.BulkAdd(timesheets);
        }

        public void Remove(Timesheet timesheet)
        {
            ASTimeSheetService.Remove(timesheet);
        }
        public IEnumerable<Activity> GetAllActivities()
        {
            return ASAcvivityService.GetAllActivitieses();
        }

        /// <summary>
        /// Gets all projects.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Project>> GetAllProjects(int userId = 0)
        {
            if (userId == 0)
            {
                return Task.Factory.StartNew(() => ASProjectService.GetAllProjects());
            }
            return Task.Factory.StartNew(() => ASProjectService.GetAllProjectForUser(userId));
        }

        /// <summary>
        /// Gets the time sheet.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns></returns>
        public IEnumerable<Timesheet> GetTimeSheet(int userId, DateTime fromDate, DateTime toDate)
        {
            var sheets = ASTimeSheetService.GetTimeSheet(userId, fromDate, toDate);

            //foreach (var timesheet in sheets)
            //{
            //    timesheet.Acitivity = ASAcvivityService.GetActivityById(timesheet.ActivityId);
            //    timesheet.Project = ASProjectService.GetProjectById(timesheet.ProjectId);
            //}

            return sheets;
        }
        public override int Save()
        {
            return RepositoryService.Save();
        }

        public override void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
