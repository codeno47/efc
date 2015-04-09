// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="RepositoryBase.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="RepositoryBase.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using EFC.Service.Phone.EntityBase;
using EFC.Service.Phone.Enum;
using EFC.Service.Phone.Events;
using EFC.Service.Phone.Linq;

namespace EFC.Service.Phone.RepositoryBase
{
    /// <summary>
    /// An abstract base class for <see cref="IRepository{TEntity}" />.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that the repository encapsulates.</typeparam>
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntityBase<int>
    {
        #region Events

        /// <summary>
        /// Raised before repository is going to be changed.
        /// </summary>
        public event EventHandler<RepositoryChangeEventArgs> RepositoryChanging;

        /// <summary>
        /// Raised after repository is changed.
        /// </summary>
        public event EventHandler<RepositoryChangeEventArgs> RepositoryChanged;

        #endregion

        #region Methods

        /// <summary>
        /// Returns list of entities from the repository or store.
        /// </summary>
        /// <param name="filterType">The filter type.</param>
        /// <returns>Strongly typed <see cref="IEnumerable{TEntity}"/>.</returns>
        public abstract IEnumerable<TEntity> GetAll(FilterType filterType = FilterType.FilterCommitted);

        /// <summary>
        /// Returns a list of entities from the repository based on the given specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <param name="filterType">The filter type.</param>
        /// <returns>The entity matching the specification.</returns>
        public abstract IEnumerable<TEntity> GetBySpecification(Specification<TEntity> specification, FilterType filterType = FilterType.FilterCommitted);

        /// <summary>
        /// Returns an entity that has the specified entity key.
        /// </summary>
        /// <param name="id">Entity key value.</param>
        /// <returns>The entity.</returns>
        public abstract TEntity GetById(int id);

        /// <summary>
        /// Add entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        public abstract TEntity Add(TEntity entity);

        /// <summary>
        /// Updates entity within the the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public abstract void Update(TEntity entity);

        /// <summary>
        /// Mark entity to be deleted within the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public abstract void Delete(TEntity entity);

        /// <summary>
        /// Raises <see cref="RepositoryChanging"/> event.
        /// </summary>
        /// <param name="changeType">Change type.</param>
        /// <param name="entity">The enitity instance.</param>
        protected virtual void OnRepositoryChanging(RepositoryChangeType changeType, TEntity entity)
        {
            EventHandler<RepositoryChangeEventArgs> handler = RepositoryChanging;

            if (handler != null)
            {
                handler(this, new RepositoryChangeEventArgs(changeType, entity));
            }
        }

        /// <summary>
        /// Raises <see cref="RepositoryChanged"/> event.
        /// </summary>
        /// <param name="changeType">Change type.</param>
        /// <param name="entity">The entity instance.</param>
        protected virtual void OnRepositoryChanged(RepositoryChangeType changeType, TEntity entity)
        {
            EventHandler<RepositoryChangeEventArgs> handler = RepositoryChanged;

            if (handler != null)
            {
                handler(this, new RepositoryChangeEventArgs(changeType, entity));
            }
        }

        #endregion
    }
}
