// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="PageBase.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="PageBase.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System;

namespace EFC.Client.Common.Base.Web
{
    /// <summary>
    /// PageBase.
    /// </summary>
    /// <typeparam name="TController">The type of the controller.</typeparam>
    public abstract class PageBase<TController> : System.Web.UI.Page where TController : IMvcControllerBase
    {
        #region Properties

        /// <summary>
        /// Gets or sets the controller.
        /// </summary>
        /// <value>
        /// The controller.
        /// </value>
        protected TController Controller { get; set; }

        #endregion

        #region .ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBase{TController}"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        protected PageBase(TController controller)
        {
            Controller = controller;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageBase{TController}"/> class.
        /// </summary>
        protected PageBase()
        {
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            Controller.SyncLiveData();
        }

        #endregion


    }
}
