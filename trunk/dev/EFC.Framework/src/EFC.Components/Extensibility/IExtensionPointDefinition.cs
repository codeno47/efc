// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IExtensionPointDefinition.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IExtensionPointDefinition.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
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
