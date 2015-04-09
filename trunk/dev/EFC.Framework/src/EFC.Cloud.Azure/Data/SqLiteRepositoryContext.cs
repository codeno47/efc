// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="SqLiteRepositoryContext.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="SqLiteRepositoryContext.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Cloud.Azure.Data
{
    using System;
    using System.Threading.Tasks;

    using EFC.Components.Data;

    using Microsoft.Practices.Unity;
    using Microsoft.WindowsAzure.MobileServices;

    /// <summary>
    /// SQLiteRepositoryContext.
    /// </summary>
    /// <typeparam name="TContext">The type of the context.</typeparam>
    public abstract class SqLiteRepositoryContext<TContext> : IRepositoryContext where TContext : IMobileServiceClient
    {
        #region Fields

        /// <summary>
        /// A boolean value indicating whether the current object is disposed or not.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The entity framework Data Context.
        /// </summary>
        private TContext context;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the entity framework data dontext.
        /// </summary>
        /// <value>The entity framework data context.</value>
        public TContext DbContext
        {
            get
            {
                if (this.context == null)
                {
                    this.context = this.CreateContext();
                }

                return this.context;
            }
        }

        /// <summary>
        /// Gets the entity framework Object Context.
        /// </summary>
        //private System.Data.Entity.Core.Objects.ObjectContext Context
        //{
        //    get { return ((IObjectContextAdapter)this.DbContext).ObjectContext; }
        //}

        #endregion

        #region Events

        /// <summary>
        /// This event is raised before changes are saved to persistant storage.
        /// </summary>
        public event EventHandler BeforeCommit;

        /// <summary>
        /// This event is raised after changes are saved to persistant storage.
        /// </summary>
        public event EventHandler AfterCommit;

        #endregion

        #region Methods

        /// <summary>
        /// Creates the entity framework data context.
        /// </summary>
        /// <returns>The entity framework data context.</returns>
        protected abstract TContext CreateContext();

        /// <summary>
        /// Flushes the changes made in the unit of work to the data store.
        /// </summary>
        public int Commit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Commits the async.
        /// </summary>
        /// <returns></returns>
        public async Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Commits the with audit.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int CommitWithAudit(IUnityContainer container)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int Refresh()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Rollback all the changes made in the unit of work.
        /// </summary>
        public void Rollback()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function is used to create the specified instance of type TEntity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data item.</typeparam>
        /// <typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam>
        /// <returns>Instance of Repository.</returns>
        public IRepository<TEntity, TIdentifier> GetRepository<TEntity, TIdentifier>() where TEntity : class, IEntity<TIdentifier>
        {
            var repository = new SqLiteRepository<TEntity, TIdentifier>(this.DbContext);

            return repository;
        }


        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">Boolean value indicating whether to dispose or not.</param>
        private void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (this.disposed)
            {
                return;
            }

            this.disposed = true;
        }

        #endregion
    }
}
