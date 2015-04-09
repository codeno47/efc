﻿// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="ControllerBase`1.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="ControllerBase`1.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using Microsoft.Practices.Unity;

namespace EFC.Client.Common.Base.Controllers
{
    /// <summary>
    /// Controller base class.
    /// </summary>
    public abstract class MvcControllerBase
    {
        #region .ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="MvcControllerBase"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        protected MvcControllerBase(IUnityContainer container)
        {
            Container = container;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        protected IUnityContainer Container { get; set; }
    }

    #endregion

}
