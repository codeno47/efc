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
