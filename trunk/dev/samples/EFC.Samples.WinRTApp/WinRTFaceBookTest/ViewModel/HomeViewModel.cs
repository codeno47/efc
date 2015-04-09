using System;
using System.Dynamic;
using System.Threading.Tasks;
using System.Windows.Input;
using Facebook;
using Facebook.Client;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using WinRTFaceBookTest.Model;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace WinRTFaceBookTest.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class HomeViewModel : ViewModelBase
    {
        public ICommand LoginClickCommand { get; set; }

        private FacebookSession session;


        private readonly INavigationService navigationService;

        /// <summary>
        /// Initializes a new instance of the HomeViewModel class.
        /// </summary>
        public HomeViewModel()
        {
            InitlizeCommand();

            navigationService = ServiceLocator.Current.GetInstance<NavigationService>();
        }

        private void InitlizeCommand()
        {
            LoginClickCommand = new RelayCommand(LogingClickCommandHandler);
        }

        private async void LogingClickCommandHandler()
        {
            if (!App.IsAuthenticated)
            {
                App.IsAuthenticated = true;
                await Authenticate();
            }
        }

        private async Task Authenticate()
        {
            string message = String.Empty;
            try
            {
                session = await App.FacebookSessionClient.LoginAsync("user_about_me,read_stream");
                App.AccessToken = session.AccessToken;
                App.FacebookId = session.FacebookId;

                //Frame.Navigate(typeof(LandingPage));
                navigationService.Navigate(typeof(LandingPage));
            }
            catch (InvalidOperationException e)
            {
                message = "Login failed! Exception details: " + e.Message;
                var dialog = new MessageDialog(message);
                dialog.ShowAsync();
            }
        }


    }
}