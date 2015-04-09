// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="ModelBase.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="ModelBase.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.CompilerServices;
using Experion.Common.Client.Phone.Annotations;

namespace EFC.Common.Client.Phone.Models
{
    /// <summary>
    /// Model base class.
    /// </summary>
    public abstract class ModelBase : INotifyPropertyChanged
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
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
