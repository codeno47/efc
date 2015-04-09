// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="LocalizationProvider.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="LocalizationProvider.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System.Resources;

namespace EFC.Components.Localization
{
    /// <summary>
    /// LocalizationProvider.
    /// </summary>
    public class LocalizationProvider : ILocalizationProvider
    {
        /// <summary>
        /// The resource manager
        /// </summary>
        private ResourceManager resourceManager;

        /// <summary>
        /// Gets or sets the resource path.
        /// </summary>
        /// <value>
        /// The resource path.
        /// </value>
        private string ResourcePath { get; set; }

        /// <summary>
        /// Gets or sets the resource manager.
        /// </summary>
        /// <value>
        /// The resource manager.
        /// </value>
        public ResourceManager ResourceManager
        {
            get { return resourceManager; }
            set { resourceManager = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizationProvider"/> class.
        /// </summary>
        /// <param name="resourcePath">The resource path.</param>
        public LocalizationProvider(string resourcePath)
        {
            ResourcePath = resourcePath;
            BuildResourceManager();
        }

        /// <summary>
        /// Builds the resource manager.
        /// </summary>
        private void BuildResourceManager()
        {
            ////"EFC.Samples.Logging.Resource",
            ResourceManager = new ResourceManager(ResourcePath, typeof(LocalizationProvider).Assembly);
        }
        /// <summary>
        /// Gets the localized string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Localized string.</returns>
        public string GetLocalizedString(string key)
        {
            return resourceManager.GetString(key);
        }
    }
}
