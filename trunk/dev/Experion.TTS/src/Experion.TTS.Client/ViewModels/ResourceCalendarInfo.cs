namespace Experion.TTS.Client.ViewModels
{
    using System;

    public class ResourceCalendarInfo: BaseViewModel
    {

        #region Proeprties

        #region BaseColor
        private Nullable<int> _baseColor;

        public Nullable<int> BaseColor
        {
            get { return this._baseColor; }
            set
            {
                this._baseColor = value;
                this.OnPropertyChanged("BaseColor");
            }
        }
        #endregion //BaseColor

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

        #region OwningResourceId
        private string _owningResourceId;

        public string OwningResourceId
        {
            get { return this._owningResourceId; }
            set
            {
                this._owningResourceId = value;
                this.OnPropertyChanged("OwningResourceId");
            }
        }
        #endregion //OwningResourceId

        #region UnmappedProperties
        private string _unmappedProperties;

        public string UnmappedProperties
        {
            get { return this._unmappedProperties; }
            set { this._unmappedProperties = value; }
        }
        #endregion //UnmappedProperties 

        #endregion //Proeprties

    }
}
