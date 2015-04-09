// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IBusinessController.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IBusinessController.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
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