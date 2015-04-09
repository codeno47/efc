// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IExtensionPoint`1.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IExtensionPoint`1.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System.Collections.Generic;
using System.ComponentModel;

namespace EFC.Components.Extensibility
{
    /// <summary>
    /// The extension point interface.
    /// </summary>
    /// <typeparam name="TContract">The type of the contract.</typeparam>
    public interface IExtensionPoint<TContract> : IRecomposable<TContract>, IEnumerable<TContract>, INotifyPropertyChanged
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
