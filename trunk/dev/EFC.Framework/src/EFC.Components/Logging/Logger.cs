// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="Logger.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="Logger.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace EFC.Components.Logging
{
    /// <summary>
    /// Logger.
    /// </summary>
    public static class Logger
    {
        #region Methods

        /// <summary>
        /// Initializes the <see cref="Logger"/> class.
        /// </summary>
        static Logger()
        {
            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.SetLogWriter(new LogWriterFactory().Create());
        }

        /// <summary>
        /// Logs the specified log.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void WriteErrorLog(string message)
        {
            WriteLog(message, TraceEventType.Error, 1);
        }

        /// <summary>
        /// Writes the activity log.
        /// </summary>
        /// <param name="eventActivity">The event action.</param>
        /// <param name="message">The message.</param>
        public static void WriteActivityLog(ActivityEvent eventActivity, string message)
        {
            WriteLog(message, TraceEventType.Information, 10, eventActivity.ToString());
        }

        /// <summary>
        /// Writes the trace.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void WriteTrace(string message)
        {
            WriteLog(message, TraceEventType.Verbose, 10);
        }

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="servity">The servity.</param>
        /// <param name="activity">The activity.</param>
        private static void WriteLog(string message, TraceEventType eventType, int servity, string activity = null)
        {
            var entry = new LogEntry { Message = message, Severity = eventType, Priority = servity, Title = activity };

            Microsoft.Practices.EnterpriseLibrary.Logging.Logger.Write(entry);
        }

        #endregion
    }
}