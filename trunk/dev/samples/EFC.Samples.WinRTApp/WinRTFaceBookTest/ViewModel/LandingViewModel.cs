using System;
using System.Dynamic;
using System.Windows.Input;
using Facebook;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;
using WinRTFaceBookTest.Model;
using Windows.UI.Xaml.Media.Imaging;

namespace WinRTFaceBookTest.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LandingViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public ProfileModel Model { get; set; }

        /// <summary>
        /// The navigation service
        /// </summary>
        private INavigationService navigationService;

        /// <summary>
        /// Gets or sets the show movie command.
        /// </summary>
        /// <value>
        /// The show movie command.
        /// </value>
        public ICommand ShowMovieCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the LandingViewModel class.
        /// </summary>
        public LandingViewModel()
        {
            InitilizeCommand();
            navigationService = ServiceLocator.Current.GetInstance<NavigationService>();
            Model = new ProfileModel();
            LoadUserInfo();

        }

        /// <summary>
        /// Initilizes the command.
        /// </summary>
        private void InitilizeCommand()
        {
            ShowMovieCommand = new RelayCommand(ShowMovieCommandHandler);
        }

        /// <summary>
        /// Shows the movie command handler.
        /// </summary>
        private void ShowMovieCommandHandler()
        {
            navigationService.Navigate(typeof(MoviesView));
        }

        /// <summary>
        /// Loads the user information.
        /// </summary>
        private async void LoadUserInfo()
        {
            var fb = new FacebookClient(App.AccessToken);

            dynamic parameters = new ExpandoObject();
            parameters.access_token = App.AccessToken;
            parameters.fields = "name";

            dynamic result = await fb.GetTaskAsync("me", parameters);

            string profilePictureUrl = string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", App.FacebookId, "large", fb.AccessToken);

            var image = new BitmapImage(new Uri(profilePictureUrl));
            Model.Image = image;
            Model.Title = result.name;

        }
    }
}