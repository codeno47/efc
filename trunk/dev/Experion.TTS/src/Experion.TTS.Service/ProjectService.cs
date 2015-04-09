using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experion.TTS.Service
{
    using EFC.Common.Service;

    using Experion.TTS.Service.Application;
    using Experion.TTS.Service.Model;

    using Microsoft.Practices.Unity;

    public class ProjectService : BusinessService
    {

        /// <summary>
        /// Gets or sets as project service.
        /// </summary>
        /// <value>
        /// As project service.
        /// </value>
        [Dependency]
        public ASProjectService AsProjectService { get; set; }

        /// <summary>
        /// Gets or sets as project role service.
        /// </summary>
        /// <value>
        /// As project role service.
        /// </value>
        [Dependency]
        public ASProjectRoleService AsProjectRoleService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectService" /> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        public ProjectService(IUnityContainer unity)
            : base(unity)
        {
        }

        /// <summary>
        /// Gets all active projects.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Project> GetAllActiveProjects()
        {
            return AsProjectService.GetAllProjects().ToList();
        }

        /// <summary>
        /// Removes the project member.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        public bool RemoveProjectMember(int userId, int projectId)
        {
            return AsProjectService.RemoveProjectMember(userId, projectId);
        }
        public override int Save()
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Role> GetAllRoles()
        {
            return AsProjectRoleService.GetAllRoles();
        }


        /// <summary>
        /// Gets all project status.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProjectStatu> GetAllProjectStatus()
        {
            return AsProjectService.GetAllProjectStatus();
        }

        /// <summary>
        /// Gets all non members.
        /// </summary>
        /// <param name="projectId">The project identifier.</param>
        /// <returns></returns>
        public IEnumerable<USER_DEFN> GetAllNonMembers(int projectId)
        {
            return AsProjectService.GetAllNonMembers(projectId);
        }

        /// <summary>
        /// Adds the project member.
        /// </summary>
        /// <param name="projectMember">The project member.</param>
        /// <returns></returns>
        public ProjectMember AddProjectMember(ProjectMember projectMember)
        {
            return AsProjectService.AddProjectMember(projectMember);
        }

        /// <summary>
        /// Adds the project.
        /// </summary>
        /// <param name="project">The project.</param>
        public Project AddProject(Project project)
        {
            return AsProjectService.AddProject(project);
        }
    }
}
