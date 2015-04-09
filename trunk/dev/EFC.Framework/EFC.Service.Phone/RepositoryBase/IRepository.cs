// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="IRepository.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="IRepository.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using EFC.Service.Phone.EntityBase;
using EFC.Service.Phone.Enum;
using EFC.Service.Phone.Events;
using EFC.Service.Phone.Linq;

namespace EFC.Service.Phone.RepositoryBase
{
    /// <summary>
    /// The repository interface defines a standard contract that repository components should implement.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that the repository encapsulates.</typeparam>
    public interface IRepository<TEntity> where TEntity : class, IEntityBase<int>
    {
        /// <summary>
        /// Returns list of entities from the repository or store.
        /// 
        /// </summary>
        /// <param name="filterType">The filter type.</param>
        /// <returns>
        /// Strongly typed <see cref="T:System.Collections.Generic.IEnumerable`1"/>.
        /// </returns>
        IEnumerable<TEntity> GetAll(FilterType filterType = FilterType.FilterCommitted);

        /// <summary>
        /// Returns a list of entities from the repository based on the given specification.
        /// 
        /// </summary>
        /// <param name="specification">The specification.</param><param name="filterType">The filter type.</param>
        /// <returns>
        /// The entity matching the specification.
        /// </returns>
        IEnumerable<TEntity> GetBySpecification(Specification<TEntity> specification, FilterType filterType = FilterType.FilterCommitted);

        /// <summary>
        /// Returns an entity that has the specified entity key.
        /// 
        /// </summary>
        /// <param name="id">Entity key value.</param>
        /// <returns>
        /// The entity.
        /// </returns>
        TEntity GetById(int id);

        /// <summary>
        /// Add entity to the repository.
        /// 
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>
        /// The added entity.
        /// </returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Updates entity within the the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Mark entity to be deleted within the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Raised before repository is going to be changed.
        /// 
        /// </summary>
        event EventHandler<RepositoryChangeEventArgs> RepositoryChanging;
        /// <summary>
        /// Raised after repository is changed.
        /// </summary>
        event EventHandler<RepositoryChangeEventArgs> RepositoryChanged;
    }
}
