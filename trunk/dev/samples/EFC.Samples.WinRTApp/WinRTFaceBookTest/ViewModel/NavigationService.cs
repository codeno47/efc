using System;
using WinRTFaceBookTest.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WinRTFaceBookTest.ViewModel
{
    public class NavigationService : INavigationService
    {
        
        public void Navigate(Type sourcePageType)
        {
            var page = 
            ((Frame)Window.Current.Content).Navigate(sourcePageType);
        }
        public void Navigate(Type sourcePageType, object parameter)
        {
            ((Frame)Window.Current.Content).Navigate(sourcePageType, parameter);
        }
        public void GoBack()
        {
            ((Frame)Window.Current.Content).GoBack();
        }
    }
}
