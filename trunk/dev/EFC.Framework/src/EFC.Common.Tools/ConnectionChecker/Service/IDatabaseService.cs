// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IDatabaseService.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IDatabaseService.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System.Data;

namespace Experion.Common.Tools.ConnectionChecker.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDatabaseService
    {
        /// <summary>
        /// Determines whether [is server active].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is server active]; otherwise, <c>false</c>.
        /// </returns>
        bool IsServerActive();

        /// <summary>
        /// Gets the connection details to table.
        /// </summary>
        /// <returns></returns>
        DataTable GetConnectionDetailsToTable();
    }
}