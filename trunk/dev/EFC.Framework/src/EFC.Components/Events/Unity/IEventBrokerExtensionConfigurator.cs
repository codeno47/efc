// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IEventBrokerExtensionConfigurator.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IEventBrokerExtensionConfigurator.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------


namespace EFC.Components.Events.Unity
{
    using System;

    /// <summary>
    /// Interface of the component for configuring event broker unity extension.
    /// </summary>
    public interface IEventBrokerExtensionConfigurator
    {
        #region Methods

        /// <summary>
        /// Configures the event publication.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        /// <param name="publicationInfo">The publication info.</param>
        void ConfigureEventPublication(Type type, string name, PublicationInfo publicationInfo);

        /// <summary>
        /// Configures the event subscription.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        /// <param name="subscriptionInfo">The subscription info.</param>
        void ConfigureEventSubscription(Type type, string name, SubscriptionInfo subscriptionInfo);

        #endregion
    }
}
