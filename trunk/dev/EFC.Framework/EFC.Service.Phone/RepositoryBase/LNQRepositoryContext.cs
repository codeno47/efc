// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="EFRepositoryContext.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="EFRepositoryContext.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System;
using System.Data.Linq;
using EFC.Service.Phone.EntityBase;
using EFC.Service.Phone.Events;

namespace EFC.Service.Phone.RepositoryBase
{
    /// <summary>
    /// Implements the <see cref="IRepositoryContext" /> interface to provide an implementation
    /// that manages the repository context.
    /// </summary>
    /// <typeparam name="TContext">The type of DBContext.</typeparam>
    public abstract class LNQRepositoryContext<TContext> : IRepositoryContext where TContext : DataContext
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
                if (context == null)
                {
                    context = CreateContext();
                }

                return context;
            }
        }

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

        #region Constructors

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
        public void Commit()
        {
            OnBeforeSaveChanges();
            DbContext.SubmitChanges();

            OnAfterSaveChanges();
        }

        /// <summary>
        /// This method will return the repository of the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data item.</typeparam>
        /// <typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam>
        /// <returns>
        /// Instance of the repository.
        /// </returns>
        public IRepository<TEntity> GetRepository<TEntity, TIdentifier>() where TEntity : class, IEntityBase<int>
        {
            var repository = new LnqRepository<TEntity>(DbContext);

            return repository;
        }

        /// <summary>
        /// Rollback all the changes made in the unit of work.
        /// </summary>
        public void Rollback()
        {
            ////Not implemented.
        }

        /// <summary>
        /// Raises BeforeSaveChanges event.
        /// </summary>
        private void OnBeforeSaveChanges()
        {
            Event.Raise(BeforeCommit, this, EventArgs.Empty);
        }

        /// <summary>
        /// Raises AfterSaveChanges event.
        /// </summary>
        private void OnAfterSaveChanges()
        {
            Event.Raise(AfterCommit, this, EventArgs.Empty);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Refreshes this Data context with original values from database.
        /// </summary>
        public void Refresh()
        {
            ////Not implemented.
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

            if (disposed)
            {
                return;
            }

            disposed = true;
        }

        #endregion
    }
}
