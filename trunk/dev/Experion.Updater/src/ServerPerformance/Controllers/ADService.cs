using System;

namespace Experion.TTS.Service
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    using System.Dynamic;
    using System.IO;
    //using System.DirectoryServices.Protocols;
    using System.Linq;
    using System.Net;
    using System.Security.Permissions;
    //using EFC.Common.Service;


    using SearchScope = System.DirectoryServices.SearchScope;

    public class ADService 
    {

        public ADService()
        {
        }
        //public ADService(IUnityContainer unity)
        //    : base(unity)
        //{
        //}

        public dynamic Authenticate(string userName, string password,StreamWriter writer)
        {


           

            writer.Write("Started" + DateTime.Now.ToString() + Environment.NewLine);

            dynamic testoutput=new ExpandoObject();

            testoutput.status = false;
            testoutput.failurereason = "";
            testoutput.state = 0;

           
            try
            {
                DirectoryEntry entry = new DirectoryEntry(ConfigurationManager.AppSettings["LDAP_Path"].ToString(),
                    userName, password, AuthenticationTypes.Secure);
                try
                {

                    writer.WriteLine("Checking Credentials");
                    object nativeObject = entry.NativeObject;
                    writer.WriteLine("Valid");
                    testoutput.status = true;
                    testoutput.failurereason = "";
                    testoutput.state = 0;
                }
                catch (Exception exception)
                {
                    writer.WriteLine(exception.Message);
                  
                    testoutput.status = false;
                    testoutput.failurereason = exception.Message;
                    testoutput.state = 1;
                }

                finally
                {
                    writer.WriteLine("Finished");

                    writer.Close();

                }

                //GetUserMemberships(domain, userName, password);

            }
            catch (DirectoryServicesCOMException exception)
            {
                writer.WriteLine(exception.Message); testoutput.status = false;
                testoutput.failurereason = exception.Message;
                testoutput.state = 2;

            }
            finally 
            {
               
                    writer.Close();
                
               
            }



            return testoutput;
        }

        [SecurityPermissionAttribute(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode)]
        [DirectoryServicesPermissionAttribute(SecurityAction.InheritanceDemand, Unrestricted = true)]
        [DirectoryServicesPermissionAttribute(SecurityAction.LinkDemand, Unrestricted = true)]
        private void GetUserMemberships(string domain, string username, string password)
        {

            var _connection = new PrincipalContext(ContextType.Domain, domain, "DC=domain,DC=com", ContextOptions.SimpleBind, username, password);
            var _userData = UserPrincipal.FindByIdentity(_connection, username);

            DirectoryEntry de = (DirectoryEntry)_userData.GetUnderlyingObject();
            object obGroups = de.Invoke("Groups");


            // "company" is the domain we would like to search in
            PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain, username, password);

            // get the user of that domain by his username, within the context
            UserPrincipal up = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, username);

            // fetch the group list
            PrincipalSearchResult<Principal> groups = up.GetAuthorizationGroups();
            GroupPrincipal[] filteredGroups = (from p in groups
                                               where p.ContextType == ContextType.Domain
                                               && p.Guid != null
                                               && p is GroupPrincipal
                                               && ((GroupPrincipal)p).GroupScope == GroupScope.Universal
                                               select p as GroupPrincipal).ToArray();

        }



       
    }
}
