// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IUnityContainerManager.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IUnityContainerManager.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using Microsoft.Practices.Unity;

namespace EFC.Components.Unity
{
    /// <summary>
    /// IUnityContainerManager.
    /// </summary>
    public interface IUnityContainerManager : IDisposable
    {
        /// <summary>
        /// Gets the container.
        /// </summary>
        IUnityContainer Container { get; }

        /// <summary>
        /// Resolves for a type.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <param name="registrationName">Name of the registration.</param>
        /// <returns></returns>
        TInstance ResolveFor<TInstance>(string registrationName);

        /// <summary>
        /// Resolves for a type.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <returns></returns>
        TInstance ResolveFor<TInstance>();

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <param name="instance">The instance.</param>
        void RegisterInstance<TInstance>(TInstance instance);

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="name">The name.</param>
        void RegisterInstance<TInstance>(TInstance instance, string name);
    }
}