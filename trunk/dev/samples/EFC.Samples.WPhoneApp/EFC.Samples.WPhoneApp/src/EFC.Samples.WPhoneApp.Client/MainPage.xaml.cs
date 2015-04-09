using EFC.Samples.WPhone.Messages;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;

namespace EFC.Samples.WPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void OnMainPageLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Messenger.Default.Register<NavigateToPageMessage>(
                this, (action) => ReceiveMessage(action)
                );

            ////Launch Login screen
            Messenger.Default.Send(new NavigateToPageMessage { PageName = "Login" });
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        private object ReceiveMessage(NavigateToPageMessage action)
        {
            var page = string.Format("/Views/{0}View.xaml", action.PageName);
            
            NavigationService.Navigate(new System.Uri(page,System.UriKind.Relative));
            return null;
        }
    }
}