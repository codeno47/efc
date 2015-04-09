// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="RecomposeEventArgs.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="RecomposeEventArgs.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace EFC.Components.Events
{
    /// <summary>
    /// The recompose event args.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    public class RecomposeEventArgs<T> : EventArgs
    {
        #region Properties

        /// <summary>
        /// Gets the add values.
        /// </summary>
        /// <value>The add values.</value>
        public IEnumerable<T> AddValues { get; private set; }

        /// <summary>
        /// Gets the remove values.
        /// </summary>
        /// <value>The remove values.</value>
        public IEnumerable<T> RemoveValues { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RecomposeEventArgs&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="addValues">The add values.</param>
        /// <param name="removeValues">The remove values.</param>
        public RecomposeEventArgs(IEnumerable<T> addValues, IEnumerable<T> removeValues)
        {
            if(addValues == null)
            {
                throw new ArgumentException("addValues");
            }

            if (removeValues == null)
            {
                throw new ArgumentException("removeValues");
            }

            AddValues = addValues;
            RemoveValues = removeValues;
        }

        #endregion
    }
}
