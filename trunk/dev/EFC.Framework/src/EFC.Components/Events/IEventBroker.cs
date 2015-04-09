// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IEventBroker.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IEventBroker.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------

namespace EFC.Components.Events
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface of the component that acts as a mediator between publisher of the event and its subscriber.
    /// </summary>
    public interface IEventBroker
    {
        #region Properties

        /// <summary>
        /// Gets the registered subjects.
        /// </summary>
        /// <value>The registered subjects.</value>
        IEnumerable<string> RegisteredSubjects { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Registers the publisher.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="eventName">Name of the event.</param>
        void RegisterPublisher(string subject, object publisher, string eventName);

        /// <summary>
        /// Registers the subscriber.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerAction">The handler action.</param>
        /// <param name="threadOption">The thread option.</param>
        void RegisterSubscriber(string subject, EventHandler handlerAction, ThreadOption threadOption);

        /// <summary>
        /// Registers the subscriber.
        /// </summary>
        /// <typeparam name="T">Type of the event arguments.</typeparam>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerAction">The handler action.</param>
        void RegisterSubscriber<T>(string subject, EventHandler<T> handlerAction) where T : EventArgs;

        /// <summary>
        /// Registers the subscriber.
        /// </summary>
        /// <typeparam name="T">Type of the event arguments.</typeparam>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerAction">The handler action.</param>
        /// <param name="threadOption">The thread option.</param>
        void RegisterSubscriber<T>(string subject, EventHandler<T> handlerAction, ThreadOption threadOption) where T : EventArgs;

        /// <summary>
        /// Registers the subscriber.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerAction">The handler action.</param>
        void RegisterSubscriber(string subject, EventHandler handlerAction);

        /// <summary>
        /// Registers the subscriber.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="subscriber">The subscriber.</param>
        /// <param name="handlerMethodName">Name of the handler method.</param>
        void RegisterSubscriber(string subject, object subscriber, string handlerMethodName);

        /// <summary>
        /// Registers the subscriber.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="subscriber">The subscriber.</param>
        /// <param name="handlerMethodName">Name of the handler method.</param>
        /// <param name="threadOption">The thread option.</param>
        void RegisterSubscriber(string subject, object subscriber, string handlerMethodName, ThreadOption threadOption);

        /// <summary>
        /// Unregisters the publisher.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="eventName">Name of the event.</param>
        void UnregisterPublisher(string subject, object publisher, string eventName);

        /// <summary>
        /// Unregisters the subscriber.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="subscriber">The subscriber.</param>
        /// <param name="handlerMethodName">Name of the handler method.</param>
        void UnregisterSubscriber(string subject, object subscriber, string handlerMethodName);

        #endregion
    }
}
