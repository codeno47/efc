using System;

namespace Experion.TTS.Service
{
    using System.Collections;
    using System.Collections.Generic;
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    using System.DirectoryServices.Protocols;
    using System.Linq;
    using System.Net;
    using System.Security.Permissions;

    using EFC.Common.Service;

    using Microsoft.Practices.Unity;

    using SearchScope = System.DirectoryServices.SearchScope;

    /// <summary>
    /// ADService.
    /// </summary>
    public class ADService : BusinessService
    {
        public ADService(IUnityContainer unity)
            : base(unity)
        {
        }

        /// <summary>
        /// Authenticates the specified user name.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool Authenticate(string userName, string password)
        {
            bool authentic = false;
            try
            {
                var domain = Unity.Resolve<string>("ADServer");
                var entry = new DirectoryEntry("LDAP://" + domain, userName, password);
                //GetUserMemberships(domain, userName, password);
                object nativeObject = entry.NativeObject;
                authentic = true;
            }
            catch (DirectoryServicesCOMException exception)
            {

            }

            return authentic;
        }

        /// <summary>
        /// Checks the user group.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="domainName">Name of the domain.</param>
        /// <returns></returns>
        [SecurityPermissionAttribute(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
        [DirectoryServicesPermissionAttribute(SecurityAction.InheritanceDemand, Unrestricted = true)]
        [DirectoryServicesPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        public bool CheckUserGroup(string username, string password, string groupName, string domainName)
        {
            var entry = new DirectoryEntry("LDAP://" + domainName, username, password);

            var mySearcher = new DirectorySearcher(entry);
            mySearcher.Filter = "(&(objectClass=user)(|(cn=" + username + ")(sAMAccountName=" + username + ")))";
            SearchResult result = mySearcher.FindOne();

            foreach (string groupPath in result.Properties["memberOf"])
            {
                char[] arr = { '=', ',' };
                var userGroup = groupPath.Split(arr);
                if (userGroup.Any(item => item.Equals(groupName)))
                {
                    return true;
                }

            }
            return false;
        }


        /// <summary>
        /// Determines whether [is admin user] [the specified user name].
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public bool IsAdminUser(string userName, string password)
        {
            var domain = Unity.Resolve<string>("ADServer");
            var group = Unity.Resolve<string>("AdminGroup");

            return CheckUserGroup(userName, password, group, domain);
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
