// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="IController.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="IController.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System;
using EFC.Components.Unity;

namespace EFC.Client.Common.Base.Controllers
{
    public interface IController : IDisposable
    {
        /////// <summary>
        /////// Gets or sets the dock manager.
        /////// </summary>
        /////// <value>
        /////// The dock manager.
        /////// </value>
        ////DockingManager DockManager { get; set; }

        /////// <summary>
        /////// Gets the documents list.
        /////// The document list source of the dock manager.
        /////// </summary>
        ////ObservableCollection<DocumentContent> DocumentsList { get; set; }

        /// <summary>
        /// Gets the unity container.
        /// </summary>
        UnityContainerManager Unity { get; }

        //// /// <summary>
        //// /// Sets the doc manager.
        //// /// </summary>
        //// /// <param name="dockManager">The dock manager.</param>
        //// /// <param name="documents">The documents.</param>
        ////void SetDocManager(DockingManager dockManager, ObservableCollection<DocumentContent> documents);
    }
}