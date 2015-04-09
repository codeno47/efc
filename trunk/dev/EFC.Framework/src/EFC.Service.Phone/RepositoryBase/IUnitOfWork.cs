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

namespace EFC.Service.Phone.RepositoryBase
{
    /// <summary>
    /// IUnitOfWork.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits this instance.
        /// </summary>
        void Commit();
    }
}
