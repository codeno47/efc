// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="AuditTrailBootStrapper.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="AuditTrailBootStrapper.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.Components.Logging
{
    using EntityFramework.Audit;

    /// <summary>
    /// AuditTrailBootStrapper.
    /// </summary>
    public class AuditTrailBootStrapper
    {
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            var auditConfiguration = AuditConfiguration.Default;

            auditConfiguration.IncludeRelationships = true;
            auditConfiguration.LoadRelationships = true;
            auditConfiguration.DefaultAuditable = true;

        }
    }
}
