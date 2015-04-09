namespace EFC.Components.Events.Unity.Configuration
{
    using System;

    using Microsoft.Practices.ObjectBuilder2;
    using Microsoft.Practices.Unity;

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
        /// Add policies to the <paramref name="policies"/> to configure the container to call this constructor with the appropriate parameter values.
        /// </summary>
        /// <param name="serviceType">Type of interface being registered. If no interface, this will be <see lang="null"/>.</param>
        /// <param name="implementationType">Type of concrete type being registered.</param>
        /// <param name="name">Name used to resolve the type object.</param>
        /// <param name="policies">Policy list to add policies to.</param>
        public override void AddPolicies(Type serviceType, Type implementationType, string name, IPolicyList policies)
        {
            Type targetType = implementationType ?? serviceType;

            this.container.Resolve<IEventBrokerExtensionConfigurator>().ConfigureEventSubscription(targetType, name, this.subscriptionInfo);
        }

        #endregion
    }
}
