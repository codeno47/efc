namespace EFC.Components.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Threading;

    using EFC.Components.Exception;
    using EFC.Components.Validations;

    /// <summary>
    /// Component that acts as a mediator between publisher of the event and its subscriber.
    /// </summary>
    public class EventBroker : IEventBroker
    {
        #region Fields

        /// <summary>
        /// The dictionary of the event subjects.
        /// </summary>
        private readonly Dictionary<string, EventSubject> subjects = new Dictionary<string, EventSubject>();

        /// <summary>
        /// The UI thread dispatcher.
        /// </summary>
        private readonly Dispatcher dispatcher;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the registered subjects.
        /// </summary>
        /// <value>The registered subjects.</value>
        public IEnumerable<string> RegisteredSubjects
        {
            get { return this.subjects.Keys; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EventBroker"/> class.
        /// </summary>
        /// <param name="dispatcher">The UI thread dispatcher.</param>
        public EventBroker(Dispatcher dispatcher)
        {
            Requires.NotNull(dispatcher, "dispatcher");

            this.dispatcher = dispatcher;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventBroker"/> class.
        /// </summary>
        public EventBroker()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Registers the publisher.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="eventName">Name of the event.</param>
        public void RegisterPublisher(string subject, object publisher, string eventName)
        {
            lock (this.subjects)
            {
                EventSubject publishedEvent = this.GetEvent(subject);
                publishedEvent.AddPublication(new Publication(publishedEvent, publisher, eventName));
            }
        }

        /// <summary>
        /// Unregisters the publisher.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="eventName">Name of the event.</param>
        public void UnregisterPublisher(string subject, object publisher, string eventName)
        {
            lock (this.subjects)
            {
                EventSubject publishedEvent = this.GetEvent(subject);

                List<Publication> publicationsToRemove =
                    new List<Publication>(
                        publishedEvent.Publications.Where(p => (p.EventName == eventName && p.Publisher == publisher)));

                foreach (Publication publication in publicationsToRemove)
                {
                    publishedEvent.RemovePublication(publication);
                }

                this.RemoveEventSubjectIfEmpty(publishedEvent);
            }
        }

        /// <summary>
        /// Registers the subscriber.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="subscriber">The subscriber.</param>
        /// <param name="handlerMethodName">Name of the handler method.</param>
        public void RegisterSubscriber(string subject, object subscriber, string handlerMethodName)
        {
            this.RegisterSubscriber(subject, subscriber, handlerMethodName, ThreadOption.Publisher);
        }

        /// <summary>
        /// Registers the subscriber.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="subscriber">The subscriber.</param>
        /// <param name="handlerMethodName">Name of the handler method.</param>
        /// <param name="threadOption">The thread option.</param>
        public void RegisterSubscriber(string subject, object subscriber, string handlerMethodName, ThreadOption threadOption)
        {
            Requires.NotNull(subject, "subject");
            Requires.NotNull(subscriber, "subscriber");
            Requires.NotNullOrEmpty(handlerMethodName, "handlerMethodName");

            this.VerifyThreadOption(threadOption);

            lock (this.subjects)
            {
                EventSubject publishedEvent = this.GetEvent(subject);
                publishedEvent.AddSubscription(new WeakSubscription(publishedEvent, subscriber, handlerMethodName, this.dispatcher, threadOption));
            }
        }

        /// <summary>
        /// Registers the subscriber.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerAction">The handler action.</param>
        public void RegisterSubscriber(string subject, EventHandler handlerAction)
        {
            RegisterSubscriber(subject, handlerAction, ThreadOption.Publisher);
        }

        /// <summary>
        /// Registers the subscriber.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerAction">The handler action.</param>
        /// <param name="threadOption">The thread option.</param>
        public void RegisterSubscriber(string subject, EventHandler handlerAction, ThreadOption threadOption)
        {
            Requires.NotNull(subject, "subject");
            Requires.NotNull(handlerAction, "handlerAction");

            this.VerifyThreadOption(threadOption);

            this.AddSubscribtionFor(subject, handlerAction, threadOption);
        }

        /// <summary>
        /// Registers the subscriber.
        /// </summary>
        /// <typeparam name="T">Type of the event arguments.</typeparam>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerAction">The handler action.</param>
        public void RegisterSubscriber<T>(string subject, EventHandler<T> handlerAction) where T : EventArgs
        {
            RegisterSubscriber(subject, handlerAction, ThreadOption.Publisher);
        }

        /// <summary>
        /// Registers the subscriber.
        /// </summary>
        /// <typeparam name="T">Type of the event arguments.</typeparam>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerAction">The handler action.</param>
        /// <param name="threadOption">The thread option.</param>
        public void RegisterSubscriber<T>(string subject, EventHandler<T> handlerAction, ThreadOption threadOption) where T : EventArgs
        {
            Requires.NotNull(subject, "subject");
            Requires.NotNull(handlerAction, "handlerAction");

            this.VerifyThreadOption(threadOption);

            this.AddSubscribtionFor(subject, handlerAction, threadOption);
        }

        /// <summary>
        /// Unregisters the subscriber.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerAction">The handler action.</param>
        public void UnregisterSubscriber(string subject, EventHandler handlerAction)
        {
            this.UnregisterSubscriber(subject, (Delegate)handlerAction);
        }

        /// <summary>
        /// Unregisters the subscriber.
        /// </summary>
        /// <typeparam name="T">Type of event args.</typeparam>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerAction">The handler action.</param>
        public void UnregisterSubscriber<T>(string subject, EventHandler<T> handlerAction) where T : EventArgs
        {
           this.UnregisterSubscriber(subject, (Delegate)handlerAction);
        }

        /// <summary>
        /// Unregisters the subscriber.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="subscriber">The subscriber.</param>
        /// <param name="handlerMethodName">Name of the handler method.</param>
        public void UnregisterSubscriber(string subject, object subscriber, string handlerMethodName)
        {
            Requires.NotNull(subject, "subject");
            Requires.NotNull(subscriber, "subscriber");
            Requires.NotNullOrEmpty(handlerMethodName, "handlerMethodName");
            this.RemoveSubscriptionFor(subject, s => s.Matches(subscriber, handlerMethodName));
        }

        /// <summary>
        /// Unregisters the subscriber.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerAction">The handler action.</param>
        private void UnregisterSubscriber(string subject, Delegate handlerAction)
        {
            Requires.NotNull(subject, "subject");
            Requires.NotNull(handlerAction, "eventHandler");
            if (handlerAction.Method.IsStatic)
            {
                this.RemoveSubscriptionFor(subject, s => s.Matches(handlerAction));
            }
            else
            {
                this.RemoveSubscriptionFor(subject, s => s.Matches(handlerAction));
            }
        }

        /// <summary>
        /// Gets the event.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <returns><see cref="EventSubject"/> for the specified event name.</returns>
        private EventSubject GetEvent(string eventName)
        {
            lock (this.subjects)
            {
                if (!this.subjects.ContainsKey(eventName))
                {
                    var subject = new EventSubject(eventName);
                    this.subjects.Add(eventName, subject);
                    return subject;
                }
                return this.subjects[eventName];
            }
        }

        /// <summary>
        /// Registers the subscriber for.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerAction">The handler action.</param>
        /// <param name="threadOption">The thread option.</param>
        private void AddSubscribtionFor(string subject, Delegate handlerAction, ThreadOption threadOption)
        {
            lock (this.subjects)
            {
                EventSubject publishedEvent = this.GetEvent(subject);
                SubscriptionBase subscription;
                if (handlerAction.Method.IsStatic)
                {
                    subscription = new StaticSubscription(handlerAction, this.dispatcher, threadOption);
                }
                else
                {
                    subscription = new WeakSubscription(publishedEvent, handlerAction, this.dispatcher, threadOption);
                }
                publishedEvent.AddSubscription(subscription);
            }
        }

        /// <summary>
        /// Unsubscribes for.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="predicate">The predicate.</param>
        private void RemoveSubscriptionFor(string subject, Func<SubscriptionBase, bool> predicate)
        {
            lock (this.subjects)
            {
                EventSubject publishedEvent = this.GetEvent(subject);
                SubscriptionBase subscriptionToRemove = publishedEvent.Subscriptions.LastOrDefault(predicate);

                if (subscriptionToRemove != null)
                {
                    publishedEvent.RemoveSubscription(subscriptionToRemove);

                    this.RemoveEventSubjectIfEmpty(publishedEvent);
                }
            }
        }

        /// <summary>
        /// Removes the event if empty.
        /// </summary>
        /// <param name="eventSubject">The event subject.</param>
        private void RemoveEventSubjectIfEmpty(EventSubject eventSubject)
        {
            if (!eventSubject.HasPublications && !eventSubject.HasSubscriptions)
            {
                this.subjects.Remove(eventSubject.Subject);
            }
        }

        /// <summary>
        /// Verifies the specified thread option.
        /// </summary>
        /// <param name="threadOption">The thread option to verify.</param>
        private void VerifyThreadOption(ThreadOption threadOption)
        {
            if (threadOption == ThreadOption.UserInterface && this.dispatcher == null)
            {
                throw ExceptionBuilder.ArgumentNotValid("threadOption", Messages.UserInterfaceNotSupported);
            }
        }

        #endregion
    }
}
