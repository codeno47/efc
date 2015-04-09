// ///-----------------------------------------------------------------------
// /// <copyright file=BusinessService1.csbcompany="Experion Global">
// ///     Copyright (c) Experion Global.  All rights reserved.
// /// </copyright>
// /// <Description>
// ///     This class defines a set of utility functions that can be used
// ///     in the application.
// /// </Description>
// ///-----------------------------------------------------------------------

using System.Resources;
using Experion.Components.Unity;

namespace Experion.Client.Common.Tests
{
    abstract public class BusinessService1
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unity.
        /// </summary>
        /// <value>
        /// The unity.
        /// </value>
        private IUnityContainerManager Unity { get; set; }

        /// <summary>
        /// Gets or sets the resource manager.
        /// </summary>
        /// <value>
        /// The resource manager.
        /// </value>
        public ResourceManager ResourceManager { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessService1" /> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="resourceManager">The resource manager.</param>
        protected BusinessService1(IUnityContainerManager unity, ResourceManager resourceManager)
        {
            Unity = unity;
            ResourceManager = resourceManager;
        }

        /// <summary>
        /// Gets the localized string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected string GetLocalizedString(string key)
        {
            return ResourceManager.GetString(key);
        }
    }
}
