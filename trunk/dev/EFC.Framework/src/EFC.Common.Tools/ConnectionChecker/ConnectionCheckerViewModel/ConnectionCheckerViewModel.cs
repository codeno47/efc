// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ConnectionCheckerViewModel.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ConnectionCheckerViewModel.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System.Windows.Input;
using EFC.Client.Common.Base;
using Experion.Common.Tools.ConnectionChecker.ConnectionCheckerViewModel;
using Experion.Common.Tools.ConnectionChecker.Service;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.Unity;

namespace EFC.Common.Tools.ConnectionChecker.ConnectionCheckerViewModel
{
    /// <summary>
    /// ConnectionCheckerViewModel
    /// </summary>
    public class ConnectionCheckerViewModel : ViewModel<ConnectionModel>
    {
        /// <summary>
        /// Gets or sets the view.
        /// </summary>
        /// <value>
        /// The view.
        /// </value>
        public ConnectionCheckerView View { get; set; }

        /// <summary>
        /// Gets or sets the refresh data command.
        /// </summary>
        /// <value>
        /// The refresh data command.
        /// </value>
        public ICommand RefreshDataCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionCheckerViewModel" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="model">The model.</param>
        public ConnectionCheckerViewModel( ConnectionModel model,IUnityContainer container) : base(model,container)
        {
            Initilize();
        }

        /// <summary>
        /// Initilizes this instance.
        /// </summary>
        private void Initilize()
        {
            View = Unity.Resolve<ConnectionCheckerView>();
            View.DataContext = this;

            InitilizeCommand();
        }

        /// <summary>
        /// Initilizes the command.
        /// </summary>
        private void InitilizeCommand()
        {
            RefreshDataCommand = new RelayCommand(OnRefreshDataCommand);
        }

        /// <summary>
        /// Called when [refresh data command].
        /// </summary>
        private void OnRefreshDataCommand()
        {
            PopulateConnectionData();
        }

        /// <summary>
        /// Populates the connection data.
        /// </summary>
        private void PopulateConnectionData()
        {
            var service = Unity.Resolve<IDatabaseService>();

            if (service.IsServerActive())
            {
                Model.ConnectionData = service.GetConnectionDetailsToTable().DefaultView;
            }
        }
    }
}
