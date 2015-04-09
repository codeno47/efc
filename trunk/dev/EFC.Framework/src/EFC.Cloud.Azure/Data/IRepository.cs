// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IRepository.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IRepository.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Cloud.Azure.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EFC.Components.Data;
    using EFC.Components.Enum;

    /// <summary>
    /// The repository interface defines a standard contract that repository components should implement.
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that the repository encapsulates.</typeparam><typeparam name="TIdentifier">The identifier that uniquely identifes the entity.</typeparam>
    public interface IRepository<TEntity, TIdentifier> where TEntity : class, IEntity<TIdentifier>
    {
        /// <summary>
        /// Returns list of entities from the repository or store.
        /// </summary>
        /// <param name="filterType">The filter type.</param>
        /// <returns>
        /// Strongly typed <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        Task<IEnumerable<TEntity>> GetAllOffline(FilterType filterType = FilterType.FilterCommitted);

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="filterType">Type of the filter.</param>
        /// <returns>
        /// TEntity collection.
        /// </returns>
        Task<IEnumerable<TEntity>> GetAllOnline(FilterType filterType = FilterType.FilterCommitted);

        /// <summary>
        /// Returns a list of entities from the repository based on the given specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <param name="filterType">The filter type.</param>
        /// <param name="useCSharpNullComparisonBehavior">Set this flag off when equating nullable types..</param>
        /// <returns>
        /// The list of entities.
        /// </returns>
        /// <exception cref="System.Data.InvalidExpressionException">Argument Predicate is missing</exception>
        Task<IEnumerable<TEntity>> GetBySpecificationOffline(
           Specification<TEntity> specification,
           FilterType filterType = FilterType.FilterCommitted,
           bool useCSharpNullComparisonBehavior = false);

        /// <summary>
        /// Gets the by specification asynchronous.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>
        /// TEntity Collection.
        /// </returns>
        Task<IEnumerable<TEntity>> GetBySpecificationOnline(Specification<TEntity> specification);

        /// <summary>
        /// Returns an entity that has the specified entity key.
        /// </summary>
        /// <param name="id">Entity key value.</param>
        /// <returns>
        /// The entity.
        /// </returns>
        Task<TEntity> GetByIdOffline(TIdentifier id);

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity.</returns>
        Task<TEntity> GetByIdOnline(TIdentifier id);

        /// <summary>
        /// AddOffline entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>
        /// The added entity.
        /// </returns>
        Task AddOffline(TEntity entity);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// TEntity
        /// </returns>
        Task AddOnline(TEntity entity);

        /// <summary>
        /// Updates entity within the the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>Task</returns>
        Task UpdateOffline(TEntity entity);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task</returns>
        Task UpdateOnline(TEntity entity);

        /// <summary>
        /// Mark entity to be deleted within the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns></returns>
        Task DeleteOffline(TEntity entity);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task</returns>
        Task DeleteOnline(TEntity entity);

        /// <summary>
        /// Synchronizes the specified query identifier.
        /// </summary>
        /// <param name="queryId">The query identifier.</param>
        /// <returns>Task</returns>
        Task Sync(string queryId);

        /// <summary>
        /// Synchronizes the by specification.
        /// </summary>
        /// <param name="queryId">The query identifier.</param>
        /// <param name="specification">The specification.</param>
        /// <returns>Task</returns>
        Task SyncBySpecification(string queryId, Specification<TEntity> specification);
    }
}
