// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="SubscriptionBase.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="SubscriptionBase.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Components.Events
{
    using System;
    using System.ComponentModel;
    using System.Reflection;
    using System.Windows.Threading;

    using EFC.Components.Exception;
    using EFC.Components.Validations;

    /// <summary>
    /// Represents a suscription that can be used to call an event handler on the subscriber.
    /// </summary>
    internal abstract class SubscriptionBase
    {
        /// <summary>
        /// The type of the event arguments.
        /// </summary>
        protected readonly Type handlerEventArgsType;

        /// <summary>
        /// The UI thread dispatcher.
        /// </summary>
        private readonly Dispatcher dispatcher;

        /// <summary>
        /// Initializes a new instance of the <see cref="SubscriptionBase"/> class.
        /// </summary>
        /// <param name="handlerMethodInfo">The handler method info.</param>
        /// <param name="dispatcher">The UI thread dispatcher.</param>
        /// <param name="threadOption">The thread option.</param>
        protected SubscriptionBase(MethodInfo handlerMethodInfo, Dispatcher dispatcher, ThreadOption threadOption)
        {
            Requires.NotNull(handlerMethodInfo, "handlerMethodInfo");
            if (!handlerMethodInfo.IsEventHandler())
            {
                throw ExceptionBuilder.ArgumentNotValid("handlerMethodInfo", Messages.InvalidEventHandlerParameters);
            }

            this.ThreadOption = threadOption;
            ParameterInfo paramInfo = handlerMethodInfo.GetParameters()[1];
            Type paramType = paramInfo.ParameterType;
            this.handlerEventArgsType = paramType;

            this.dispatcher = dispatcher;
        }

        /// <summary>
        /// Calls the specified publication.
        /// </summary>
        /// <param name="publication">The publication.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public virtual void Call(Publication publication, object sender, EventArgs args)
        {
            var eventParameeter = new[] { sender, args };
            Type publisherEventArgsType = args.GetType();
            if (!this.handlerEventArgsType.IsAssignableFrom(publisherEventArgsType))
            {
                throw new ArgumentException(string.Format(Messages.EventArgsAreNotAssignable, publisherEventArgsType, this.handlerEventArgsType));
            }
            switch (this.ThreadOption)
            {
                case ThreadOption.Publisher:
                    this.CallOnPublisher(eventParameeter);
                    break;
                case ThreadOption.Background:
                    this.CallOnBackgroundWorker(eventParameeter);
                    break;
                case ThreadOption.UserInterface:
                    this.CallOnUserInterface(eventParameeter);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Gets the name of the handler method.
        /// </summary>
        /// <value>The name of the handler method.</value>
        public abstract string HandlerMethodName { get; }

        /// <summary>
        /// Gets the subscriber.
        /// </summary>
        /// <value>The subscriber.</value>
        public abstract object Subscriber { get; }

        /// <summary>
        /// Gets or sets the thread option.
        /// </summary>
        /// <value>The thread option.</value>
        public ThreadOption ThreadOption
        {
            get;
            private set;
        }

        /// <summary>
        /// Calls the publication on the publishers thread.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        private void CallOnPublisher(object[] parameters)
        {
            Delegate delegateAction = this.GetSubscriptionDelegate();
            if (delegateAction != null)
            {
                delegateAction.DynamicInvoke(parameters);
            }
        }

        /// <summary>
        /// Calls the publication on new background thread.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        private void CallOnBackgroundWorker(object[] parameters)
        {
            Delegate delegateAction = this.GetSubscriptionDelegate();
            if (delegateAction != null)
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (sender, e) => delegateAction.DynamicInvoke(parameters);

                worker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Calls the publication on the UI thread.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        private void CallOnUserInterface(object[] parameters)
        {
            Delegate delegateAction = this.GetSubscriptionDelegate();
            if (delegateAction != null)
            {
                this.dispatcher.BeginInvoke(DispatcherPriority.Normal, delegateAction, parameters);
            }
        }

        /// <summary>
        /// Gets the subscription delegate.
        /// </summary>
        /// <returns>The subscription delegate.</returns>
        protected abstract Delegate GetSubscriptionDelegate();

        /// <summary>
        /// Checks the handler action.
        /// </summary>
        /// <param name="handlerAction">The handler action.</param>
        /// <returns>The valid handler action.</returns>
        protected static Delegate CheckHandlerAction(Delegate handlerAction)
        {
            Requires.NotNull(handlerAction, "handlerAction");
            return handlerAction;
        }

        /// <summary>
        /// Matcheses the specified handler action.
        /// </summary>
        /// <param name="handlerAction">The handler action.</param>
        /// <returns><c>True</c> if the delegate is matching the subscription; otherwise false.</returns>
        public abstract bool Matches(Delegate handlerAction);

        /// <summary>
        /// Matcheses the specified subscriber.
        /// </summary>
        /// <param name="subscriber">The subscriber.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns><c>True</c> if the subscriber method is matching the subscription; otherwise false.</returns>
        public abstract bool Matches(object subscriber, string methodName);
    }
}
