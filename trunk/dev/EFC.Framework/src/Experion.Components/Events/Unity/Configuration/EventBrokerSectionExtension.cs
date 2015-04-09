

namespace EFC.Components.Events.Unity.Configuration
{
    using Microsoft.Practices.Unity.Configuration;

    /// <summary>
    /// Section extension class to confgure event broker configuration elements.
    /// </summary>
    public class EventBrokerSectionExtension : SectionExtension
    {
        #region Methods

        /// <summary>
        /// Add the extensions to the section via the context.
        /// </summary>
        /// <param name="context">Context object that can be used to add elements and aliases.</param>
        public override void AddExtensions(SectionExtensionContext context)
        {
            AddElements(context);
        }

        /// <summary>
        /// Add elements to the context.
        /// </summary>
        /// <param name="context">Context object that can be used to add elements and aliases.</param>
        private static void AddElements(SectionExtensionContext context)
        {
            context.AddElement<EventSubscriptionConfigurationElement>("subscription");
            context.AddElement<EventPublicationConfigurationElement>("publication");
        }

        #endregion
    }
}
