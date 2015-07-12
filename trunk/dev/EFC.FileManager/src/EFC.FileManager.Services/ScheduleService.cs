using System;
using System.Collections.Generic;
using System.Linq;
using EFC.FileManager.Services.Dto;

namespace EFC.FileManager.Services
{
    public class ScheduleService
    {
        /// <summary>
        /// Gets or sets the schedules.
        /// </summary>
        /// <value>
        /// The schedules.
        /// </value>
        public List<ScheduleInfo> Schedules { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleService"/> class.
        /// </summary>
        public ScheduleService()
        {
            Schedules = new List<ScheduleInfo>();
        }

        /// <summary>
        /// Adds the schedule.
        /// </summary>
        /// <param name="schedule">The schedule.</param>
        public void AddSchedule(ScheduleInfo schedule)
        {
            schedule.Id = schedule.FilePath.GetHashCode();

            if (Schedules.All(p => p.Id != schedule.Id))
            {
                Schedules.Add(schedule);
            }
        }

        /// <summary>
        /// Removes the schedule.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        public void RemoveSchedule(int id)
        {
            var itemToRemove = Schedules.FirstOrDefault(p => p.Id == id);
            if (itemToRemove != null)
            {
                Schedules.Remove(itemToRemove);
            }
        }
        /// <summary>
        /// Gets the current schedules.
        /// </summary>
        /// <returns></returns>
        public List<ScheduleInfo> GetCurrentSchedules()
        {
            var currentTime = DateTime.Now;
            var result = new List<ScheduleInfo>();

            foreach (var scheduleInfo in Schedules)
            {
                if (CompareDate(currentTime, scheduleInfo.Time))
                {
                    result.Add(scheduleInfo);
                }
            }

            return result;
        }

        /// <summary>
        /// Compares the date.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        private bool CompareDate(DateTime left, DateTime right)
        {
            if (left.Day == right.Day
                && left.Month == right.Month
                && left.Year == right.Year
                && left.Hour == right.Hour
                && left.Minute == right.Minute)
            {
                return true;
            }

            return false;
        }
    }
}
