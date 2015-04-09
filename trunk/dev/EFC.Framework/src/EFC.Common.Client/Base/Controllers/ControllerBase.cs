// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ControllerBase.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ControllerBase.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System.Windows;
using EFC.Components.Unity;

namespace EFC.Client.Common.Base.Controllers
{
    public abstract class ControllerBase : IController
    {
        #region Fields

        private Window mainWindow;

        #endregion

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// UnityContainerManager.
        /// </summary>
        private readonly UnityContainerManager unityContainer;

        /// <summary>
        /// Gets the main window of application.
        /// </summary>
        public Window MainWindow
        {
            get { return mainWindow ?? (mainWindow = Application.Current.MainWindow); }
            set { mainWindow = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerBase"/> class.
        /// </summary>
        protected ControllerBase()
        {
            unityContainer = UnityContainerManager.GetInstance(); 
        }

        /// <summary>
        /// Gets the unity container.
        /// </summary>
        public UnityContainerManager Unity
        {
            get { return unityContainer; }
        }
    }
}