﻿// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="HandleExceptionAttribute.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="HandleExceptionAttribute.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using EFC.Components.Logging;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace EFC.Components.Aspect
{
    using System.Text;

    /// <summary> 
    /// Aspect that, when applied on a method, catches all its exceptions.
    /// </summary> 
    [Serializable]
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    [MulticastAttributeUsage(MulticastTargets.Method, AllowMultiple = true)]
    public class HandleExceptionAttribute : OnExceptionAspect
    {
        #region .ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleExceptionAttribute"/> class.
        /// </summary>
        /// <param name="policyName">Name of the policy.</param>
        public HandleExceptionAttribute(string policyName)
        {
            this.PolicyName = policyName;
        }

        #region Properties

        /// <summary>
        /// Gets or sets the name of the policy.
        /// </summary>
        /// <value>
        /// The name of the policy.
        /// </value>
        private string PolicyName { get; set; }

        #endregion
        #endregion

        #region Methods

        /// <summary> 
        /// Method invoked upon failure of the method to which the current 
        /// aspect is applied. 
        /// </summary> 
        /// <param name="args">Information about the method being executed.</param> 
        public override void OnException(MethodExecutionArgs args)
        {
            Logger.WriteErrorLog(args.Exception.Message);
            Logger.WriteErrorLog(args.Exception.StackTrace);

            var innerExceptions = this.ParseException(args.Exception);
            Logger.WriteErrorLog(innerExceptions);

            ExceptionPolicy.HandleException(args.Exception, PolicyName);
        }

        /// <summary>
        /// Gets the exception messge.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>Message.</returns>
        private string GetExceptionMessge(System.Exception exception)
        {
            if (exception != null)
            {
                return exception.StackTrace;
            }

            return string.Empty;
        }

        /// <summary>
        /// Parses the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>Message.</returns>
        private string ParseException(System.Exception exception)
        {
            var exceptionMessage = new StringBuilder();

            if (exception.InnerException != null)
            {
                var message = this.GetExceptionMessge(exception.InnerException);
                if (!string.IsNullOrEmpty(message))
                {
                    exceptionMessage.AppendLine(message);
                }

                if (exception.InnerException.InnerException != null)
                {
                    message = this.GetExceptionMessge(exception.InnerException.InnerException);
                    if (!string.IsNullOrEmpty(message))
                    {
                        exceptionMessage.AppendLine(message);
                    }

                    if (exception.InnerException.InnerException.InnerException != null)
                    {
                        message = this.GetExceptionMessge(exception.InnerException.InnerException.InnerException);
                        if (!string.IsNullOrEmpty(message))
                        {
                            exceptionMessage.AppendLine(message);
                        }
                    }
                }
            }

            return exceptionMessage.ToString();

        }
        #endregion
    }
}
