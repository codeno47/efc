// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ActivityEvent.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ActivityEvent.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Components.Logging
{
    /// <summary>
    /// User activity actions.
    /// </summary>
    public enum ActivityEvent
    {
        /// <summary>
        /// The create{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        Create,

        /// <summary>
        /// The delete{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        Delete,

        /// <summary>
        /// The update{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        Update,

        /// <summary>
        /// The retrieve{CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}
        /// </summary>
        Retrieve
    }
}
