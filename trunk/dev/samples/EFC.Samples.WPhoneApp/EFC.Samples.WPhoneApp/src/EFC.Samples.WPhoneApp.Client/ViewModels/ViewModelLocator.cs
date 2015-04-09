/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:EFC.Samples.WPhoneApp.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using EFC.Samples.WPhone.Dependency;
using EFC.Samples.WPhoneApp.Model;
using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace EFC.Samples.WPhone.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public  class ViewModelLocator
    {
        static ViewModelLocator()
        {
          
        }
         //<summary>
         //Gets the Main property.
         //</summary>
        /// <summary>
        /// Gets the main.
        /// </summary>
        /// <value>
        /// The main.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public static MainViewModel Main
        {
            get
            {
                return UnityManager.Container.Resolve<MainViewModel>();
            }
        }

        /// <summary>
        /// Gets the login.
        /// </summary>
        /// <value>
        /// The login.
        /// </value>
        public static LoginViewModel Login
        {
            get
            {
                return UnityManager.Container.Resolve<LoginViewModel>();
            }
        }

        /// <summary>
        /// Gets the home.
        /// </summary>
        /// <value>
        /// The home.
        /// </value>
        public static HomeViewModel Home
        {
            get
            {
                return UnityManager.Container.Resolve<HomeViewModel>();
            }
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}