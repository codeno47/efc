// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ViewModel`2.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ViewModel`2.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;

namespace EFC.Client.Common.Base
{
    /// <summary>
    /// ViewModel Base class.
    /// </summary>
    /// <typeparam name="TInstance">The type of the instance.</typeparam>
    /// <typeparam name="TData">Model. </typeparam>
    /// <typeparam name="TParam">Business controller. </typeparam>
    public abstract class ViewModel<TInstance, TParam, TData> : ViewModelBase, IDisposable
    {/// <summary>
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
            get { return view; }
            set
            {
                view = value;
                RaisePropertyChanged("View");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel{TInstance}" /> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="model">The controller.</param>
        private ViewModel(TInstance controller, TData model)
        {
            Model = model;
            ScreenController = controller;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel&lt;TInstance, TParam, TData&gt;"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="businessController">The business controller.</param>
        /// <param name="model">The model.</param>
        private ViewModel(TInstance controller,TParam businessController, TData model)
        {
            BusinessController = businessController;
            Model = model;
            ScreenController = controller;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel{TInstance}"/> class.
        /// </summary>
        private ViewModel()
        {
            PropertyChanged += OnViewModelPropertyChaned;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel{TInstance}"/> class.
        /// </summary>
        private ViewModel(TData model)
        {
            Model = model;
            PropertyChanged += OnViewModelPropertyChaned;
        }

        #region Fields

        private Window mainWindow;

        #endregion

        #region Properties

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
        /// Gets the controller.
        /// </summary>
        public TInstance ScreenController { get; private set; }

        /// <summary>
        /// Gets the business controller.
        /// </summary>
        public TParam BusinessController { get; private set; }

        /// <summary>
        /// Gets the business controller.
        /// </summary>
        public TData Model { get; private set; }

        #endregion

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
        private void InitilizeViewModel()
        {
            ((UserControl)View).DataContext = this;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void OnDispose()
        {
            Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}
