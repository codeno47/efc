// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="RepositoryChangeEventArgs.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="RepositoryChangeEventArgs.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System;
using EFC.Service.Phone.Enum;

namespace EFC.Service.Phone.Events
{
    /// <summary>
    /// Repository change event args.
    /// </summary>
    public class RepositoryChangeEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        /// Gets the change type.
        /// </summary>
        /// <value>The change type.</value>
        public RepositoryChangeType ChangeType { get; private set; }

        /// <summary>
        /// Gets the repository entity instance.
        /// </summary>
        /// <value>The repository entity instance.</value>
        public object Entity { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryChangeEventArgs"/> class.
        /// </summary>
        /// <param name="changeType">The change type.</param>
        /// <param name="entity">The domain entity instance.</param>
        public RepositoryChangeEventArgs(RepositoryChangeType changeType, object entity)
        {
            ChangeType = changeType;
            Entity = entity;
        }

        #endregion
    }
}
