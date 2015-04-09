using EFC.Common.Service;
using Experion.TTS.Service.Application;
using Microsoft.Practices.Unity;
using System;

namespace Experion.TTS.Service
{
    using Experion.TTS.Service.Model;
    using System.Collections.Generic;

    public class AuthenticationService : BusinessService
    {
        /// <summary>
        /// Gets or sets the asynchronous authentication service.
        /// </summary>
        /// <value>
        /// The asynchronous authentication service.
        /// </value>
        [Dependency]
        public ASAuthenticationService ASAuthenticationService { get; set; }

        /// <summary>
        /// Gets or sets as user service.
        /// </summary>
        /// <value>
        /// As user service.
        /// </value>
        [Dependency]
        public ASUserService AsUserService { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        public AuthenticationService(IUnityContainer unity)
            : base(unity)
        {
        }

        /// <summary>
        /// Determines whether [is valid user] [the specified username].
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public USER_DEFN IsValidUser(string username, string password)
        {
            return ASAuthenticationService.GetUser(username, password);
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<USER_DEFN> GetAllUsers()
        {
            return AsUserService.GetAllUsers();
        }

        public void IsAdminUser(USER_DEFN user)
        {

        }
        public override int Save()
        {
            throw new NotImplementedException();
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
