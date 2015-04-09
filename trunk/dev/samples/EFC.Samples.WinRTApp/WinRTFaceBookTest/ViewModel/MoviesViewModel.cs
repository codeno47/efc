using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using Facebook;
using GalaSoft.MvvmLight;
using WinRTFaceBookTest.Model;
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
    public class MoviesViewModel : ViewModelBase
    {
        public ObservableCollection<MovieInfo> MovieList { get; set; }
        /// <summary>
        /// Initializes a new instance of the MoviesViewModel class.
        /// </summary>
        public MoviesViewModel()
        {
            MovieList = new ObservableCollection<MovieInfo>();
            LoadMovies();
        }

        private async void LoadMovies()
        {
            //HttpClient client = new HttpClient();
            //client.MaxResponseContentBufferSize = 256000;
            var temAccessToken =
                "CAACEdEose0cBAKVFZCpWCacwMidiPh3z8YO3etjPno0mWl2buinw1AsPwjKVa9Q2zrJARa5gZAigBsEp8OD2C0LHtSmx2Vrdjx0U54C8lJh93K1wxFJlZC3DxPc5eLpYZC5ShclIncKoDoUMpVde7khksIPjz4GAetK5VsVEa7VbF4fC8DMGrZAZBxpAVNaz2uzegLjUcyjQZDZD";
            var url = string.Format("https://graph.facebook.com/me/video.watches?access_token={0}&method=GET", temAccessToken);
            //HttpResponseMessage response = await client.GetAsync(url);
            //response.EnsureSuccessStatusCode();
            //String jsonResponse = await response.Content.ReadAsStringAsync();

            //FacebookUser User = JsonConvert.DeserializeObject<FacebookUser>(jsonResponse);

            var fb = new FacebookClient(temAccessToken);

        
            dynamic friendsTaskResult = await fb.GetTaskAsync("/me/video.watches?");
            var result = (IDictionary<string, object>)friendsTaskResult;
            var data = (IEnumerable<object>)result["data"];
            foreach (var item in data)
            {
                var movieData = (IDictionary<string, object>)item;

                var data2 = (IDictionary<string, object>)movieData["data"];
                var data3 = (IDictionary<string, object>)data2["movie"];

                MovieList.Add(new MovieInfo { Name = (string)data3["title"], Image = new BitmapImage(new Uri((string)data3["url"])) });
                //FacebookData.Friends.Add(new Friend { Name = (string)movieData["name"], id = (string)movieData["id"], PictureUri = new Uri(string.Format("https://graph.facebook.com/{0}/picture?type={1}&access_token={2}", (string)movieData["id"], "square", App.AccessToken)) });
            }

            //Frame.Navigate(typeof(FriendSelector));
        }

        
    }
}