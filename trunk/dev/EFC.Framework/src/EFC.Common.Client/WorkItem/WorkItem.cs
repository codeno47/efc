// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="WorkItem.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="WorkItem.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using EFC.Components.Unity;

namespace EFC.Client.Common.WorkItem
{
    /// <summary>
    /// WorkItem.
    /// </summary>
    public abstract class WorkItem : IWorkItem, IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unity.
        /// </summary>
        /// <value>
        /// The unity.
        /// </value>
        public UnityContainerManager Unity { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            OnWorkItemStart();
        }

        /// <summary>
        /// Called when [work item start].
        /// </summary>
        protected virtual void OnWorkItemStart()
        {
            Unity = UnityContainerManager.GetInstance();
            Unity.RegisterInstance(Unity);
        }

        /// <summary>
        /// Called when [work item dispose].
        /// </summary>
        protected virtual void OnWorkItemDispose()
        {
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            OnWorkItemDispose();
            Unity.Dispose();
        }

        #endregion

    }
}
