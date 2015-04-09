// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="Event.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="Event.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;

namespace EFC.Service.Phone.Events
{
    /// <summary>
    /// The event helper class.
    /// </summary>
    public static class Event
    {
        #region Methods

        /// <summary>
        /// Raises the specified handler.
        /// </summary>
        /// <param name="handler">The handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public static void Raise(EventHandler handler, object sender, EventArgs e)
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        /// <summary>
        /// Raises the specified handler.
        /// </summary>
        /// <param name="handler">The handler.</param>
        /// <param name="sender">The sender.</param>
        public static void Raise(EventHandler handler, object sender)
        {
            Raise(handler, sender, EventArgs.Empty);
        }

        /// <summary>
        /// Raises the specified handler.
        /// </summary>
        /// <typeparam name="TEventArgs">The type of the event args.</typeparam>
        /// <param name="handler">The handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <typeparamref name="TEventArgs"/> instance containing the event data.</param>
        public static void Raise<TEventArgs>(EventHandler<TEventArgs> handler, object sender, TEventArgs e) where TEventArgs : EventArgs
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        /////// <summary>
        /////// Raises the specified handler.
        /////// </summary>
        /////// <param name="handler">The handler.</param>
        /////// <param name="sender">The sender.</param>
        /////// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        ////public static void Raise(CancelEventHandler handler, object sender, CancelEventArgs e)
        ////{
        ////    if (handler != null)
        ////    {
        ////        handler(sender, e);
        ////    }
        ////}

        /// <summary>
        /// Raises the specified handler.
        /// </summary>
        /// <param name="handler">The handler.</param>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        public static void Raise(PropertyChangedEventHandler handler, object sender, PropertyChangedEventArgs e)
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        #endregion
    }
}
