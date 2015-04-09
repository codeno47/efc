// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="IExtensionPoint`1.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="IExtensionPoint`1.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

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
