// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="EventPublicationInjectionMember.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="EventPublicationInjectionMember.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Components.Events.Unity.Configuration
{
    using global::Unity;
    using global::Unity.Policy;
    using global::Unity.Registration;
    using System;

    /// <summary>
    /// The event publication injection member.
    /// </summary>
    public class EventPublicationInjectionMember : InjectionMember
    {
        #region Fields

        /// <summary>
        /// The publication info.
        /// </summary>
        private PublicationInfo publicationInfo;

        /// <summary>
        /// The container.
        /// </summary>
        private IUnityContainer container;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventPublicationInjectionMember"/> class.
        /// </summary>
        /// <param name="publicationInfo">The publication info.</param>
        /// <param name="container">The container.</param>
        public EventPublicationInjectionMember(PublicationInfo publicationInfo, IUnityContainer container)
        {
            this.publicationInfo = publicationInfo;
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

            this.container.Resolve<IEventBrokerExtensionConfigurator>().ConfigureEventPublication(targetType, name, this.publicationInfo);
        }

        #endregion
    }
}
