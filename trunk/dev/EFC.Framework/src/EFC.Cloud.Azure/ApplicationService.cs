// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="ApplicationService.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="ApplicationService.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Cloud.Azure
{
    using System;

    using EFC.Components.Exception;

    using Microsoft.Practices.Unity;
    using Microsoft.WindowsAzure.MobileServices;

    /// <summary>
    /// ApplicationService base.
    /// </summary>
    public abstract class ApplicationService<TContext> where TContext : IMobileServiceClient, IDisposable
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
        protected Data.IRepositoryContext RepositoryContext { get; set; }

        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        protected Data.IRepositoryContext DataContext { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationService{TContext}"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        protected ApplicationService(IUnityContainer unity, Data.IRepositoryContext context)
        {
            this.Unity = unity;
            this.RepositoryContext = context;
            this.InitilizeContext();
        }

        /// <summary>
        /// Saves this current changes to database.
        /// No auditing will be executed.
        /// </summary>
        /// <returns>Status code.</returns>
        protected int Save()
        {
            return this.DataContext.Commit();
        }

        /// <summary>
        /// Initializes the context.
        /// </summary>
        private void InitilizeContext()
        {
            this.DataContext = this.RepositoryContext;

            if (this.DataContext == null)
            {
                throw new ObjectNotDefinedException(string.Format("DataContext cannot be null"));
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.DataContext.Dispose();
        }
    }
}
