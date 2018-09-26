// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="EventSubscriptionInjectionMember.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="EventSubscriptionInjectionMember.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Components.Events.Unity.Configuration
{
    using global::Unity;
    using global::Unity.Registration;
    using System;

    /// <summary>
    /// The event subscription injection member.
    /// </summary>
    public class EventSubscriptionInjectionMember : InjectionMember
    {
        #region Fields

        /// <summary>
        /// The subscription info.
        /// </summary>
        private SubscriptionInfo subscriptionInfo;

        /// <summary>
        /// The container.
        /// </summary>
        private IUnityContainer container;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventSubscriptionInjectionMember"/> class.
        /// </summary>
        /// <param name="subscriptionInfo">The subscription info.</param>
        /// <param name="container">The container.</param>
        public EventSubscriptionInjectionMember(SubscriptionInfo subscriptionInfo, IUnityContainer container)
        {
            this.subscriptionInfo = subscriptionInfo;
            this.container = container;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the policies.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="implementationType">Type of the implementation.</param>
        /// <param name="name">The name.</param>
        /// <param name="policies">The policies.</param>
        public override void AddPolicies(Type serviceType, Type implementationType, string name, global::Unity.Policy.IPolicyList policies)
        {
            Type targetType = implementationType ?? serviceType;

            this.container.Resolve<IEventBrokerExtensionConfigurator>().ConfigureEventSubscription(targetType, name, this.subscriptionInfo);
        }

        #endregion
    }
}
