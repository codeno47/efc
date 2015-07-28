// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ApplicationService.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ApplicationService.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.Data.Entity;
using EFC.Components.Data;
using EFC.Components.Exception;
using Microsoft.Practices.Unity;

namespace EFC.Common.Service
{
    /// <summary>
    /// ApplicationService base.
    /// </summary>
    public abstract class ApplicationService<TContext> where TContext : DbContext, IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unity.
        /// </summary>
        /// <value>
        /// The unity.
        /// </value>
        protected IUnityContainer Unity { get; set; }

        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        protected IRepositoryContext RepositoryContext { get; set; }

        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        protected IRepositoryContext DataContext { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is audit enabled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is audit enabled; otherwise, <c>false</c>.
        /// </value>
        private bool IsAuditEnabled { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationService{TContext}"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        protected ApplicationService(IUnityContainer unity, IRepositoryContext context)
        {
            Unity = unity;
            RepositoryContext = context;
            InitilizeContext();
            InitializeAudit();
        }

        /// <summary>
        /// Initializes the audit.
        /// </summary>
        private void InitializeAudit()
        {
            try
            {
                IsAuditEnabled = Unity.Resolve<bool>("IsAuditEnabled");
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// Saves this current changes to database.
        /// No auditing will be executed.
        /// </summary>
        /// <returns>Status code.</returns>
        protected int Save()
        {
            return DataContext.Commit();
        }

        /// <summary>
        /// Saves the changes with Audit if enabled.
        /// If save failed, it will throw entity exception.
        /// </summary>
        protected void SaveChangesWithAudit()
        {
            if (IsAuditEnabled)
            {
                DataContext.CommitWithAudit(Unity);
            }
            else
            {
                this.Save();
            }
        }

        /// <summary>
        /// Initializes the context.
        /// </summary>
        private void InitilizeContext()
        {
            DataContext = RepositoryContext;

            if (DataContext == null)
            {
                throw new ObjectNotDefinedException("DataContext does not implement EFRepositoryContext");
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            DataContext.Dispose();
        }
    }
}
