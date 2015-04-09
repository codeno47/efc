using System;
using System.Collections.Generic;
using EFC.Common.Service;
using EFC.Components.Data;
using Experion.TTS.Service.Model;
using Microsoft.Practices.Unity;

namespace Experion.TTS.Service.Application
{
    using System.Diagnostics;
    using System.Linq;

    using EFC.Components.Enum;

    /// <summary>
    /// Application Service
    /// </summary>
    public class ASTimeSheetService : ApplicationService<Entities>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASTimeSheetService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        public ASTimeSheetService(IUnityContainer unity, IRepositoryContext context)
            : base(unity, context)
        {
        }

        private IRepository<Timesheet, long> TimesheetRepository
        {
            get { return DataContext.GetRepository<Timesheet, long>(); }
        }

        public IEnumerable<Timesheet> GetTimeSheet(int userId, DateTime fromDate, DateTime toDate)
        {
            var roleSpecification = new Specification<Timesheet>(r => r.UserId.Equals(userId) && (r.TimesheetDate >= fromDate && r.TimesheetDate <= toDate));
            return TimesheetRepository.GetBySpecification(roleSpecification);
        }

        public void Add(Timesheet timesheet)
        {
            //var allTimeSheets = TimesheetRepository.GetAll(FilterType.FilterAll);
            //timesheet.TimesheetId = allTimeSheets.Max(p => p.Id) + 1;
            TimesheetRepository.Add(timesheet);
        }

        public void BulkAdd(IEnumerable<Timesheet> timesheets)
        {
            //var allTimeSheets = TimesheetRepository.GetAll(FilterType.FilterAll);
            //var maxId = allTimeSheets.Max(p => p.Id);

            foreach (var timesheet in timesheets)
            {
                //maxId++;
                //timesheet.TimesheetId = maxId;
                TimesheetRepository.Add(timesheet);
            }
        }

        public void Remove(Timesheet timesheet)
        {
            var timesheetToDelete = TimesheetRepository.GetById(timesheet.TimesheetId);

            Debug.Assert(timesheetToDelete != null, "TimeSheet entry not found in database");

            if (timesheetToDelete != null)
            {
                TimesheetRepository.Delete(timesheetToDelete);
            }

        }
    }
}
