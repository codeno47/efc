using Microsoft.Practices.Unity;

namespace Experion.TTS.Service.Application
{
    using EFC.Common.Service;
    using EFC.Components.Data;

    using Experion.TTS.Service.Data;
    using Experion.TTS.Service.Model;
    using System.Collections.Generic;

    /// <summary>
    /// Application Service
    /// </summary>
    public class ASUserService : ApplicationService<Entities>
    {
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
        /// Initializes a new instance of the <see cref="ASUserService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        public ASUserService(IUnityContainer unity, IRepositoryContext context)
            : base(unity, context)
        {
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<USER_DEFN> GetAllUsers()
        {
            return UserRepository.GetAll();
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool AddUser(string userName, string password)
        {
            var context = DataContext as TtsRepositoryContext;
            context.DbContext.InsertUser(userName, password);

            return true;
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool ChangePassword(string userName, string password)
        {
            var context = DataContext as TtsRepositoryContext;
            context.DbContext.ChangeUserPassword(userName, password);

            return true;
        }
    }
}
