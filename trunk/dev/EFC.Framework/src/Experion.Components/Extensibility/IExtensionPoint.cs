// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="IExtensionPoint.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="IExtensionPoint.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace EFC.Components.Extensibility
{
    /// <summary>
    /// The extension point interface.
    /// </summary>
    public interface IExtensionPoint : IRecomposable<object>, IEnumerable<object>, INotifyPropertyChanged
    {
        #region Properties

        /// <summary>
        /// Gets the name of the contract.
        /// </summary>
        /// <value>The name of the contract.</value>
        string ContractName { get; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the contract typed extension point.
        /// </summary>
        /// <typeparam name="TContract">The type of the contract.</typeparam>
        /// <returns>The contract typed extension point.</returns>
        IExtensionPoint<TContract> AsContractTyped<TContract>();

        /// <summary>
        /// Returns the contract typed extension point.
        /// </summary>
        /// <param name="contractType">Type of the contract.</param>
        /// <returns>The contract typed extension point.</returns>
        object AsContractTyped(Type contractType);

        #endregion
    }
}
