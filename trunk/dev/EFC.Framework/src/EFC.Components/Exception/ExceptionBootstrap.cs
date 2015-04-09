// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ExceptionBootstrap.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ExceptionBootstrap.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Components.Exception
{
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

    /// <summary>
    /// Initializes Exception block.
    /// </summary>
    public class ExceptionBootstrap
    {
        /// <summary>
        /// Initializes this instance.
        /// Call this method to set default exception manager.
        /// </summary>
        public static void Initilize()
        {
            var config = ConfigurationSourceFactory.Create();
            var factory = new ExceptionPolicyFactory(config);

            var exceptionManager = factory.CreateManager();

            ExceptionPolicy.SetExceptionManager(exceptionManager);
        }
    }
}
