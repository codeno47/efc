// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ConnectionStringKeys.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ConnectionStringKeys.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Service.Phone.Enum
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
