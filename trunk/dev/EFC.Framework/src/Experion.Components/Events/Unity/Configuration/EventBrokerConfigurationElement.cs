namespace EFC.Components.Events.Unity.Configuration
{
    using System.Configuration;

    using Microsoft.Practices.Unity.Configuration;

    /// <summary>
    /// The event broker configuration element.
    /// </summary>
    public abstract class EventBrokerConfigurationElement : InjectionMemberElement
    {
        #region Fields

        /// <summary>
        /// Constant representing subject attribute of the XML element.
        /// </summary>
        private const string SubjectAttribute = "subject";

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        [ConfigurationProperty(SubjectAttribute)]
        public string Subject
        {
            get { return (string)base[SubjectAttribute]; }
            set { base[SubjectAttribute] = value; }
        }

        #endregion
    }
}
