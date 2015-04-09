// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="PublicationInfo.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="PublicationInfo.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------


namespace EFC.Components.Events.Unity
{
    /// <summary>
    /// Struct with info about publication passed inside of the Object Builder.
    /// </summary>
    public struct PublicationInfo
    {
        #region Fields

        /// <summary>
        /// The subject.
        /// </summary>
        public string Subject;

        /// <summary>
        /// The event name.
        /// </summary>
        public string EventName;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PublicationInfo"/> struct.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="eventName">Name of the event.</param>
        public PublicationInfo(string subject, string eventName)
        {
            this.Subject = subject;
            this.EventName = eventName;
        }

        #endregion
    }
}
