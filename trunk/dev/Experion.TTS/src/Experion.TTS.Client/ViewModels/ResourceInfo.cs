namespace Experion.TTS.Client.ViewModels
{
    using System;

    public class ResourceInfo : BaseViewModel
    {

        #region Properties

        #region DaySettingsOverrides
        private string _daySettingsOverrides;

        public string DaySettingsOverrides
        {
            get { return this._daySettingsOverrides; }
            set
            {
                this._daySettingsOverrides = value;
                this.OnPropertyChanged("DaySettingsOverrides");
            }
        }
        #endregion //DaySettingsOverrides

        #region DaysOfWeek
        private string _daysOfWeek;

        public string DaysOfWeek
        {
            get { return this._daysOfWeek; }
            set
            {
                this._daysOfWeek = value;
                this.OnPropertyChanged("DaysOfWeek");
            }
        }
        #endregion //DaysOfWeek

        #region Description
        private string _description;

        public string Description
        {
            get { return this._description; }
            set
            {
                this._description = value;
                this.OnPropertyChanged("Description");
            }
        }
        #endregion //Description

        #region EmailAddress
        private string _emailAddress;

        public string EmailAddress
        {
            get { return this._emailAddress; }
            set
            {
                this._emailAddress = value;
                this.OnPropertyChanged("EmailAddress");
            }
        }
        #endregion //EmailAddress

        #region FirstDayOfWeek
        private Nullable<byte> _firstDayOfWeek;

        public Nullable<byte> FirstDayOfWeek
        {
            get { return this._firstDayOfWeek; }
            set
            {
                this._firstDayOfWeek = value;
                this.OnPropertyChanged("FirstDayOfWeek");
            }
        }
        #endregion //FirstDayOfWeek

        #region Id
        private string _id;

        public string Id
        {
            get { return this._id; }
            set
            {
                this._id = value;
                this.OnPropertyChanged("Id");
            }

        }
        #endregion //Id

        #region IsLocked
        private string _isLocked;

        public string IsLocked
        {
            get { return this._isLocked; }
            set
            {
                this._isLocked = value;
                this.OnPropertyChanged("IsLocked");
            }
        }
        #endregion //IsLocked

        #region IsVisible
        private string _isVisible;

        public string IsVisible
        {
            get { return this._isVisible; }
            set
            {
                this._isVisible = value;
                this.OnPropertyChanged("IsVisible");
            }
        }
        #endregion //IsVisible

        #region Name
        private string _name;

        public string Name
        {
            get { return this._name; }
            set
            {
                this._name = value;
                this.OnPropertyChanged("Name");
            }
        }
        #endregion //Name

        #region PrimaryCalendarId
        private string _primaryCalendarId;

        public string PrimaryCalendarId
        {
            get { return this._primaryCalendarId; }
            set
            {
                this._primaryCalendarId = value;
                this.OnPropertyChanged("PrimaryCalendarId");
            }
        }
        #endregion //PrimaryCalendarId

        #region PrimaryTimeZoneId
        private string _primaryTimeZoneId;

        public string PrimaryTimeZoneId
        {
            get { return this._primaryTimeZoneId; }
            set
            {
                this._primaryTimeZoneId = value;
                this.OnPropertyChanged("PrimaryTimeZoneId");
            }
        }
        #endregion //PrimaryTimeZoneId 

        #endregion //Properties
    }
}
