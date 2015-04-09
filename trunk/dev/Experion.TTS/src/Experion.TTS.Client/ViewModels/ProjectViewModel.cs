// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="TimeSheetViewModel.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="TimeSheetViewModel.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using EFC.Client.Common.Base;

using Experion.TTS.Service;
using Experion.TTS.Service.Model;
using Microsoft.Practices.Unity;
namespace Experion.TTS.Client.ViewModels
{
    using Experion.TTS.Client.Constants;
    using Experion.TTS.Client.Extensions;
    using Experion.TTS.Client.Model;
    using Experion.TTS.Client.Models;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Messaging;
    using Microsoft.Practices.ObjectBuilder2;
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;

    public class ProjectViewModel : ViewModel
    {
        #region Members

        private string errorMessage;

        /// <summary>
        /// The selected project status
        /// </summary>
        private ProjectStatusModel selectedProjectStatus;

        /// <summary>
        /// The new project
        /// </summary>
        private ProjectModel newProject;
        /// <summary>
        /// The selected project
        /// </summary>
        private Project selectedProject;

        /// <summary>
        /// Gets or sets the project roles.
        /// </summary>
        /// <value>
        /// The project roles.
        /// </value>
        public ObservableCollection<Role> ProjectRoles { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public ObservableCollection<USER_DEFN> Users { get; set; }

        /// <summary>
        /// Gets or sets the selected item command.
        /// </summary>
        /// <value>
        /// The selected item command.
        /// </value>
        public ICommand SelectedItemCommand { get; set; }

        /// <summary>
        /// Gets or sets the project selected command.
        /// </summary>
        /// <value>
        /// The project selected command.
        /// </value>
        public ICommand ProjectSelectedCommand { get; set; }

        /// <summary>
        /// Gets or sets the add member command.
        /// </summary>
        /// <value>
        /// The add member command.
        /// </value>
        public ICommand AddMemberCommand { get; set; }

        /// <summary>
        /// Gets or sets the remove member command.
        /// </summary>
        /// <value>
        /// The remove member command.
        /// </value>
        public ICommand RemoveMemberCommand { get; set; }

        /// <summary>
        /// Gets or sets the popup cancel command.
        /// </summary>
        /// <value>
        /// The popup cancel command.
        /// </value>
        public ICommand PopupCancelCommand { get; set; }

        /// <summary>
        /// Gets or sets the popup ok command.
        /// </summary>
        /// <value>
        /// The popup ok command.
        /// </value>
        public ICommand PopupOkCommand { get; set; }

        /// <summary>
        /// Gets or sets the add project ok command.
        /// </summary>
        /// <value>
        /// The add project ok command.
        /// </value>
        public ICommand AddProjectOkCommand { get; set; }

        /// <summary>
        /// Gets or sets the add project cancel command.
        /// </summary>
        /// <value>
        /// The add project cancel command.
        /// </value>
        public ICommand AddProjectCancelCommand { get; set; }

        /// <summary>
        /// Gets or sets the project data.
        /// </summary>
        /// <value>
        /// The project data.
        /// </value>
        public ObservableCollection<Project> ProjectData { get; set; }

        /// <summary>
        /// Gets or sets the project members.
        /// </summary>
        /// <value>
        /// The project members.
        /// </value>
        public ObservableCollection<ProjectMemberModel> ProjectMembers { get; set; }

        /// <summary>
        /// Gets or sets the current project members.
        /// </summary>
        /// <value>
        /// The current project members.
        /// </value>
        public ObservableCollection<ProjectMemberModel> CurrentProjectMembers { get; set; }

        /// <summary>
        /// Gets or sets the project service.
        /// </summary>
        /// <value>
        /// The project service.
        /// </value>
        public ProjectService ProjectService { get; set; }


        /// <summary>
        /// The show add member
        /// </summary>
        private bool showAddMember;

        /// <summary>
        /// Gets or sets a value indicating whether [show add member].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show add member]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowAddMember
        {
            get
            {
                return this.showAddProject;
            }
            set
            {
                this.showAddProject = value;
                RaisePropertyChanged("ShowAddMember");
            }
        }

        private bool showAddProject;

        /// <summary>
        /// Gets or sets a value indicating whether [show add project].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show add project]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowAddProject
        {
            get
            {
                return this.showAddProject;
            }
            set
            {
                this.showAddProject = value;
                RaisePropertyChanged("showAllUsersRibbonItem");
            }
        }

        /// <summary>
        /// Gets or sets the selected project.
        /// </summary>
        /// <value>
        /// The selected project.
        /// </value>
        public Project SelectedProject
        {
            get
            {
                return this.selectedProject;
            }
            set
            {
                if (value != null)
                {
                    this.SelectedItemCommand.Execute(value);

                }
                this.selectedProject = value;

                RaisePropertyChanged("SelectedProject");
            }
        }

        /// <summary>
        /// Gets or sets the selected member.
        /// </summary>
        /// <value>
        /// The selected member.
        /// </value>
        public ProjectMemberModel SelectedMember { get; set; }

        /// <summary>
        /// Gets or sets the project status.
        /// </summary>
        /// <value>
        /// The project status.
        /// </value>
        public ObservableCollection<ProjectStatusModel> ProjectStatus { get; set; }

        /// <summary>
        /// Gets or sets the selected role.
        /// </summary>
        /// <value>
        /// The selected role.
        /// </value>
        public Role SelectedRole { get; set; }

        /// <summary>
        /// Gets or sets the new project.
        /// </summary>
        /// <value>
        /// The new project.
        /// </value>
        public ProjectModel NewProject
        {
            get
            {
                return this.newProject;
            }
            set
            {
                this.newProject = value;
                RaisePropertyChanged("NewProject");
            }
        }

        /// <summary>
        /// The selected project status
        /// </summary>
        public ProjectStatusModel SelectedProjectStatus
        {
            get
            {
                return this.selectedProjectStatus;
            }
            set
            {
                this.selectedProjectStatus = value;

                if (selectedProjectStatus != null)
                {
                    NewProject.ProjectId = selectedProjectStatus.ProjectStatusId;
                }

                RaisePropertyChanged("SelectedProjectStatus");
            }
        }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }
            set
            {
                this.errorMessage = value;
                RaisePropertyChanged("ErrorMessage");
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectViewModel"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ProjectViewModel(IUnityContainer container)
            : base(container)
        {
            this.Initilize();
        }

        /// <summary>
        /// Initilizes this instance.
        /// </summary>
        private void Initilize()
        {
            this.ProjectData = new ObservableCollection<Project>();
            this.CurrentProjectMembers = new ObservableCollection<ProjectMemberModel>();
            ProjectStatus = new ObservableCollection<ProjectStatusModel>();

            NewProject = new ProjectModel();

            this.InitilizeCollection();

            this.SelectedItemCommand = new RelayCommand<Project>(this.OnSelectionItemChanged);
            this.RemoveMemberCommand = new RelayCommand<ProjectMemberModel>(this.OnRemoveProjectMember);
            //ProjectSelectedCommand = new RelayCommand<Project>(OnProjectSelectionChanged);

            this.AddMemberCommand = new RelayCommand(this.OnAddMemberCommand);
            this.PopupCancelCommand = new RelayCommand(this.PopupCancelCommandHandler);
            this.PopupOkCommand = new RelayCommand(this.PopupOkCommandHandler);

            this.AddProjectOkCommand = new RelayCommand(this.AddProjectOkCommandHandler);
            this.AddProjectCancelCommand = new RelayCommand(this.AddProjectCancelCommandHandler);

            Messenger.Default.Unregister<string>(this, this.OnMessageReceived);
            Messenger.Default.Register<string>(this, this.OnMessageReceived);

            this.PropertyChanged -= this.OnModelPropertyChanged;
            this.PropertyChanged += this.OnModelPropertyChanged;

            LoadProjectStatus();
        }

        /// <summary>
        /// Loads the project status.
        /// </summary>
        private void LoadProjectStatus()
        {
            var projectstus = ProjectService.GetAllProjectStatus();

            if (projectstus != null)
            {
                projectstus.ForEach(x => ProjectStatus.Add(x.ToProjectStatusModel()));
            }
        }

        /// <summary>
        /// Adds the project cancel command handler.
        /// </summary>
        private void AddProjectCancelCommandHandler()
        {
            ShowAddProject = false;
            //TODO: handle add project

        }

        /// <summary>
        /// Adds the project ok command handler.
        /// </summary>
        private void AddProjectOkCommandHandler()
        {
            var canProceed = false;

            if (NewProject == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(NewProject.Code))
            {
                ErrorMessage = "Project code cannot be null";
                return;
            }

            if (string.IsNullOrEmpty(this.NewProject.Description))
            {
                ErrorMessage = "Description code cannot be null";
                return;
            }

            if (NewProject.StartDate == null || NewProject.StartDate == DateTime.MinValue)
            {
                ErrorMessage = "Project Start date cannot be null";
                return;
            }

            if (this.SelectedProjectStatus == null)
            {
                ErrorMessage = "Project status cannot be null";
                return;
            }

            var project = NewProject.ToProjectEntity();

            project.ProjectStatus = SelectedProjectStatus.ProjectStatusId;

            var projectAdded = ProjectService.AddProject(project);

            if (projectAdded != null)
            {
                this.ProjectData.Add(projectAdded);
            }

            ErrorMessage = string.Empty;

            NewProject = new ProjectModel();

            ShowAddProject = false;

        }

        /// <summary>
        /// Called when [message received].
        /// </summary>
        /// <param name="message">The message.</param>
        private void OnMessageReceived(string message)
        {
            switch (message)
            {
                case RibbonConstants.AddProjectItem:
                    OnAddProjectItem();
                    break;

            }
        }

        /// <summary>
        /// Called when [add project item].
        /// </summary>
        private void OnAddProjectItem()
        {
            ShowAddProject = true;

        }

        /// <summary>
        /// Called when [model property changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("SelectedProject"))
            {
                LoadMemebersForProject(SelectedProject.Id);
            }
        }

        /// <summary>
        /// Loads the memebers for project.
        /// </summary>
        /// <param name="id">The identifier.</param>
        private void LoadMemebersForProject(int id)
        {
            var memebers = ProjectService.GetAllNonMembers(id);
            var result = memebers.ToMemberModels();
            CurrentProjectMembers.Clear();

            result.ForEach(x => CurrentProjectMembers.Add(x));
        }

        /// <summary>
        /// Popups the cancel command handler.
        /// </summary>
        private void PopupCancelCommandHandler()
        {
            ShowAddMember = false;
        }

        /// <summary>
        /// Popups the ok command handler.
        /// </summary>
        private void PopupOkCommandHandler()
        {
            ShowAddMember = false;

            var newMember = new ProjectMember
                            {
                                IsActive = true,
                                ProjectId = SelectedProject.Id,
                                UserId = SelectedMember.UserId,
                                RoleId = SelectedRole.RoleId,
                            };

            var addedmemeber = ProjectService.AddProjectMember(newMember);

            if (addedmemeber != null)
            {
                ProjectMembers.Add(addedmemeber.ToMemberModel());
            }
        }

        /// <summary>
        /// Called when [add member command].
        /// </summary>
        private void OnAddMemberCommand()
        {
            ShowAddMember = true;
        }

        /// <summary>
        /// Called when [remove project member].
        /// </summary>
        /// <param name="user">The user.</param>
        private void OnRemoveProjectMember(ProjectMemberModel user)
        {
            if (user == null)
            {
                return;
            }

            if (user.ProjectId < 1)
            {
                MessageBox.Show("Please select a project");
            }

            var message = string.Format(
                "Are you sure want to remove {0} from Project {1} ?",
                user.Name,
                SelectedProject.Description);

            if (MessageBox.Show(message, "Remove Member", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (ProjectService.RemoveProjectMember(user.UserId, user.ProjectId))
                {
                    ProjectMembers.Remove(user);
                }
            }
        }

        /// <summary>
        /// Called when [selection item changed].
        /// </summary>
        /// <param name="e">The e.</param>
        private void OnSelectionItemChanged(Project e)
        {
            ProjectMembers.Clear();
            var projectTeam = e.ProjectMembers.OrderBy(x => x.USER_DEFN.UserName);



            foreach (var member in projectTeam)
            {
                if (member.IsActive)
                {
                    var userModel = new ProjectMemberModel
                                    {
                                        Name = member.USER_DEFN.UserName,
                                        Role = member.Role.RoleName,
                                        UserId = member.UserId,
                                        ProjectId = member.ProjectId
                                    };

                    ProjectMembers.Add(userModel);
                }
            }
        }


        /// <summary>
        /// Initilizes the collection.
        /// </summary>
        private void InitilizeCollection()
        {
            ProjectService = Unity.Resolve<ProjectService>();

            var projects = ProjectService.GetAllActiveProjects().OrderBy(x => x.Code).ToList();
            ProjectData = new ObservableCollection<Project>(projects);


            ProjectMembers = new ObservableCollection<ProjectMemberModel>();

            var roles = ProjectService.GetAllRoles().OrderBy(x => x.RoleName);
            ProjectRoles = new ObservableCollection<Role>(roles);

            ProjectData.CollectionChanged += OnProjectCollectionChanged;

        }

        /// <summary>
        /// Called when [project collection changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        private void OnProjectCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {


        }

    }
}
