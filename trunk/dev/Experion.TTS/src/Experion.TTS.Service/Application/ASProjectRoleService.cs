using EFC.Common.Service;
using Experion.TTS.Service.Model;

namespace Experion.TTS.Service.Application
{
    using System.Collections.Generic;

    using EFC.Components.Data;

    using Microsoft.Practices.Unity;

    public class ASProjectRoleService : ApplicationService<Entities>
    {
        /// <summary>
        /// Gets the role repository.
        /// </summary>
        /// <value>
        /// The role repository.
        /// </value>
        private IRepository<Role, int> RoleRepository
        {
            get { return DataContext.GetRepository<Role, int>(); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ASProjectRoleService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        public ASProjectRoleService(IUnityContainer unity, IRepositoryContext context)
            : base(unity, context)
        {
        }

        /// <summary>
        /// Gets all roles.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Role> GetAllRoles()
        {
            return RoleRepository.GetAll();
        }
    }
}
