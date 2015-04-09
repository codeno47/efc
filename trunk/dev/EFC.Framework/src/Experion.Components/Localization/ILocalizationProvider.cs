// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="ILocalizationProvider.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="ILocalizationProvider.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System.Resources;

namespace EFC.Components.Localization
{
    /// <summary>
    /// ILocalizationProvider.
    /// </summary>
    public interface ILocalizationProvider
    {
        /// <summary>
        /// Gets or sets the resource manager.
        /// </summary>
        /// <value>
        /// The resource manager.
        /// </value>
        ResourceManager ResourceManager { get; set; }

        /// <summary>
        /// Gets the localized string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Localized string.</returns>
        string GetLocalizedString(string key);
    }
}