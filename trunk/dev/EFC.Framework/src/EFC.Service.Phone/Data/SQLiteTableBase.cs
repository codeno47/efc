// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="SQLiteTableBase.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="SQLiteTableBase.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EFC.Service.Phone.Annotations;

namespace EFC.Service.Phone.Data
{
    /// <summary>
    /// SqLiteTableBase.
    /// </summary>
    public abstract class SqLiteTableBase : INotifyPropertyChanged, INotifyPropertyChanging
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
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region INotifyPropertyChanging

        /// <summary>
        /// Called when [property changing].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Occurs when a property value is changing.
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        #endregion
    }
}
