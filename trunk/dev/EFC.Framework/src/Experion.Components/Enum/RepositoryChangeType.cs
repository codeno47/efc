// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="RepositoryChangeType.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="RepositoryChangeType.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

namespace EFC.Components.Enum
{
    /// <summary>
    /// Repository change types.
    /// 
    /// </summary>
    public enum RepositoryChangeType
    {
        /// <summary>
        /// The none
        /// </summary>
        None,
        /// <summary>
        /// The get
        /// </summary>
        Get,
        /// <summary>
        /// The add
        /// </summary>
        Add,
        /// <summary>
        /// The update
        /// </summary>
        Update,
        /// <summary>
        /// The delete
        /// </summary>
        Delete,

        /// <summary>
        /// The attach
        /// </summary>
        Attach,

        /// <summary>
        /// The detach
        /// </summary>
        Detach
    }
}
