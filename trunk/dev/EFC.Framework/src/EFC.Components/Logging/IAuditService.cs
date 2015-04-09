// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IAuditService.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IAuditService.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Components.Logging
{
    using EFC.Components.Logging.Data;

    /// <summary>
    /// IAuditService.
    /// </summary>
    public interface IAuditService
    {
        /// <summary>
        /// Adds the log.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <returns>Status.</returns>
        bool AddLog(AuditLog log);
    }
}
