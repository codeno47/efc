namespace Experion.TTS.Client.ViewModels
{
    using System.Collections.ObjectModel;

    using Infragistics.Controls.Schedules;

    public class ScheduleViewModel : BaseViewModel
    {

        #region Construtors
        public ScheduleViewModel()
        {
        }

        public ScheduleViewModel(string currentUserId, string currentUserName, string currentUserCalendarId)
        {
            this.Resources.Add(new ResourceInfo
            {
                Id = currentUserId,
                Name = currentUserName

            });

            this.ResourceCalendars.Add(new ResourceCalendarInfo
            {
                Id = currentUserCalendarId,
                OwningResourceId = currentUserId
            });

            this.CurrentResourceCalendar = this.ResourceCalendars[0];

        }
        #endregion //Construtors

        #region Properties

        #region Appointments
        private ObservableCollection<AppointmentInfo> _appointments = new ObservableCollection<AppointmentInfo>();
        public ObservableCollection<AppointmentInfo> Appointments
        {
            get { return this._appointments; }
            set
            {
                this._appointments = value;
                this.OnPropertyChanged("Appointments");
            }
        }
        #endregion //Appointments

        #region CalendarDisplayMode
        /// <summary>
        /// local variable _CalendarDisplayMode 
        /// </summary>
        private CalendarDisplayMode _calendarDisplayMode = CalendarDisplayMode.Separate;

        /// <summary>
        /// Identifies the CalendarDisplayMode  property.
        /// </summary>		
        public CalendarDisplayMode CalendarDisplayMode
        {
            get { return this._calendarDisplayMode; }
            set
            {
                this._calendarDisplayMode = value;
                this.OnPropertyChanged("CalendarDisplayMode ");
            }
        }
        #endregion  //CalendarDisplayMode

        #region CurrentResourceCalendar
        private ResourceCalendarInfo _currentResourceCalendar = new ResourceCalendarInfo();
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public ResourceCalendarInfo CurrentResourceCalendar
        {
            get { return this._currentResourceCalendar; }
            set
            {
                this._currentResourceCalendar = value;
                this.OnPropertyChanged("CurrentResourceCalendar");
            }
        }
        #endregion //CurrentResourceCalendar

        #region Resources
        private ObservableCollection<ResourceInfo> _resources = new ObservableCollection<ResourceInfo>();
        public ObservableCollection<ResourceInfo> Resources
        {
            get { return this._resources; }
            set
            {
                this._resources = value;
                this.OnPropertyChanged("Resources");
            }
        }
        #endregion //Resources

        #region ResourceCalendars
        private ObservableCollection<ResourceCalendarInfo> _resourceCalendars = new ObservableCollection<ResourceCalendarInfo>();
        public ObservableCollection<ResourceCalendarInfo> ResourceCalendars
        {
            get { return this._resourceCalendars; }
            set
            {
                this._resourceCalendars = value;
                this.OnPropertyChanged("ResourceCalendars");
            }
        }
        #endregion //ResourceCalendars 

        #endregion //Properties

    }
}
