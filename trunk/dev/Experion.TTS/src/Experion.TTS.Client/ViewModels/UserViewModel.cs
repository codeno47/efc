// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="UserViewModel.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="UserViewModel.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using Microsoft.Practices.Unity;

namespace Experion.TTS.Client.ViewModels
{
    using EFC.Client.Common.Base;
    using Experion.TTS.Client.Constants;
    using Experion.TTS.Client.Extensions;
    using Experion.TTS.Client.Model;
    using Experion.TTS.Client.Models;
    using Experion.TTS.Service;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Messaging;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    /// <summary>
    /// UserViewModel.
    /// </summary>

    public class UserViewModel : ViewModel
    {
        /// <summary>
        /// The show all users ribbon item
        /// </summary>
        private bool showAllUsersRibbonItem;

        /// <summary>
        /// Gets or sets the selected item command.
        /// </summary>
        /// <value>
        /// The selected item command.
        /// </value>
        public ICommand SelectedItemCommand { get; set; }

        /// <summary>
        /// Gets or sets the clear search command.
        /// </summary>
        /// <value>
        /// The clear search command.
        /// </value>
        public ICommand ClearSearchCommand { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [show add project].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show add project]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowAllUsersRibbonItem
        {
            get
            {
                return this.showAllUsersRibbonItem;
            }
            set
            {
                this.showAllUsersRibbonItem = value;
                RaisePropertyChanged("ShowAllUsersRibbonItem");
            }
        }

        private ObservableCollection<ProjectMemberModel> users;
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public ObservableCollection<ProjectMemberModel> Users
        {
            get
            {
                return this.users;
            }
            set
            {
                this.users = value;
                RaisePropertyChanged("Users");
            }
        }

        private bool isBusy;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is busy; otherwise, <c>false</c>.
        /// </value>
        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }
            set
            {
                this.isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }

        /// <summary>
        /// The selected member
        /// </summary>
        private ProjectMemberModel selectedMember;
        /// <summary>
        /// Gets or sets the selected member.
        /// </summary>
        /// <value>
        /// The selected member.
        /// </value>
        public ProjectMemberModel SelectedMember
        {
            get
            {
                return this.selectedMember;
            }
            set
            {
                this.selectedMember = value;
                SelectedItemCommand.Execute(selectedMember);
                RaisePropertyChanged("SelectedMember");
            }
        }

        /// <summary>
        /// The project models
        /// </summary>
        private ObservableCollection<ProjectModel> projectModels;

        /// <summary>
        /// Gets or sets the project models.
        /// </summary>
        /// <value>
        /// The project models.
        /// </value>
        public ObservableCollection<ProjectModel> ProjectModels
        {
            get
            {
                return this.projectModels;
            }
            set
            {
                this.projectModels = value;
                RaisePropertyChanged("ProjectModels");
            }
        }

        /// <summary>
        /// The search text
        /// </summary>
        private string searchText;
        /// <summary>
        /// Gets or sets the search text.
        /// </summary>
        /// <value>
        /// The search text.
        /// </value>
        public string SearchText
        {
            get
            {
                return this.searchText;
            }
            set
            {
                this.searchText = value;

                FilterUserData(searchText);

                RaisePropertyChanged("SearchText");
            }
        }

        /// <summary>
        /// Gets or sets the authentication service.
        /// </summary>
        /// <value>
        /// The authentication service.
        /// </value>

        public AuthenticationService AuthenticationService { get; set; }

        /// <summary>
        /// Initializes a new instance of the UserViewModel class.
        /// </summary>
        public UserViewModel(IUnityContainer container)
            : base(container)
        {
            Initilize();
            InitilizeCollections();
        }

        /// <summary>
        /// Initilizes this instance.
        /// </summary>
        private void Initilize()
        {
            Messenger.Default.Unregister<string>(this, this.OnMessageReceived);
            Messenger.Default.Register<string>(this, this.OnMessageReceived);

            this.SelectedItemCommand = new RelayCommand<ProjectMemberModel>(this.OnSelectionItemChanged);

            ClearSearchCommand = new RelayCommand(ClearSearchCommandHandler);
        }

        /// <summary>
        /// Clears the search command handler.
        /// </summary>
        private void ClearSearchCommandHandler()
        {
            SearchText = string.Empty;
        }

        /// <summary>
        /// Filters the user data.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        private void FilterUserData(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                InitilizeCollections();

                Users = new ObservableCollection<ProjectMemberModel>(Users.Where(x => x.Name.StartsWith(searchText, StringComparison.OrdinalIgnoreCase)));

            }
            else
            {
                InitilizeCollections();
            }
        }

        /// <summary>
        /// Called when [selection item changed].
        /// </summary>
        /// <param name="projectMember">The project member.</param>
        private async void OnSelectionItemChanged(ProjectMemberModel projectMember)
        {
            try
            {
                var timesheetService = Unity.Resolve<TimeSheetService>();
                IsBusy = true;

                var projects = (await timesheetService.GetAllProjects(projectMember.UserId)).ToMemberModels();

                ProjectModels = new ObservableCollection<ProjectModel>(projects);
            }
            finally
            {
                IsBusy = false;
            }

        }

        /// <summary>
        /// Called when [message received].
        /// </summary>
        /// <param name="message">The message.</param>
        private void OnMessageReceived(string message)
        {
            switch (message)
            {
                case RibbonConstants.ShowUsers:
                    OnShowUsers();
                    break;

            }
        }

        /// <summary>
        /// Called when [show users].
        /// </summary>
        private void OnShowUsers()
        {

        }

        /// <summary>
        /// Initializes the collections.
        /// </summary>
        private void InitilizeCollections()
        {
            var authenticationService = Unity.Resolve<AuthenticationService>();

            var userDefns = authenticationService.GetAllUsers().OrderBy(x => x.UserName).ToList();
            if (userDefns.Any())
            {
                Users = new ObservableCollection<ProjectMemberModel>(userDefns.ToMemberModels());
            }
        }
    }
}