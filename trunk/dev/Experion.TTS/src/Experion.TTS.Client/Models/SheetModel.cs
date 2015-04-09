using System;
using EFC.Client.Common.Base;

namespace Experion.TTS.Client.Models
{
    using Experion.TTS.Service.Model;

    /// <summary>
    /// SheetModel
    /// </summary>
    public class SheetModel : ModelBase
    {

        private DateTime date;

        private Activity activity;

        private Project projectName;

        private string projectDescription;

        private string task;

        private decimal duration;

        private string remarks;

        public int UserID { get; set; }

        public long ID { get; set; }
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                RaisePropertyChanged("Date");
            }
        }

        public Activity Activity
        {
            get { return activity; }
            set
            {
                activity = value;
                RaisePropertyChanged("Activity");
            }
        }

        public Project ProjectName
        {
            get { return projectName; }
            set
            {
                projectName = value;
                RaisePropertyChanged("ProjectName");
            }
        }

        public string Task
        {
            get { return task; }
            set
            {
                task = value;
                RaisePropertyChanged("Task");
            }
        }

        public decimal Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                RaisePropertyChanged("Duration");
            }
        }

        public string Remarks
        {
            get { return remarks; }
            set
            {
                remarks = value;
                RaisePropertyChanged("Remarks");
            }
        }

        public string ProjectDescription
        {
            get
            {
                return this.projectDescription;
            }
            set
            {
                this.projectDescription = value;
                this.RaisePropertyChanged("ProjectDescription");
            }
        }
    }
}
