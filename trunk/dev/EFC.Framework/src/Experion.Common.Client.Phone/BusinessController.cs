// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="BusinessController.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="BusinessController.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System;
using EFC.Common.Client.Phone.Constants;
using Experion.Common.Client.Phone;
using Microsoft.Practices.Unity;

namespace EFC.Common.Client.Phone
{
    /// <summary>
    /// BusinessController.
    /// </summary>
    public abstract class BusinessController : IBusinessController
    {
        #region Properties

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public IUnityContainer Container { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is offline.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is offline; otherwise, <c>false</c>.
        /// </value>
        private bool IsOffline { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessController"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        protected BusinessController(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container", "container cannot be null");
            }

            Container = container;
        }

        #region Methods

        /// <summary>
        /// Switches the mode ( offline or online).
        /// </summary>
        /// <param name="mode">The mode.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">mode</exception>
        public void SwitchMode(TransferMode mode)
        {
            switch (mode)
            {
                case TransferMode.Local:
                    IsOffline = true;
                    break;

                case TransferMode.Remote:
                    IsOffline = false;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("mode");
            }
        }
        #endregion
    }
}
