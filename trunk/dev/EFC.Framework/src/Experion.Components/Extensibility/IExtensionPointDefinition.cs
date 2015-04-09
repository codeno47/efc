// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="IExtensionPointDefinition.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="IExtensionPointDefinition.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

namespace EFC.Components.Extensibility
{
    /// <summary>
    /// The extension point definition interface.
    /// </summary>
    public interface IExtensionPointDefinition
    {
        #region Properties

        /// <summary>
        /// Gets the name of the contract.
        /// </summary>
        /// <value>The name of the contract.</value>
        string ContractName { get; }

        #endregion
    }
}
