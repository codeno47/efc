// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="IBusinessController.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="IBusinessController.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using EFC.Common.Client.Phone.Constants;
using Microsoft.Practices.Unity;

namespace EFC.Common.Client.Phone
{
    public interface IBusinessController
    {
        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        IUnityContainer Container { get; set; }

        /// <summary>
        /// Switches the mode ( offline or online).
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">mode</exception>
        void SwitchMode(TransferMode mode);
    }
}