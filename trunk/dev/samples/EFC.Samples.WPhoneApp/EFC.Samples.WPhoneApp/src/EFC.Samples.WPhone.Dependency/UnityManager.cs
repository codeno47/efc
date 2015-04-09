﻿using System;
using System.IO;
using EFC.Samples.WPhone.Service.Contracts;
using EFC.Samples.WPhone.Services;
using EFC.Samples.WPhone.Services.Application;
using EFC.Samples.WPhone.Services.Data;
using EFC.Samples.WPhone.ViewModels;
using EFC.Samples.WPhone.Views;
using EFC.Service.Phone.RepositoryBase;
using Microsoft.Practices.Unity;

namespace EFC.Samples.WPhone.Dependency
{
    /// <summary>
    /// UnityManager.
    /// </summary>
    public class UnityManager
    {
        #region Fields

        /// <summary>
        /// The container
        /// </summary>
        public static IUnityContainer Container = new UnityContainer();


        #endregion

        /// <summary>
        /// Initializes the <see cref="UnityManager"/> class.
        /// </summary>
        static UnityManager()
        {
            ResgisterTypes();
        }

        #region Methods

        /// <summary>
        /// Resgisters the types.
        /// </summary>
        private static void ResgisterTypes()
        {
            Container.RegisterInstance(typeof (IUnityContainer), Container);

            RegisterClientObjects();
            RegisterServices();
        }

        private void InitilizeContainer()
        {
            //Container.
        }
        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private static void RegisterServices()
        {
            
            Container.RegisterInstance("connectionString", GetDatabaseLocation());
            Container.RegisterInstance("FieldMaxDataContainer", GetDatabaseLocation());

            var data = Container.Resolve<String>("connectionString");

            #region Services

            Container.RegisterType<IRepositoryContext, FieldMaxRepositoryContext>();
            Container.RegisterType<FieldMaxDataContext>(new InjectionConstructor(data));
            Container.RegisterType<SampleApplicationService>();
            Container.RegisterType<ISampleDataService, SampleDataService>();

            #endregion

        }


        /// <summary>
        /// Registers the client objects.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private static void RegisterClientObjects()
        {

            #region ViewModels

            Container.RegisterType<MainPage>("MainView");
            Container.RegisterType<MainViewModel>(new InjectionProperty("View", Container.Resolve<MainPage>("MainView")));

            #endregion

        }


        /// <summary>
        /// Gets the database location.
        /// </summary>
        /// <returns></returns>
        private static string GetDatabaseLocation()
        {
            return Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "fieldmax.sdf");
        }
        #endregion

    }
}
