// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="ConnectionStringKeys.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="ConnectionStringKeys.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

namespace EFC.Components.Enum
{
    /// <summary>
    /// Connection string key names.
    /// 
    /// </summary>
    public static class ConnectionStringKeys
    {
        /// <summary>
        /// Key name of data source to be used in DbConnectionStringBuilder.
        /// 
        /// </summary>
        public const string DataSource = "Data Source";
        /// <summary>
        /// Key name of initial catalog to be used in DbConnectionStringBuilder.
        /// 
        /// </summary>
        public const string Catalog = "Initial Catalog";
        /// <summary>
        /// Key name of user id to be used in DbConnectionStringBuilder.
        /// 
        /// </summary>
        public const string UserId = "User ID";
        /// <summary>
        /// Key name of password to be used in DbConnectionStringBuilder.
        /// 
        /// </summary>
        public const string Password = "Password";
    }
}
