﻿// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="UnitOfWork.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="UnitOfWork.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System;

namespace EFC.Components.Data
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// UnitOfWork.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public ObjectContext Context { get; private set; }

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The id.</param>
        public UnitOfWork(ObjectContext context, int id)
        {
            Id = id;
            Context = context;
            Context.ContextOptions.LazyLoadingEnabled = false;
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        public Task<int> CommitAsync()
        {
            var savedRecords = Context.SaveChanges();
            return new Task<int>(() => savedRecords);
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            return Context.SaveChanges();
        }

        /// <summary>
        /// Commits the with audit.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <returns>
        /// Number of changes commited.
        /// </returns>
        public int CommitWithAudit(IUnityContainer container)
        {
            return Context.SaveChanges();
        }

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        /// <returns></returns>
        public int Refresh()
        {
            var refreshableObjects = GetRefreshableObjects();
            Context.Refresh(RefreshMode.StoreWins, refreshableObjects);
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
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }

            GC.SuppressFinalize(this);
        }
    }
}