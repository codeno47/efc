// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IRecomposable.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IRecomposable.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using EFC.Components.Events;

namespace EFC.Components.Extensibility
{
    /// <summary>
    /// The recomposable interface.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    public interface IRecomposable<T>
    {
        #region Properties

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <value>The values.</value>
        IEnumerable<T> Values { get; }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when recomposing.
        /// </summary>
        event EventHandler<RecomposeEventArgs<T>> Recomposing;

        /// <summary>
        /// Occurs when recomposed.
        /// </summary>
        event EventHandler<RecomposeEventArgs<T>> Recomposed;

        #endregion
    }
}
