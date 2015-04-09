namespace Experion.TTS.Client.ViewModels
{
    using System;

    public class AppointmentInfo : BaseViewModel
    {

        #region Properties

        #region Description
        /// <summary>
        /// local variable _description
        /// </summary>
        private string _description;

        /// <summary>
        /// Identifies the Description property.
        /// </summary>		
        public string Description
        {
            get { return this._description; }
            set
            {
                this._description = value;
                this.OnPropertyChanged("Description");
            }
        }
        #endregion  //Description

        #region End

        /// <summary>
        /// local variable _end
        /// </summary>
        private DateTime _end; // = DateTime.Now;

        /// <summary>
        /// Identifies the End property.
        /// </summary>		
        public DateTime End
        {
            get { return this._end; }
            set
            {
                this._end = value;
                this.OnPropertyChanged("End");
            }
        }
        #endregion  //End

        #region EndTimeZoneId
        /// <summary>
        /// local variable _endTimeZoneId
        /// </summary>
        private string _endTimeZoneId;

        /// <summary>
        /// Identifies the EndTimeZoneId property.
        /// </summary>		
        public string EndTimeZoneId
        {
            get { return this._endTimeZoneId; }
            set
            {
                this._endTimeZoneId = value;
                this.OnPropertyChanged("EndTimeZoneId");
            }
        }
        #endregion  //EndTimeZoneId

        #region Id
        /// <summary>
        /// local variable _id
        /// </summary>
        private string _id;

        /// <summary>
        /// Identifies the Id property.
        /// </summary>		
        public string Id
        {
            get { return this._id; }
            set
            {
                this._id = value;
                this.OnPropertyChanged("Id");
            }
        }
        #endregion  //Id

        #region IsLocked
        /// <summary>
        /// local variable _myVar
        /// </summary>
        private Nullable<bool> _isLocked = true;

        /// <summary>
        /// Identifies the IsLocked property.
        /// </summary>		
        public Nullable<bool> IsLocked
        {
            get { return this._isLocked; }
            set
            {
                this._isLocked = value;
                this.OnPropertyChanged("IsLocked");
            }
        }
        #endregion  //IsLocked

        #region IsOccurrenceDeleted
        /// <summary>
        /// local variable _isOccurrenceDeleted
        /// </summary>
        private Nullable<bool> _isOccurrenceDeleted;

        /// <summary>
        /// Identifies the IsOccurrenceDeleted property.
        /// </summary>		
        public Nullable<bool> IsOccurrenceDeleted
        {
            get { return this._isOccurrenceDeleted; }
            set
            {
                this._isOccurrenceDeleted = value;
                this.OnPropertyChanged("IsOccurrenceDeleted");
            }
        }
        #endregion  //IsOccurrenceDeleted

        #region IsTimeZoneNeutral
        /// <summary>
        /// local variable _isTimeZoneNeutral
        /// </summary>
        private bool _isTimeZoneNeutral;

        /// <summary>
        /// Identifies the IsTimeZoneNeutral property.
        /// </summary>		
        public bool IsTimeZoneNeutral
        {
            get { return this._isTimeZoneNeutral; }
            set
            {
                this._isTimeZoneNeutral = value;
                this.OnPropertyChanged("IsTimeZoneNeutral");
            }
        }
        #endregion  //IsTimeZoneNeutral

        #region IsVisible
        /// <summary>
        /// local variable _isVisible
        /// </summary>
        private Nullable<bool> _isVisible;

        /// <summary>
        /// Identifies the IsVisible property.
        /// </summary>		
        public Nullable<bool> IsVisible
        {
            get { return this._isVisible; }
            set
            {
                this._isVisible = value;
                this.OnPropertyChanged("IsVisible");
            }
        }
        #endregion  //IsVisible

        #region Location
        /// <summary>
        /// local variable _location
        /// </summary>
        private string _location;

        /// <summary>
        /// Identifies the Location property.
        /// </summary>		
        public string Location
        {
            get { return this._location; }
            set
            {
                this._location = value;
                this.OnPropertyChanged("Location");
            }
        }
        #endregion  //Location

        #region MaxOccurrenceDateTime
        /// <summary>
        /// local variable _mxOccurrenceDateTime
        /// </summary>
        private Nullable<DateTime> _mxOccurrenceDateTime;

        /// <summary>
        /// Identifies the MaxOccurrenceDateTime property.
        /// </summary>		
        public Nullable<DateTime> MaxOccurrenceDateTime
        {
            get { return this._mxOccurrenceDateTime; }
            set
            {
                this._mxOccurrenceDateTime = value;
                this.OnPropertyChanged("MaxOccurrenceDateTime");
            }
        }
        #endregion  //MaxOccurrenceDateTime

        #region OriginalOccurrenceEnd

        /// <summary>
        /// local variable _originalOccurrenceEnd
        /// </summary>
        private DateTime _originalOccurrenceEnd; // = DateTime.Now;

        /// <summary>
        /// Identifies the OriginalOccurrenceEnd property.
        /// </summary>		
        public DateTime OriginalOccurrenceEnd
        {
            get { return this._originalOccurrenceEnd; }
            set
            {
                this._originalOccurrenceEnd = value;
                this.OnPropertyChanged("OriginalOccurrenceEnd");
            }
        }
        #endregion  //OriginalOccurrenceEnd

        #region OriginalOccurrenceStart

        /// <summary>
        /// local variable _originalOccurrenceStart
        /// </summary>
        private DateTime _originalOccurrenceStart; // = DateTime.Now;

        /// <summary>
        /// Identifies the OriginalOccurrenceStart property.
        /// </summary>		
        public DateTime OriginalOccurrenceStart
        {
            get { return this._originalOccurrenceStart; }
            set
            {
                this._originalOccurrenceStart = value;
                this.OnPropertyChanged("OriginalOccurrenceStart");
            }
        }
        #endregion  //OriginalOccurrenceStart

        #region OwningCalendarId
        /// <summary>
        /// local variable _owningCalendarId
        /// </summary>
        private string _owningCalendarId;

        /// <summary>
        /// Identifies the OwningCalendarId property.
        /// </summary>		
        public string OwningCalendarId
        {
            get { return this._owningCalendarId; }
            set
            {
                this._owningCalendarId = value;
                this.OnPropertyChanged("OwningCalendarId");
            }
        }
        #endregion  //OwningCalendarId

        #region OwningResourceId
        /// <summary>
        /// local variable _owningResourceId
        /// </summary>
        private string _owningResourceId;

        /// <summary>
        /// Identifies the OwningResourceId property.
        /// </summary>		
        public string OwningResourceId
        {
            get { return this._owningResourceId; }
            set
            {
                this._owningResourceId = value;
                this.OnPropertyChanged("OwningResourceId");
            }
        }
        #endregion  //OwningResourceId

        #region Recurrence
        /// <summary>
        /// local variable _recurrence
        /// </summary>
        private string _recurrence;

        /// <summary>
        /// Identifies the Recurrence property.
        /// </summary>		
        public string Recurrence
        {
            get { return this._recurrence; }
            set
            {
                this._recurrence = value;
                this.OnPropertyChanged("Recurrence");
            }
        }
        #endregion  //Recurrence

        #region RecurrenceVersion
        /// <summary>
        /// local variable _recurrenceVersion
        /// </summary>
        private Nullable<int> _recurrenceVersion;

        /// <summary>
        /// Identifies the RecurrenceVersion property.
        /// </summary>		
        public Nullable<int> RecurrenceVersion
        {
            get { return this._recurrenceVersion; }
            set
            {
                this._recurrenceVersion = value;
                this.OnPropertyChanged("RecurrenceVersion");
            }
        }
        #endregion  //RecurrenceVersion

        #region Reminder
        /// <summary>
        /// local variable _reminder
        /// </summary>
        private string _reminder;

        /// <summary>
        /// Identifies the Reminder property.
        /// </summary>		
        public string Reminder
        {
            get { return this._reminder; }
            set
            {
                this._reminder = value;
                this.OnPropertyChanged("Reminder");
            }
        }
        #endregion  //Reminder

        #region ReminderEnabled
        /// <summary>
        /// local variable _reminderEnabled
        /// </summary>
        private Nullable<bool> _reminderEnabled;

        /// <summary>
        /// Identifies the ReminderEnabled property.
        /// </summary>		
        public Nullable<bool> ReminderEnabled
        {
            get { return this._reminderEnabled; }
            set
            {
                this._reminderEnabled = value;
                this.OnPropertyChanged("ReminderEnabled");
            }
        }
        #endregion  //ReminderEnabled

        #region ReminderInterval
        /// <summary>
        /// local variable _ReminderInterval
        /// </summary>
        private TimeSpan _reminderInterval;

        /// <summary>
        /// Identifies the ReminderInterval property.
        /// </summary>		
        public TimeSpan ReminderInterval
        {
            get { return this._reminderInterval; }
            set
            {
                this._reminderInterval = value;
                this.OnPropertyChanged("ReminderInterval");
            }
        }
        #endregion  //ReminderInterval

        #region RootActivityId
        /// <summary>
        /// local variable _rootActivityId
        /// </summary>
        private string _rootActivityId;

        /// <summary>
        /// Identifies the RootActivityId property.
        /// </summary>		
        public string RootActivityId
        {
            get { return this._rootActivityId; }
            set
            {
                this._rootActivityId = value;
                this.OnPropertyChanged("RootActivityId");
            }
        }
        #endregion  //RootActivityId

        #region Start

        /// <summary>
        /// local variable _start
        /// </summary>
        private DateTime _start; // = DateTime.Now;

        /// <summary>
        /// Identifies the Start property.
        /// </summary>		
        public DateTime Start
        {
            get { return this._start; }
            set
            {
                this._start = value;
                this.OnPropertyChanged("Start");
            }
        }
        #endregion  //Start

        #region StartTimeZoneId
        /// <summary>
        /// local variable _startTimeZoneId
        /// </summary>
        private string _startTimeZoneId;

        /// <summary>
        /// Identifies the StartTimeZoneId property.
        /// </summary>		
        public string StartTimeZoneId
        {
            get { return this._startTimeZoneId; }
            set
            {
                this._startTimeZoneId = value;
                this.OnPropertyChanged("StartTimeZoneId");
            }
        }
        #endregion  //StartTimeZoneId

        #region Subject
        /// <summary>
        /// local variable _myVar
        /// </summary>
        private string _subject;

        /// <summary>
        /// Identifies the Subject property.
        /// </summary>		
        public string Subject
        {
            get { return this._subject; }
            set
            {
                this._subject = value;
                this.OnPropertyChanged("Subject");
            }
        }
        #endregion  //Subject

        #region UnmappedProperties
        /// <summary>
        /// local variable _unmappedProperties
        /// </summary>
        private string _unmappedProperties;

        /// <summary>
        /// Identifies the UnmappedProperties property.
        /// </summary>		
        public string UnmappedProperties
        {
            get { return this._unmappedProperties; }
            set
            {
                this._unmappedProperties = value;
                this.OnPropertyChanged("UnmappedProperties");
            }
        }
        #endregion  //UnmappedProperties

        #region VariantProperties
        /// <summary>
        /// local variable _variantProperties
        /// </summary>
        private Nullable<long> _variantProperties;

        /// <summary>
        /// Identifies the VariantProperties property.
        /// </summary>		
        public Nullable<long> VariantProperties
        {
            get { return this._variantProperties; }
            set
            {
                this._variantProperties = value;
                this.OnPropertyChanged("VariantProperties");
            }
        }
        #endregion  //VariantProperties 

        #endregion //Properties

    }
}
