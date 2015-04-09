namespace EFC.Components.Events
{
    using System;
    using System.Reflection;
    using System.Windows.Threading;

    using EFC.Components.Exception;
    using EFC.Components.Validations;

    /// <summary>
    /// Component representing a subscription to a single event that will not cause memory leaks if the subscription will not be unsubscribed.
    /// </summary>
    internal class WeakSubscription : SubscriptionBase
    {
        #region Fields

        /// <summary>
        /// Reference to the subject of the subscription.
        /// </summary>
        private readonly EventSubject subject;

        /// <summary>
        /// Reference to the object that subscribes to the event.
        /// </summary>
        private readonly WeakReference subscriberReference;

        /// <summary>
        /// Runtime method handle.
        /// </summary>
        private readonly RuntimeMethodHandle methodHandle;

        /// <summary>
        /// Runtime type handle.
        /// </summary>
        private readonly RuntimeTypeHandle typeHandle;

        /// <summary>
        /// Handler method name.
        /// </summary>
        private string _handlerMethodName;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether this instance is alive.
        /// </summary>
        /// <value><c>True</c> if this instance is alive; otherwise, <c>False</c>.</value>
        public bool IsAlive
        {
            get { return this.subscriberReference.IsAlive; }
        }

        /// <summary>
        /// Gets the name of the handler method.
        /// </summary>
        /// <value>The name of the handler method.</value>
        public override string HandlerMethodName
        {
            get { return this._handlerMethodName; }
        }

        /// <summary>
        /// Gets the subscriber.
        /// </summary>
        /// <value>The subscriber.</value>
        public override object Subscriber
        {
            get { return this.subscriberReference.Target; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakSubscription"/> class.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="subscriber">The subscriber.</param>
        /// <param name="handlerMethodName">Name of the handler method.</param>
        /// <param name="dispatcher">The UI thread dispatcher.</param>
        /// <param name="threadOption">The thread option.</param>
        internal WeakSubscription(EventSubject subject, object subscriber, string handlerMethodName, Dispatcher dispatcher, ThreadOption threadOption)
            : this(subject, subscriber, GetMethodInfo(subscriber, handlerMethodName, null), dispatcher, threadOption)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakSubscription"/> class.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="handlerAction">The handler action.</param>
        /// <param name="dispatcher">The UI thread dispatcher.</param>
        /// <param name="threadOption">The thread option.</param>
        internal WeakSubscription(EventSubject subject, Delegate handlerAction, Dispatcher dispatcher, ThreadOption threadOption)
            : this(subject, CheckHandlerAction(handlerAction).Target, CheckHandlerAction(handlerAction).Method, dispatcher, threadOption)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeakSubscription"/> class.
        /// </summary>
        /// <param name="subject">The subject.</param>
        /// <param name="subscriber">The subscriber.</param>
        /// <param name="handlerMethodInfo">The handler method info.</param>
        /// <param name="dispatcher">The UI thread dispatcher.</param>
        /// <param name="threadOption">The thread option.</param>
        protected WeakSubscription(EventSubject subject, object subscriber, MethodInfo handlerMethodInfo, Dispatcher dispatcher, ThreadOption threadOption)
            : base(handlerMethodInfo, dispatcher, threadOption)
        {
            Requires.NotNull(subject, "subject");
            Requires.NotNull(subscriber, "subscriber");
            Requires.NotNull(handlerMethodInfo, "handlerMethodInfo");

            if (handlerMethodInfo.IsStatic)
            {
                throw ExceptionBuilder.ArgumentNotValid("handlerMethodInfo", Messages.PassedMethodCantBeStatic);
            }

            this._handlerMethodName = handlerMethodInfo.Name;
            this.subject = subject;
            this.subscriberReference = new WeakReference(subscriber);
            this.typeHandle = subscriber.GetType().TypeHandle;
            this.methodHandle = handlerMethodInfo.MethodHandle;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the method info.
        /// </summary>
        /// <param name="subscriber">The subscriber.</param>
        /// <param name="handlerMethodName">Name of the handler method.</param>
        /// <param name="parameterTypes">The parameter types.</param>
        /// <returns><see cref="MethodInfo"/> instance with metadata about event handler.</returns>
        private static MethodInfo GetMethodInfo(object subscriber, string handlerMethodName, Type[] parameterTypes)
        {
            Requires.NotNull(subscriber, "subscriber");

            Type type = subscriber.GetType();
            var bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            if (parameterTypes != null)
            {
                return type.GetMethod(handlerMethodName, bindingFlags, null, parameterTypes, null);
            }
            try
            {
                return type.GetMethod(handlerMethodName, bindingFlags);
            }
            catch (AmbiguousMatchException)
            {
                throw new NotSupportedException(string.Format(Messages.SubscriptionDoesNotSupportMethodOverloads, handlerMethodName, subscriber.GetType()));
            }
        }

        /// <summary>
        /// Calls the specified publication.
        /// </summary>
        /// <param name="publication">The publication.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public override void Call(Publication publication, object sender, EventArgs args)
        {
            if (this.IsAlive)
            {
                base.Call(publication, sender, args);
            }
            else
            {
                this.subject.RemoveSubscription(this);
            }
        }

        /// <summary>
        /// Creates the subscription delegate.
        /// </summary>
        /// <returns><see cref="Delegate"/> that is target of the event.</returns>
        protected override Delegate GetSubscriptionDelegate()
        {
            object subscriberObject = this.subscriberReference.Target;
            if (subscriberObject != null)
            {
                MethodInfo methodInfo = (MethodInfo)MethodBase.GetMethodFromHandle(this.methodHandle, this.typeHandle);
                Type handlerDelegateType = typeof(EventHandler<>).MakeGenericType(handlerEventArgsType);
                return Delegate.CreateDelegate(handlerDelegateType, subscriberObject, methodInfo);
            }

            return null;
        }

        /// <summary>
        /// Matcheses the specified handler action.
        /// </summary>
        /// <param name="handlerAction">The handler action.</param>
        /// <returns>
        /// <c>True</c> if the delegate is matching the subscription; otherwise false.
        /// </returns>
        public override bool Matches(Delegate handlerAction)
        {
            if (handlerAction == null)
            {
                return false;
            }
            object subscriberObject = this.subscriberReference.Target;
            if (subscriberObject == null)
            {
                return false;
            }
            var methodInfo = MethodBase.GetMethodFromHandle(this.methodHandle, this.typeHandle);
            return handlerAction.Method.Equals(methodInfo) && subscriberObject.Equals(handlerAction.Target);
        }

        /// <summary>
        /// Matcheses the specified subscriber.
        /// </summary>
        /// <param name="subscriber">The subscriber.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns>
        /// <c>True</c> if the subscriber method is matching the subscription; otherwise false.
        /// </returns>
        public override bool Matches(object subscriber, string methodName)
        {
            object subscriberObject = this.subscriberReference.Target;
            if (subscriberObject == null)
            {
                return false;
            }
            return subscriberObject.Equals(subscriber) &&
                   string.Equals(this._handlerMethodName, methodName);
        }

        #endregion
    }
}
