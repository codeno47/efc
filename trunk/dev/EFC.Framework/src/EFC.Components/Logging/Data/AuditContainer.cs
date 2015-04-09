// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="AuditContainer.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="AuditContainer.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;

namespace EFC.Components.Logging.Data
{
    using System.Data.Entity;

    /// <summary>
    /// AuditModelContainer.
    /// </summary>
    public partial class AuditModelContainer : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditModelContainer"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public AuditModelContainer(String connectionString)
            : base(connectionString)
        {

        }
    }
}
