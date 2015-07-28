// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="TraceAttribute.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="TraceAttribute.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Components.Aspect
{
    using System;
    using System.Configuration;
    using System.Reflection;
    using System.Text;

    using EFC.Components.Logging;

    using PostSharp.Aspects;

    /// <summary> 
    /// Aspect that, when applied on a method, emits a trace message before and 
    /// after the method execution. 
    /// </summary> 
    [Serializable]
    public class TraceAttribute : OnMethodBoundaryAspect
    {
        /// <summary>
        /// The is logging enabled.
        /// </summary>
        private static bool? isloggingEnabled;

        /// <summary>
        /// The synchronize lock
        /// </summary>
        private static readonly object SyncLock = new object();

        /// <summary>
        /// The method name.
        /// </summary>
        private string methodName;

        /// <summary>
        /// The is property
        /// </summary>
        private bool isproperty;

        /// <summary>
        /// Initilizes the log status.
        /// </summary>
        private void InitilizeLogStatus()
        {
            try
            {
                if (isloggingEnabled == null)
                {
                    lock (SyncLock)
                    {
                        isloggingEnabled = ConfigurationManager.AppSettings.Get("EnableVerboseLogging").Equals("true");
                    }
                }
            }
            catch (Exception)
            {
                lock (SyncLock)
                {
                    isloggingEnabled = false;
                }
            }
        }

        /// <summary>
        /// Method executed at build time. Initializes the aspect instance. After the execution  of
        /// <see cref="CompileTimeInitialize" />, the aspect is serialized as a managed
        /// resource inside the transformed assembly, and De-serialized at runtime.
        /// </summary>
        /// <param name="method">Method to which the current aspect instance
        /// has been applied.</param>
        /// <param name="aspectInfo">Unused variable.</param>
        public override void CompileTimeInitialize(MethodBase method, AspectInfo aspectInfo)
        {
            if (method.DeclaringType != null)
            {
                this.methodName = method.DeclaringType.FullName + "." + method.Name;
            }
        }

        /// <summary>
        /// Compiles the time validate.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <returns>The Status.</returns>
        public override bool CompileTimeValidate(MethodBase method)
        {
            isproperty = base.CompileTimeValidate(method);
            return isproperty;
        }

        /// <summary> 
        /// Method invoked before the execution of the method to which the current 
        /// aspect is applied. 
        /// </summary> 
        /// <param name="args">Unused variable.</param> 
        public override void OnEntry(MethodExecutionArgs args)
        {
            this.InitilizeLogStatus();

            if (isloggingEnabled == false || args.Method.Name.Equals("set_Name") || args.Method.Name.Equals("get_Name"))
            {
                return;
            }

            var argumentValues = args.Arguments;
            var parameterInfos = args.Method.GetParameters();
            var index = 0;

            var messageBuilder = new StringBuilder();

            messageBuilder.Append(string.Format("{0}: Enter", this.methodName));

            if (argumentValues != null)
            {
                foreach (var argument in args.Arguments)
                {
                    var message = string.Format("Argument Name:'{0}', Argument Value:'{1}'", parameterInfos[index].Name, argument);
                    messageBuilder.Append(message);

                    index++;
                }
            }

            lock (SyncLock)
            {
                Logger.WriteTrace(messageBuilder.ToString());
            }
        }

        /// <summary>
        /// Method invoked after successful execution of the method to which the current.
        /// aspect is applied.
        /// </summary>
        /// <param name="args">Unused variable.</param>
        public override void OnSuccess(MethodExecutionArgs args)
        {
            if (isloggingEnabled == false)
            {
                return;
            }

            var message = string.Format("{0}: Success", this.methodName);

            lock (SyncLock)
            {
                Logger.WriteTrace(message);
            }
        }
    }
}
