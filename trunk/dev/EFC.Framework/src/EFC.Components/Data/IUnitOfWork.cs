// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IUnitOfWork.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IUnitOfWork.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
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
