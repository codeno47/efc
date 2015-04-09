// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="LoginViewModel.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="LoginViewModel.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using EFC.Client.Common.Base;
using Experion.TTS.Client.Models;
using Experion.TTS.Service;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.Unity;
using System.Windows.Input;

namespace Experion.TTS.Client.ViewModels
{
    using Experion.TTS.Client.Views;
    using Experion.TTS.Service.Model;
    using System.Windows;

    /// <summary>
    /// LoginViewModel.
    /// </summary>
    public class LoginViewModel : ViewModel
    {
        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public LoginModel Model { get; set; }

        /// <summary>
        /// Gets or sets the time sheet view model.
        /// </summary>
        /// <value>
        /// The time sheet view model.
        /// </value>
        private TimeSheetViewModel TimeSheetViewModel { get; set; }

        /// <summary>
        /// Gets or sets the login command.
        /// </summary>
        /// <value>
        /// The login command.
        /// </value>
        public ICommand LoginCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        public ICommand PasswordChangedCommand { get; set; }

        /// <summary>
        /// Gets or sets the authentication service.
        /// </summary>
        /// <value>
        /// The authentication service.
        /// </value>
        public AuthenticationService AuthenticationService { get; set; }

        public ADService AdService { get; set; }

        /// <summary>
        /// Initializes a new instance of the LoginViewModel class.
        /// </summary>
        public LoginViewModel(IUnityContainer container)
            : base(container)
        {
            AdService = Unity.Resolve<ADService>();
            Model = new LoginModel();
            Model.UserName = Properties.Settings.Default.lastLogginUser;
            InitilizeCommands();

        }

        /// <summary>
        /// Initilizes the commands.
        /// </summary>
        private void InitilizeCommands()
        {
            LoginCommand = new RelayCommand(LoginCommandHandler);
            CancelCommand = new RelayCommand(CancelCommandHandler);
        }

        private void CancelCommandHandler()
        {

        }

        private bool IsLoginDataValid()
        {
            if (string.IsNullOrEmpty(Model.UserName) || string.IsNullOrEmpty(Model.Password))
            {
                MessageBox.Show(
                    "User / Password cannot be null",
                    "Login",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                return false;
            }

            return true;
        }
        /// <summary>
        /// Logins the command handler.
        /// </summary>
        private void LoginCommandHandler()
        {
            var loginView = View as LoginView;

            if (loginView != null)
            {
                this.Model.Password = loginView.PasswordDataBox.Password;
            }

            if (!IsLoginDataValid())
            {
                return;
            }

            Model.IsBusy = true;
            USER_DEFN user = null;
            AuthenticationService = Unity.Resolve<AuthenticationService>();

            var authenticationStatus = this.AdService.Authenticate(this.Model.UserName, this.Model.Password);

            if (!authenticationStatus)
            {
                MessageBox.Show(
                    "Invalid Username / Password",
                    "Login",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                Model.IsBusy = false;
                return;
            }

            if (AdService.IsAdminUser(this.Model.UserName, this.Model.Password))
            {
                Messenger.Default.Send(new RibbonVisibilityMessage { ItemName = "Project", IsEnabled = true });
            }

            user = AuthenticationService.IsValidUser(Model.UserName, Model.Password);
            if (user != null)
            {
                App.CurrentUser = user;

                TimeSheetViewModel = Unity.Resolve<TimeSheetViewModel>();
                TimeSheetViewModel.CurrentUser = user;

                Messenger.Default.Send(new RibbonVisibilityMessage { ItemName = "TimeSheet", IsEnabled = true });

                Messenger.Default.Send(new GoToViewModelMessage { ViewModel = TimeSheetViewModel });
            }
            else
            {
                MessageBox.Show(
                    "You don't have access to TTS.Please contact TTS Administrator for Access.",
                    "Login",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            Model.IsBusy = false;

        }

    }
}