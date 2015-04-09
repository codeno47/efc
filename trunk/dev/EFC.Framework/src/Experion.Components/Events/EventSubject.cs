namespace EFC.Components.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EFC.Components.Validations;

    /// <summary>
    /// The subject of the published event.
    /// </summary>
    internal class EventSubject
    {
        #region Fields

        /// <summary>
        /// Publication comparer.
        /// </summary>
        private readonly IEqualityComparer<Publication> publicationComparer;

        /// <summary>
        /// The list of subscriptions for single subject.
        /// </summary>
        private readonly List<SubscriptionBase> subscriptions;

        /// <summary>
        /// The list of publications for single subject.
        /// </summary>
        private readonly List<Publication> publications;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the publications.
        /// </summary>
        /// <value>The publications.</value>
        public IEnumerable<Publication> Publications
        {
            get { return this.publications; }
        }

        /// <summary>
        /// Gets the subscriptions.
        /// </summary>
        /// <value>The subscriptions.</value>
        public IEnumerable<SubscriptionBase> Subscriptions
        {
            get { return this.subscriptions; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has subscriptions.
        /// </summary>
        /// <value><c>True</c> if this instance has subscriptions; otherwise, <c>False</c>.</value>
        public bool HasSubscriptions
        {
            get { return this.subscriptions.Count > 0; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has publications.
        /// </summary>
        /// <value><c>True</c> if this instance has publications; otherwise, <c>False</c>.</value>
        public bool HasPublications
        {
            get { return this.publications.Count > 0; }
        }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public string Subject { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventSubject"/> class.
        /// </summary>
        /// <param name="subject">The subject.</param>
        internal EventSubject(string subject)
        {
            Requires.NotNullOrEmpty(subject, "subject");

            this.publications = new List<Publication>();
            this.subscriptions = new List<SubscriptionBase>();
            this.publicationComparer = new PublicationComparerer();
            this.Subject = subject;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the publication.
        /// </summary>
        /// <param name="publication">The publication.</param>
        public void AddPublication(Publication publication)
        {
            if (this.publications.Contains(publication, this.publicationComparer))
            {
                throw new InvalidOperationException(Messages.DuplicatedPublication);
            }
            this.publications.Add(publication);
        }

        /// <summary>
        /// Adds the subscription.
        /// </summary>
        /// <param name="subscription">The subscription.</param>
        public void AddSubscription(SubscriptionBase subscription)
        {
            this.subscriptions.Add(subscription);
        }

        /// <summary>
        /// Removes the publication.
        /// </summary>
        /// <param name="publication">The publication.</param>
        public void RemovePublication(Publication publication)
        {
            this.publications.Remove(publication);
            publication.Dispose();
        }

        /// <summary>
        /// Removes the subscription.
        /// </summary>
        /// <param name="subscription">The subscription.</param>
        public void RemoveSubscription(SubscriptionBase subscription)
        {
            this.subscriptions.Remove(subscription);
        }

        /// <summary>
        /// Fires the specified publication.
        /// </summary>
        /// <param name="publication">The publication.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void Fire(Publication publication, object sender, EventArgs args)
        {
            List<SubscriptionBase> subs = new List<SubscriptionBase>(this.Subscriptions);

            foreach (SubscriptionBase subscription in subs)
            {
                subscription.Call(publication, sender, args);
            }
        }

        #endregion
    }
}
