// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ViewModel.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ViewModel.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using Microsoft.Practices.Unity;

namespace EFC.Client.Common.Base
{
    /// <summary>
    /// ViewModel Base class.
    /// </summary>
    public abstract class ViewModel : ViewModelBase, IDisposable
    {
        #region Fields

        /// <summary>
        /// The main window
        /// </summary>
        private Window mainWindow;

        #endregion

        #region Properties
        /// <summary>
        /// The view
        /// </summary>
        private object view;

        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        public object View
        {
            get
            {
                return view;
            }
            set
            {
                view = value;
                RaisePropertyChanged("View");
            }
        }

        /// <summary>
        /// Gets the main window of application.
        /// </summary>
        public Window MainWindow
        {
            get { return mainWindow ?? (mainWindow = Application.Current.MainWindow); }
            set { mainWindow = value; }
        }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets the Model.
        /// </summary>
        public ModelBase Model { get; private set; }

        /// <summary>
        /// Gets or sets the unity.
        /// </summary>
        /// <value>
        /// The unity.
        /// </value>
        protected IUnityContainer Unity { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        protected ViewModel(IUnityContainer container)
        {
            Unity = container;
            PropertyChanged += OnViewModelPropertyChaned;
        }

        /// <summary>
        /// Called when [view model property chaned].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void OnViewModelPropertyChaned(object sender, PropertyChangedEventArgs e)
        {
            if (string.Compare(e.PropertyName, "View", System.StringComparison.Ordinal) == 0)
            {
                InitilizeViewModel();
            }
        }

        /// <summary>
        /// Initilizes the view model.
        /// </summary>
        protected void InitilizeViewModel()
        {
            ((UserControl)View).DataContext = this;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {

        }
    }
}