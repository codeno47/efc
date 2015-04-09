// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="DisposableBase.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="DisposableBase.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using EFC.Components.Threading;

namespace EFC.Components.ComponentModel
{
    /// <summary>
    /// The disposable abstract base class.
    /// </summary>
    [Serializable]
    public abstract class DisposableBase : IDisposable
    {
        #region Fields

        /// <summary>
        /// The state.
        /// </summary>
        private readonly Locked state = new Locked();

        #endregion

        #region Destructor

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the object is reclaimed by garbage collection.
        /// </summary>
        ~DisposableBase()
        {
            Dispose(false);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Releases the unmanaged and managed resources.
        /// </summary>
        public void Dispose()
        {
            if (state.Switch(1, 0))
            {
                OnDisposing();

                Dispose(true);

                state.Switch(2);

                OnDisposed();

                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// Called when disposing.
        /// </summary>
        protected virtual void OnDisposing()
        {
        }

        /// <summary>
        /// Releases the unmanaged resources and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><c>True</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected abstract void Dispose(bool disposing);

        /// <summary>
        /// Called when disposed.
        /// </summary>
        protected virtual void OnDisposed()
        {
        }

        /// <summary>
        /// Throws exception if this instance is disposed or about to be disposed.
        /// </summary>
        protected void CheckDisposed()
        {
            if (state.Value != 0)
            {
                throw new ObjectDisposedException("Object already disposed");
            }
        }

        #endregion
    }
}
