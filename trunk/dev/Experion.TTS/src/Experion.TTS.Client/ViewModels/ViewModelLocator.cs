/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:Experion.TTS.Client.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using System;
using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Experion.TTS.Client.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {

        /// <summary>
        /// The parentUnityContainer
        /// </summary>
        private static IUnityContainer parentUnityContainer;

        /// <summary>
        /// Gets or sets the child parentUnityContainer.
        /// </summary>
        /// <value>
        /// The child parentUnityContainer.
        /// </value>
        private static IUnityContainer ChildContainer { get; set; }


        static ViewModelLocator()
        {
            BuildContainer();

            //ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //if (ViewModelBase.IsInDesignModeStatic)
            //{
            //    SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            //}
            //else
            //{
            //    SimpleIoc.Default.Register<IDataService, DataService>();
            //}

            //SimpleIoc.Default.Register<MainViewModel>();
        }

        /// <summary>
        /// Builds the parentUnityContainer.
        /// </summary>
        private static void BuildContainer()
        {
            var unityContainerParent = new UnityContainer();
            parentUnityContainer = unityContainerParent;

            BuildChildContainer();
        }

        /// <summary>
        /// Builds the child parentUnityContainer.
        /// </summary>
        private static void BuildChildContainer()
        {
            try
            {
                ChildContainer = parentUnityContainer.CreateChildContainer();
                ChildContainer.RegisterInstance(typeof (IUnityContainer), ChildContainer);
                var section = LoadUnityConfigurationFile();
                section.Configure(ChildContainer, "parent");
                parentUnityContainer.RegisterInstance(Guid.NewGuid());
            }
            catch (Exception e)
            {
                
            }
        }

        /// <summary>
        /// Loads the unity configuration file.
        /// </summary>
        /// <returns>Unity Configuration Section</returns>
        private static UnityConfigurationSection LoadUnityConfigurationFile()
        {
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            return section;
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public static MainViewModel Main
        {
            get
            {
                return ChildContainer.Resolve<MainViewModel>();
            }
        }

        public static LoginViewModel Login
        {
            get
            {
                return ChildContainer.Resolve<LoginViewModel>();
            }
        }

        public static ScheduleViewModel Schedule
        {
           get
            {
                return ChildContainer.Resolve<ScheduleViewModel>();
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