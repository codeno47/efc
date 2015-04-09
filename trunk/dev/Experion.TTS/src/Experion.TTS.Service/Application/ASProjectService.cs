using System.Data.Entity;
using System.Linq;
using EFC.Common.Service;
using EFC.Components.Data;
using Experion.TTS.Service.Model;
using Microsoft.Practices.Unity;

namespace Experion.TTS.Service.Application
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Application Service
    /// </summary>
    public class ASProjectService : ApplicationService<Entities>
    {
        /// <summary>
        /// Gets the project repository.
        /// </summary>
        /// <value>
        /// The project repository.
        /// </value>
        private IRepository<Project, int> ProjectRepository
        {
            get { return DataContext.GetRepository<Project, int>(); }
        }

        /// <summary>
        /// Gets the project status repository.
        /// </summary>
        /// <value>
        /// The project status repository.
        /// </value>
        private IRepository<ProjectStatu, int> ProjectStatusRepository
        {
            get { return DataContext.GetRepository<ProjectStatu, int>(); }
        }

        /// <summary>
        /// Gets the user repository repository.
        /// </summary>
        /// <value>
        /// The user repository repository.
        /// </value>
        private IRepository<USER_DEFN, int> UserRepository
        {
            get { return DataContext.GetRepository<USER_DEFN, int>(); }
        }

        /// <summary>
        /// Gets or sets as project member service.
        /// </summary>
        /// <value>
        /// As project member service.
        /// </value>
        [Dependency]
        public ASProjectMember AsProjectMemberService { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="ASProjectService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        public ASProjectService(IUnityContainer unity, IRepositoryContext context)
            : base(unity, context)
        {
        }

        /// <summary>
        /// Gets all project status.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectStatu> GetAllProjectStatus()
        {
            return ProjectStatusRepository.GetAll();
        }

        /// <summary>
        /// Gets the project by unique identifier.
        /// </summary>
        /// <param name="projectId">The project unique identifier.</param>
        /// <returns></returns>
        public Project GetProjectById(int projectId)
        {
            var roleSpecification = new Specification<Project>(r => r.ProjectId.Equals(projectId));
            return ProjectRepository.GetBySpecification(roleSpecification).FirstOrDefault();
        }

        /// <summary>
        /// Gets all projects.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> GetAllProjects()
        {
            var specification = new Specification<Project>(r => r.ProjectStatus.Equals(1));
            return ProjectRepository.GetBySpecification(specification);
        }


        /// <summary>
        /// Gets all project for user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public IEnumerable<Project> GetAllProjectForUser(int userId)
        {
            var user = UserRepository.GetById(userId);

            var projects = new List<Project>();

            if (user != null)
            {
                projects.AddRange(user.ProjectMembers.Select(member => member.Project));
            }

            return projects;
        }
        /// <summary>
        /// Adds the project.
        /// </summary>
        /// <param name="project">The project.</param>
        /// <returns>AddProject.</returns>
        public Project AddProject(Project project)
        {
            var projectSaved = ProjectRepository.Add(project);
            this.Save();

            return projectSaved;
        }

        /// <summary>
        /// Removes the project member.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        public bool RemoveProjectMember(int userId, int projectId)
        {
            var project = ProjectRepository.GetById(projectId);

            var member = project.ProjectMembers.FirstOrDefault(x => x.UserId.Equals(userId));
            return member != null && this.AsProjectMemberService.RemoveMember(member.Id);
        }

        /// <summary>
        /// Adds the project member.
        /// </summary>
        /// <param name="projectMember">The project member.</param>
        /// <returns></returns>
        public ProjectMember AddProjectMember(ProjectMember projectMember)
        {
            var project = ProjectRepository.GetById(projectMember.ProjectId);

            var member = project.ProjectMembers.FirstOrDefault(x => x.UserId.Equals(projectMember.UserId));
            if (member == null)
            {
                return this.AsProjectMemberService.AddMember(projectMember);
            }

            return null;
        }


        //public IEnumerable<USER_DEFN> GetAllProjectMembers(int projectId)
        //{
        //    var project = ProjectRepository.GetById(projectId);

        //    var specification = new Specification<ProjectMember>(r => r.ProjectId.Equals(projectId));
        //    var projectMemebers = ProjectMemberRepository.GetBySpecification(specification);

        //    return null;
        //}

        /// <summary>
        /// Gets all non members.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        public IEnumerable<USER_DEFN> GetAllNonMembers(int projectId)
        {
            var project = ProjectRepository.GetById(projectId);
            if (project == null)
            {
                return null;
            }
            var users = UserRepository.GetAll().ToList();

            var membersAlreadyInProject = project.ProjectMembers.Select(memeber => memeber.USER_DEFN).ToList();

            return users.Except(membersAlreadyInProject);
        }
    }
}
