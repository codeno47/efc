// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="BusinessService.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="BusinessService.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.Resources;
using EFC.Components.Exception;
using Microsoft.Practices.Unity;

namespace EFC.Common.Service
{
    /// <summary>
    /// Business service base.
    /// </summary>
    abstract public class BusinessService : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unity.
        /// </summary>
        /// <value>
        /// The unity.
        /// </value>
        protected IUnityContainer Unity { get; set; }

        /// <summary>
        /// Gets or sets the resource manager.
        /// </summary>
        /// <value>
        /// The resource manager.
        /// </value>
        protected ResourceManager ResourceManager { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessService" /> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="resourceManager">The resource manager.</param>
        protected BusinessService(IUnityContainer unity, ResourceManager resourceManager)
        {
            Unity = unity;
            ResourceManager = resourceManager;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        protected BusinessService(IUnityContainer unity)
        {
            Unity = unity;
        }

        /// <summary>
        /// Saves this Current changes to database.
        /// </summary>
        /// <returns>Status code.</returns>
        public virtual int Save()
        {
            return 0;
        }

        /// <summary>
        /// Gets the localized string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected string GetLocalizedString(string key)
        {
            if (ResourceManager == null)
            {
                throw new ObjectNotDefinedException(string.Format("Class member {0} not intilized", ResourceManager));
            }
            return ResourceManager.GetString(key);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public abstract void Dispose();
    }
}
