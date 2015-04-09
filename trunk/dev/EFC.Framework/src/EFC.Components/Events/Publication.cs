// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="Publication.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="Publication.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Components.Events
{
    using System;
    using System.Reflection;

    using EFC.Components.Validations;

    /// <summary>
    /// Component representing publication of the single event.
    /// </summary>
    internal class Publication : IDisposable
    {
        #region Fields

        /// <summary>
        /// Reference to the object that published event.
        /// </summary>
        private readonly WeakReference publisherReference;

        /// <summary>
        /// Reference to the subject of the publication.
        /// </summary>
        private readonly EventSubject subject;

        /// <summary>
        /// Constant with name of the method handling the published event.
        /// </summary>
        private const string EventHandlerMethodName = "PublicationHandler";

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this instance is alive.
        /// </summary>
        /// <value><c>True</c> if this instance is alive; otherwise, <c>False</c>.</value>
        public bool IsAlive
        {
            get
            {
                return this.publisherReference.IsAlive;
            }
        }

        /// <summary>
        /// Gets the publisher.
        /// </summary>
        /// <value>The publisher.</value>
        public object Publisher
        {
            get { return this.publisherReference.Target; }
        }

        /// <summary>
        /// Gets or sets the name of the event.
        /// </summary>
        /// <value>The name of the event.</value>
        public string EventName
        {
            get;
            private set;
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Publication"/> class.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="eventName">Name of the event.</param>
        internal Publication(EventSubject subject, object publisher, string eventName)
        {
            
            Requires.NotNull(subject, "subject");

            this.subject = subject;
            this.publisherReference = new WeakReference(publisher);
            this.EventName = eventName;

            Type publisherType = publisher.GetType();
            EventInfo publishedEvent = publisherType.GetEvent(eventName, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            if (publishedEvent == null)
            {
                throw new ArgumentException(string.Format(Messages.PublicEventNotFound, eventName, publisherType.Name));
            }

            EnsureIfIsSupported(publishedEvent);

            Delegate handler = Delegate.CreateDelegate(publishedEvent.EventHandlerType, this, this.GetType().GetMethod(EventHandlerMethodName));

            publishedEvent.AddEventHandler(publisher, handler);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Throws if event is static.
        /// </summary>
        /// <param name="publishedEvent">The published event.</param>
        private static void EnsureIfIsSupported(EventInfo publishedEvent)
        {
            MethodInfo methodInfo = publishedEvent.EventHandlerType.GetMethod("Invoke");
            if (!methodInfo.IsEventHandler())
            {
                throw new NotSupportedException(string.Format(Messages.OnlyEventHandlerSignaturesAreSupported, publishedEvent.Name));
            }
            if (publishedEvent.GetAddMethod().IsStatic || publishedEvent.GetRemoveMethod().IsStatic)
            {
                throw new NotSupportedException(string.Format(Messages.StaticEventNotSupported, publishedEvent.Name));
            }
        }

        /// <summary>
        /// Fires the event publication.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void PublicationHandler(object sender, EventArgs e)
        {
            this.subject.Fire(this, sender, e);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>True</c> to release both managed and unmanaged resources; <c>False</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.publisherReference != null && this.publisherReference.IsAlive && this.publisherReference.Target != null)
                {
                    object publisherObject = this.publisherReference.Target;

                    EventInfo publishedEvent = this.publisherReference.Target.GetType().GetEvent(this.EventName);
                    publishedEvent.RemoveEventHandler(this.publisherReference.Target, Delegate.CreateDelegate(publishedEvent.EventHandlerType, this, this.GetType().GetMethod(EventHandlerMethodName)));
                }
            }
        }

        #endregion
    }
}
