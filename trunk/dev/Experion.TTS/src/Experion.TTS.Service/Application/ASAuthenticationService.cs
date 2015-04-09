using System.Data.Entity;
using System.Linq;
using EFC.Common.Service;
using EFC.Components.Data;
using Experion.TTS.Service.Data;
using Experion.TTS.Service.Model;
using Microsoft.Practices.Unity;

namespace Experion.TTS.Service.Application
{
    /// <summary>
    /// Application Service
    /// </summary>
    public class ASAuthenticationService : ApplicationService<Entities>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ASAuthenticationService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        public ASAuthenticationService(IUnityContainer unity, IRepositoryContext context)
            : base(unity, context)
        {
        }

        /// <summary>
        /// Gets the user repository.
        /// </summary>
        /// <value>
        /// The user repository.
        /// </value>
        private IRepository<USER_DEFN, int> UserRepository
        {
            get { return DataContext.GetRepository<USER_DEFN, int>(); }
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public USER_DEFN GetUser(string userName, string password)
        {
            var roleSpecification = new Specification<USER_DEFN>(r => r.UserName.Equals(userName) && r.IsActive);
            return UserRepository.GetBySpecification(roleSpecification).FirstOrDefault();
        }
    }
}
