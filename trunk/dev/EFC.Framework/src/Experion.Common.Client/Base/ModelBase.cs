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

namespace EFC.Client.Common.Base
{
    /// <summary>
    /// ModelBase.
    /// </summary>
    public class ModelBase : INotifyPropertyChanged
    {
       /// <summary>
        /// Initializes a new instance of the <see cref="ModelBase"/> class.
        /// </summary>
        public ModelBase()
        {
        }

        /// <summary>
        /// Raises the property changed.
        /// </summary>
        /// <param name="popertyName">Name of the poperty.</param>
        protected virtual void RaisePropertyChanged(string popertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(popertyName));
            }
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}