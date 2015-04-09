﻿// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="ActivityEvent.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="ActivityEvent.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

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