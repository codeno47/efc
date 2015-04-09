// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="IUnitOfWork.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="IUnitOfWork.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System;

namespace EFC.Components.Data
{
    using System.Threading.Tasks;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// Commits the async.
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();

        /// <summary>
        /// Commits the with audit.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <returns>Number of changes commited.</returns>
        int CommitWithAudit(IUnityContainer container);

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        /// <returns></returns>
        int Refresh();
    }
}
