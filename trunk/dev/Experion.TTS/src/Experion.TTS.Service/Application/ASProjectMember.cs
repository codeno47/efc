using Microsoft.Practices.Unity;

namespace Experion.TTS.Service.Application
{
    using EFC.Common.Service;
    using EFC.Components.Data;

    using Experion.TTS.Service.Model;

    /// <summary>
    /// Business Service
    /// </summary>
    public class ASProjectMember : ApplicationService<Entities>
    {

        private IRepository<ProjectMember, int> ProjectMemberRepository
        {
            get { return DataContext.GetRepository<ProjectMember, int>(); }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ASProjectMember" /> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        public ASProjectMember(IUnityContainer unity, IRepositoryContext context)
            : base(unity, context)
        {
        }

        /// <summary>
        /// Removes the member.
        /// </summary>
        /// <param name="membershipId">The membership identifier.</param>
        public bool RemoveMember(int membershipId)
        {
            var member = ProjectMemberRepository.GetById(membershipId);
            ProjectMemberRepository.Delete(member);
            if (this.Save() > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds the member.
        /// </summary>
        /// <param name="projectMember">The project member.</param>
        /// <returns></returns>
        public ProjectMember AddMember(ProjectMember projectMember)
        {
            //var member = ProjectMemberRepository.GetById(projectMember.);
            var added = ProjectMemberRepository.Add(projectMember);
            if (this.Save() > 0)
            {
                return added;
            }

            return null;
        }
    }
}
