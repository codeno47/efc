// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="LogLevel.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="LogLevel.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------
namespace EFC.Components.Logging
{
    /// <summary>
    /// The LogLevel enum.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// The All level.
        /// </summary>
        All,

        /// <summary>
        /// The trace level.
        /// </summary>
        Trace,

        /// <summary>
        /// The debug level.
        /// </summary>
        Debug,

        /// <summary>
        /// The information level.
        /// </summary>
        Information,

        /// <summary>
        /// The warning level.
        /// </summary>
        Warning,

        /// <summary>
        /// The error level.
        /// </summary>
        Error,

        /// <summary>
        /// The fatal error level.
        /// </summary>
        Fatal,

        /// <summary>
        /// The Off level.
        /// </summary>
        Off
    }
}
