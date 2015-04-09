// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="ViewModel.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="ViewModel.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using Microsoft.Practices.Unity;

namespace EFC.Common.Client.Phone.ViewModels
{
    /// <summary>
    /// ViewModel Base class.
    /// </summary>
    public abstract class ViewModel:ViewModelBase
    {
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
        /// Gets or sets the unity.
        /// </summary>
        /// <value>
        /// The unity.
        /// </value>
        public IUnityContainer Unity { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        protected ViewModel(IUnityContainer container)
        {
            Unity = container;
            PropertyChanged += OnViewModelPropertyChanged;
        }

        /// <summary>
        /// Called when [view model property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
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
    }
}
