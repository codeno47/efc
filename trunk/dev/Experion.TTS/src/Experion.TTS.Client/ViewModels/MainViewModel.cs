using EFC.Client.Common.Base;
using Experion.TTS.Client.Models;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.Unity;

namespace Experion.TTS.Client.ViewModels
{
    using Experion.TTS.Client.Constants;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;

    /// <summary>
    /// MainViewModel.
    /// </summary>
    public class MainViewModel : ViewModel
    {
        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        /// <summary>
        /// The welcome title
        /// </summary>
        private string welcomeTitle = string.Empty;

        /// <summary>
        /// The region
        /// </summary>
        private object region;

        /// <summary>
        /// The is time sheet enabled
        /// </summary>
        private bool isTimeSheetEnabled;

        /// <summary>
        /// Gets or sets the login view model.
        /// </summary>
        /// <value>
        /// The login view model.
        /// </value>
        private LoginViewModel LoginViewModel { get; set; }

        /// <summary>
        /// Gets or sets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        public object Region
        {
            get
            {
                return region;
            }
            set
            {
                region = value;
                RaisePropertyChanged("Region");
            }
        }

        /// <summary>
        /// Gets or sets the bulk time sheet add command.
        /// </summary>
        /// <value>
        /// The bulk time sheet add command.
        /// </value>
        public ICommand BulkTimeSheetAddCommand { get; set; }

        /// <summary>
        /// Gets or sets the save ribbon command.
        /// </summary>
        /// <value>
        /// The save ribbon command.
        /// </value>
        public ICommand SaveRibbonCommand { get; set; }

        /// <summary>
        /// Gets or sets the add project command.
        /// </summary>
        /// <value>
        /// The add project command.
        /// </value>
        public ICommand AddProjectCommand { get; set; }

        /// <summary>
        /// Gets or sets the show all projects command.
        /// </summary>
        /// <value>
        /// The show all projects command.
        /// </value>
        public ICommand ShowAllProjectsCommand { get; set; }

        /// <summary>
        /// Gets or sets the manage project command.
        /// </summary>
        /// <value>
        /// The manage project command.
        /// </value>
        public ICommand ManageProjectCommand { get; set; }

        /// <summary>
        /// Gets or sets the show time sheet command.
        /// </summary>
        /// <value>
        /// The show time sheet command.
        /// </value>
        public ICommand ShowTimeSheetCommand { get; set; }

        /// <summary>
        /// Gets or sets the add user command.
        /// </summary>
        /// <value>
        /// The add user command.
        /// </value>
        public ICommand AddUserCommand { get; set; }

        /// <summary>
        /// Gets or sets the show users command.
        /// </summary>
        /// <value>
        /// The show users command.
        /// </value>
        public ICommand ShowUsersCommand { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is time sheet enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is time sheet enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsTimeSheetEnabled
        {
            get
            {
                return this.isTimeSheetEnabled;
            }
            set
            {
                this.isTimeSheetEnabled = value;
                RaisePropertyChanged("IsTimeSheetEnabled");
            }
        }


        /// <summary>
        /// The is project ribbon enabled
        /// </summary>
        private bool isProjectRibbonEnabled;


        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return welcomeTitle;
            }

            set
            {
                if (welcomeTitle == value)
                {
                    return;
                }

                welcomeTitle = value;
                RaisePropertyChanged(WelcomeTitlePropertyName);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is project ribbon enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is project ribbon enabled; otherwise, <c>false</c>.
        /// </value>
        public bool IsProjectRibbonEnabled
        {
            get
            {
                return this.isProjectRibbonEnabled;
            }
            set
            {
                this.isProjectRibbonEnabled = value;
                RaisePropertyChanged("IsProjectRibbonEnabled");
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public MainViewModel(IUnityContainer container)
            : base(container)
        {
            LoginViewModel = container.Resolve<LoginViewModel>();
            RegisterMessageHandler();

            InitilizeCommands();
            ShowLogin();
        }

        /// <summary>
        /// Initilizes the commands.
        /// </summary>
        private void InitilizeCommands()
        {
            SaveRibbonCommand = new RelayCommand(SaveRibbonCommandHandler);
            AddProjectCommand = new RelayCommand(AddProjectCommandHandler);
            ManageProjectCommand = new RelayCommand(ManageProjectCommandHandler);
            ShowAllProjectsCommand = new RelayCommand(ShowAllProjectsCommandHanlder);

            BulkTimeSheetAddCommand = new RelayCommand(BulkTimeSheetAddCommandHandler);
            ShowTimeSheetCommand = new RelayCommand(ShowTimeSheetCommandHandler);

            ShowUsersCommand = new RelayCommand(ShowUsersCommandHandler);
            AddUserCommand = new RelayCommand(AddUserCommandHandler);
        }

        /// <summary>
        /// Adds the user command handler.
        /// </summary>
        private void AddUserCommandHandler()
        {

        }

        /// <summary>
        /// Shows the users command handler.
        /// </summary>
        private void ShowUsersCommandHandler()
        {
            var usersViewModel = Unity.Resolve<UserViewModel>();
            Messenger.Default.Send(new GoToViewModelMessage { ViewModel = usersViewModel });
            Messenger.Default.Send(RibbonConstants.ShowUsers);
            Messenger.Default.Send(new RibbonVisibilityMessage { ItemName = "Users", IsEnabled = true });

        }

        /// <summary>
        /// Shows the time sheet command handler.
        /// </summary>
        private void ShowTimeSheetCommandHandler()
        {
            if (App.CurrentUser != null)
            {
                var timesheetViewModel = Unity.Resolve<TimeSheetViewModel>();
                timesheetViewModel.CurrentUser = App.CurrentUser;

                Messenger.Default.Send(new RibbonVisibilityMessage { ItemName = "TimeSheet", IsEnabled = true });
                Messenger.Default.Send(new GoToViewModelMessage { ViewModel = timesheetViewModel });
            }
        }

        /// <summary>
        /// Shows all projects command hanlder.
        /// </summary>
        private void ShowAllProjectsCommandHanlder()
        {
            var projectViewModel = Unity.Resolve<ProjectViewModel>();
            Messenger.Default.Send(new GoToViewModelMessage { ViewModel = projectViewModel });
            Messenger.Default.Send(RibbonConstants.AddProject);
            Messenger.Default.Send(new RibbonVisibilityMessage { ItemName = "Project", IsEnabled = true });

        }

        /// <summary>
        /// Manages the project command handler.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void ManageProjectCommandHandler()
        {
            var projectViewModel = Unity.Resolve<ProjectViewModel>();
            Messenger.Default.Send(new GoToViewModelMessage { ViewModel = projectViewModel });
            Messenger.Default.Send(RibbonConstants.AddProject);
        }

        /// <summary>
        /// Adds the project command handler.
        /// </summary>
        private void AddProjectCommandHandler()
        {
            Messenger.Default.Send(Constants.RibbonConstants.AddProjectItem);
        }

        /// <summary>
        /// Bulks the time sheet add command handler.
        /// </summary>
        private void BulkTimeSheetAddCommandHandler()
        {
            Messenger.Default.Send(Constants.RibbonConstants.AddBulkRibbonCommand);
        }

        /// <summary>
        /// Saves the ribbon command handler.
        /// </summary>
        private void SaveRibbonCommandHandler()
        {
            Messenger.Default.Send(Constants.RibbonConstants.SaveRibbonCommand);
        }

        /// <summary>
        /// Registers the message handler.
        /// </summary>
        private void RegisterMessageHandler()
        {
            Messenger.Default.Register<GoToViewModelMessage>(this, OnScreenSwitchMessage);
            Messenger.Default.Register<RibbonVisibilityMessage>(this, OnRibbonButtonStatusChangedMessage);
            //Messenger.Default.Register<string>(this, OnMessageReceived);
        }

        //private void OnMessageReceived(string message)
        //{
        //    switch (message)
        //    {
        //        case RibbonConstants.AddBulkRibbonCommand:
        //            ();
        //            break;
        //    }
        //}

        /// <summary>
        /// Called when [ribbon button status changed message].
        /// </summary>
        /// <param name="message">The message.</param>
        private void OnRibbonButtonStatusChangedMessage(RibbonVisibilityMessage message)
        {
            switch (message.ItemName)
            {
                case "TimeSheet":
                    IsTimeSheetEnabled = message.IsEnabled;
                    break;

                case "Project":
                    IsProjectRibbonEnabled = message.IsEnabled;
                    break;
            }
        }

        /// <summary>
        /// Called when [screen switch message].
        /// </summary>
        /// <param name="message">The message.</param>
        private void OnScreenSwitchMessage(GoToViewModelMessage message)
        {
            if (message.ViewModel != null)
            {
                Region = message.ViewModel.View;
            }
        }

        /// <summary>
        /// Shows the login.
        /// </summary>
        private void ShowLogin()
        {
            Messenger.Default.Send(new GoToViewModelMessage { ViewModel = LoginViewModel });
        }
    }

}