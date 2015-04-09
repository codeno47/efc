// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="SubscriptionInfo.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="SubscriptionInfo.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------


namespace EFC.Components.Events.Unity
{
    /// <summary>
    /// Struct with info about subscription passed inside of the Object Builder.
    /// </summary>
    public struct SubscriptionInfo
    {
        #region Fields

        /// <summary>
        /// The subject.
        /// </summary>
        public string Subject;

        /// <summary>
        /// The event hander method name.
        /// </summary>
        public string HandlerMethodName;

        /// <summary>
        /// The optional thread option.
        /// </summary>
        public ThreadOption? ThreadOption;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionInfo"/> struct.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerMethodName">Name of the handler method.</param>
        /// <param name="threadOption">The thread option.</param>
        public SubscriptionInfo(string subject, string handlerMethodName, ThreadOption threadOption)
        {
            this.Subject = subject;
            this.HandlerMethodName = handlerMethodName;
            this.ThreadOption = threadOption;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionInfo"/> struct.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerMethodName">Name of the handler method.</param>
        public SubscriptionInfo(string subject, string handlerMethodName)
        {
            this.Subject = subject;
            this.HandlerMethodName = handlerMethodName;
            this.ThreadOption = null;
        }

        #endregion
    }
}
