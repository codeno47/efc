namespace EFC.Components.Events
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Threading;

    using EFC.Components.Exception;
    using EFC.Components.Validations;

    using System.Threading;

    /// <summary>
    /// Static event handler subscription.
    /// </summary>
    internal class StaticSubscription : SubscriptionBase
    {
        /// <summary>
        /// Handler action.
        /// </summary>
        private readonly Delegate _handlerAction;

        /// <summary>
        /// Handler method name.
        /// </summary>
        private readonly string _handlerMethodName;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaticSubscription"/> class.
        /// </summary>
        /// <param name="handlerAction">The handler action.</param>
        /// <param name="dispatcher">The UI thread dispatcher.</param>
        /// <param name="threadOption">The thread option.</param>
        internal StaticSubscription(Delegate handlerAction, Dispatcher dispatcher, ThreadOption threadOption)
            : base(CheckHandlerAction(handlerAction).Method, dispatcher, threadOption)
        {
            Requires.NotNull(handlerAction, "handlerAction");
            if (!handlerAction.Method.IsStatic)
            {
                throw ExceptionBuilder.ArgumentNotValid("handlerMethodInfo", Messages.PassedMethodMustBeStatic);
            }
            this._handlerAction = handlerAction;
            this._handlerMethodName = this.CreateMethodHandlerNameFor(handlerAction);
        }

        /// <summary>
        /// Gets the name of the handler method.
        /// </summary>
        /// <value>The name of the handler method.</value>
        public override string HandlerMethodName
        {
            get
            {
                return this._handlerMethodName;
            }
        }

        /// <summary>
        /// Gets the subscriber.
        /// </summary>
        /// <value>The subscriber.</value>
        public override object Subscriber
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the subscription delegate.
        /// </summary>
        /// <returns>The subscription delegate.</returns>
        protected override Delegate GetSubscriptionDelegate()
        {
            return this._handlerAction;
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
            return handlerAction.Equals(this._handlerAction);
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
            return false;
        }

        /// <summary>
        /// Gets the name of the subscripion method handler.
        /// </summary>
        /// <param name="handlerAction">The handler action for which the method handler name will be created.</param>
        /// <returns>A formated handler method name.</returns>
        private string CreateMethodHandlerNameFor(Delegate handlerAction)
        {
            MethodInfo methodInfo = handlerAction.Method;
            ParameterInfo[] parameterInfos = methodInfo.GetParameters();
            IEnumerable<string> parameterList = parameterInfos.Select(x => string.Format("{0} {1}", x.ParameterType.FullName, x.Name));
            string parameters = string.Join(", ", parameterList.ToArray());
            string assemblyName = this._handlerAction.Method.DeclaringType.Assembly.FullName;
            return string.Format("{0}.{1}({2}), {3}", methodInfo.DeclaringType.FullName, methodInfo.Name, parameters, assemblyName);
        }
    }
}
