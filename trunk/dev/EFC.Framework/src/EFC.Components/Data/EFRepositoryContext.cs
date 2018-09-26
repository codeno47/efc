// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="EFRepositoryContext.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="EFRepositoryContext.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using EFC.Components.Events;

namespace EFC.Components.Data
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Threading.Tasks;

    using EFC.Components.Logging;
    using EFC.Components.Logging.Data;

    using EntityFramework.Extensions;
    using global::Unity;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// Implements the <see cref="IRepositoryContext"/> interface to provide an implementation
    /// that manages the repository context.
    /// </summary>
    /// <typeparam name="TContext">The type of DBContext.</typeparam>
    public abstract class EFRepositoryContext<TContext> : IRepositoryContext where TContext : DbContext
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

        /// <summary>
        /// Gets the entity framework Object Context.
        /// </summary>
        private System.Data.Entity.Core.Objects.ObjectContext Context => ((IObjectContextAdapter)DbContext).ObjectContext;

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

        /// <summary>
        /// Initializes a new instance of the <see cref="EFRepositoryContext{TContext}"/> class.
        /// </summary>
        public EFRepositoryContext()
        {
        }

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
            return CommitChanges();
        }

        /// <summary>
        /// Commits the with audit.
        /// </summary>
        /// <returns></returns>
        public int CommitWithAudit(IUnityContainer container)
        {
            OnBeforeSaveChanges();

            var auditData = this.DbContext.BeginAudit();

            var auditService = container.Resolve<IAuditService>();

            var changedCount = DbContext.SaveChanges();

            OnAfterSaveChanges();

            var log = auditData.LastLog.ToXml();

            auditService.AddLog(new AuditLog { Data = log, Time = DateTime.Now.ToUniversalTime() });

            return changedCount;
        }

        /// <summary>
        /// Commits the changes.
        /// </summary>
        /// <returns></returns>
        private int CommitChanges()
        {
            OnBeforeSaveChanges();

            var changedCount = DbContext.SaveChanges();

            OnAfterSaveChanges();

            return changedCount;
        }
        /// <summary>
        /// Commits the async.
        /// </summary>
        /// <returns></returns>
        public async Task<int> CommitAsync()
        {
            OnBeforeSaveChanges();

            var changedCount = await DbContext.SaveChangesAsync();

            OnAfterSaveChanges();

            return changedCount;
        }

        /// <summary>
        /// Rollback all the changes made in the unit of work.
        /// </summary>
        public void Rollback()
        {
            foreach (var ent in DbContext.ChangeTracker
                     .Entries()
                     .Where(p => p.State == EntityState.Deleted ||
                                     p.State == EntityState.Modified))
            {
                ent.State = EntityState.Unchanged;
            }

            foreach (var ent in DbContext.ChangeTracker
                    .Entries()
                    .Where(p => p.State == EntityState.Added))
            {
                ent.State = EntityState.Detached;
            }
        }

        /// <summary>
        /// This function is used to create the specified instance of type TEntity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data item.</typeparam>
        /// <typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam>
        /// <returns>Instance of Repository.</returns>
        public IRepository<TEntity, TIdentifier> GetRepository<TEntity, TIdentifier>() where TEntity : class, IEntity<TIdentifier>
        {
            var repository = new EFRepository<TEntity, TIdentifier>(this.DbContext);

            return repository;
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
        public int Refresh()
        {
            var refreshableObjects = GetRefreshableObjects();

            Context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, refreshableObjects);
            return 0;
        }

        /// <summary>
        /// Gets the refreshable objects.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<object> GetRefreshableObjects()
        {
            return (from entry in Context.ObjectStateManager.GetObjectStateEntries(
                                               EntityState.Added
                                               | EntityState.Deleted
                                               | EntityState.Modified
                                               | EntityState.Unchanged)
                    where entry.EntityKey != null
                    select entry.Entity);
        }

        /// <summary>
        /// Refreshes the async.
        /// </summary>
        public async void RefreshAsync()
        {
            var refreshableObjects = GetRefreshableObjects();

            await this.Context.RefreshAsync(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, refreshableObjects);
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
