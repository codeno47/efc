using System.Collections.ObjectModel;
using System.Windows.Data;
using EFC.Client.Common.Base;

namespace Experion.TTS.Client.Models
{
    using System;
    using System.ComponentModel;

    using Experion.TTS.Service.Model;

    /// <summary>
    /// TimeSheetModel
    /// </summary>
    public class TimeSheetModel : ModelBase
    {
        private  ObservableCollection<ProjectEffortPieModel> pieCollection;


        private ObservableCollection<SheetModel> timeSheetCollection;

        private ObservableCollection<DateTime> selectedDates;

        private ICollectionView timeSheetData;

        private Activity selectedActivity;

        public ObservableCollection<Activity> activities;

        private ObservableCollection<Project> projects;

        private Project selectedProjects;

        private Activity selectedActivities;

        private decimal selectedEffort;

        private string selectedTask;

        private SheetModel selectedTimeSheet;

        public ObservableCollection<Activity> Activities
        {
            get { return activities; }
            set
            {
                activities = value;
                RaisePropertyChanged("Activities");
            }
        }

        public ObservableCollection<SheetModel> TimeSheetCollection
        {
            get { return timeSheetCollection; }
            set
            {
                timeSheetCollection = value;
                RaisePropertyChanged("TimeSheetCollection");
            }
        }

        public ICollectionView TimeSheetData
        {
            get { return timeSheetData; }
            set
            {
                timeSheetData = value;
                RaisePropertyChanged("TimeSheetData");
            }
        }

        public Activity SelectedActivity
        {
            get
            {
                return this.selectedActivity;
            }
            set
            {
                this.selectedActivity = value;
                this.RaisePropertyChanged("SelectedActivity");
            }
        }

        public ObservableCollection<Project> Projects
        {
            get
            {
                return this.projects;
            }
            set
            {
                this.projects = value;
                this.RaisePropertyChanged("Projects");
            }
        }

        public ObservableCollection<DateTime> SelectedDates
        {
            get
            {
                return this.selectedDates;
            }
            set
            {
                this.selectedDates = value;
                this.RaisePropertyChanged("SelectedDates");
            }
        }

        public Project SelectedProjects
        {
            get
            {
                return this.selectedProjects;
            }
            set
            {
                this.selectedProjects = value;
                this.RaisePropertyChanged("SelectedProjects");
            }
        }

        public Activity SelectedActivities
        {
            get
            {
                return this.selectedActivities;
            }
            set
            {
                this.selectedActivities = value;
                this.RaisePropertyChanged("SelectedActivities");
            }
        }

        public decimal SelectedEffort
        {
            get
            {
                return this.selectedEffort;
            }
            set
            {
                this.selectedEffort = value;
                this.RaisePropertyChanged("SelectedEffort");

            }
        }

        public string SelectedTask
        {
            get
            {
                return this.selectedTask;
            }
            set
            {
                this.selectedTask = value;
                this.RaisePropertyChanged("SelectedTask");
            }
        }

        public ObservableCollection<ProjectEffortPieModel> PieCollection
        {
            get
            {
                return this.pieCollection;
            }
            set
            {
                this.pieCollection = value;
                this.RaisePropertyChanged("PieCollection");

            }
        }

        public SheetModel SelectedTimeSheet
        {
            get
            {
                return this.selectedTimeSheet;
            }
            set
            {
                this.selectedTimeSheet = value;
                this.RaisePropertyChanged("SelectedTimeSheet");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeSheetModel"/> class.
        /// </summary>
        public TimeSheetModel()
        {
            Activities = new ObservableCollection<Activity>();
            TimeSheetCollection = new ObservableCollection<SheetModel>();
            TimeSheetData = CollectionViewSource.GetDefaultView(TimeSheetCollection);
            SelectedDates = new ObservableCollection<DateTime>();
            PieCollection = new ObservableCollection<ProjectEffortPieModel>();

            if (TimeSheetData.GroupDescriptions != null)
            {
                TimeSheetData.GroupDescriptions.Add(new PropertyGroupDescription("Date"));
                TimeSheetData.GroupDescriptions.Add(new PropertyGroupDescription("ProjectName"));
            }
        }
    }
}
