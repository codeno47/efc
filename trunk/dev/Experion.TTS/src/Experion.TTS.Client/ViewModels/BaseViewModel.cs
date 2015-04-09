namespace Experion.TTS.Client.ViewModels
{
    using System.ComponentModel;
    using System.Windows;

    public abstract class BaseViewModel : DependencyObject, INotifyPropertyChanged
    {

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region OnPropertyChanged
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));

        }
        #endregion //OnPropertyChanged
    }
}
