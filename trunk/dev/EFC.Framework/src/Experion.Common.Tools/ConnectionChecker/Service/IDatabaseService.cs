// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="IDatabaseService.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="IDatabaseService.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------
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