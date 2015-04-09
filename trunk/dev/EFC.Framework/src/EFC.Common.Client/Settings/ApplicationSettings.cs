// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ApplicationSettings.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ApplicationSettings.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System.Configuration;

namespace EFC.Client.Common.Settings
{
    /// <summary>
    /// ApplicationSettings.
    /// </summary>
    public static class ApplicationSettings
    {
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <returns>Connection string.</returns>
        public static string GetConnectionString()
        {
            string connectString;
            if (!IsTestMode())
            {
                connectString = ConfigurationManager.ConnectionStrings["homesaverEntities"].ToString();
            }
            else
            {
                connectString = ConfigurationManager.ConnectionStrings["homesaverEntitiesTest"].ToString();
            }
            return connectString;
        }

        /// <summary>
        /// Gets the connection string for v2 model.
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionStringForV2Model()
        {
            string connectString;
            if (!IsTestMode())
            {
                connectString = ConfigurationManager.ConnectionStrings["homesaverV2"].ToString();
            }
            else
            {
                connectString = ConfigurationManager.ConnectionStrings["homesaverV2Test"].ToString();
            }
            return connectString;
        }

        /// <summary>
        /// Gets the connection string for adapter.
        /// </summary>
        /// <returns>Connection string.</returns>
        public static string GetConnectionStringForAdapter()
        {
             string connectString;
             if (!IsTestMode())
             {
                 connectString = ConfigurationManager.ConnectionStrings["homesaverConnectionString"].ToString();
             }
             else
             {
                 connectString = ConfigurationManager.ConnectionStrings["homesaverConnectionStringTest"].ToString();
             }

            return connectString;
        }

        /// <summary>
        /// Gets the connection string for CRM model.
        /// </summary>
        /// <returns>Connection string.</returns>
        public static string GetConnectionStringForCrmModel()
        {
            string connectString;
            if (!IsTestMode())
            {
                connectString = ConfigurationManager.ConnectionStrings["crmCoreEntities"].ToString();
            }
            else
            {
                connectString = ConfigurationManager.ConnectionStrings["crmCoreEntitiesTest"].ToString();
            }

            return connectString;
        }

        /// <summary>
        /// Gets the quick book company file.
        /// </summary>
        /// <returns>Company file name.</returns>
        public static string GetQuickBookCompanyFile()
        {
            var connectString = ConfigurationManager.ConnectionStrings["quickbook"].ToString();
            return connectString;
        }

        /// <summary>
        /// Determines whether [is test mode].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is test mode]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsTestMode()
        {
            var data = ConfigurationManager.ConnectionStrings["TestMode"].ToString();
            if (!string.IsNullOrEmpty(data) && string.CompareOrdinal("true", data) == 0)
            {
                return true;
            }

            return false;
        }
    }
}