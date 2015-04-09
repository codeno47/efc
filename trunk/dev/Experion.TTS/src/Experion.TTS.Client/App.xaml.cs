using System.Windows;

namespace Experion.TTS.Client
{
    using Experion.TTS.Service.Model;

    using GalaSoft.MvvmLight.Threading;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }

        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        /// <value>
        /// The current user.
        /// </value>
        public static USER_DEFN CurrentUser { get; set; }
    }
}
