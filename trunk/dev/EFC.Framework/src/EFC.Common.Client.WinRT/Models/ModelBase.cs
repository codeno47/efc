﻿// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ModelBase.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ModelBase.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Experion.Common.Client.WinRT.Annotations;

namespace EFC.Common.Client.WinRT.Models
{
    /// <summary>
    /// Model base class.
    /// </summary>
    abstract class ModelBase:INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
