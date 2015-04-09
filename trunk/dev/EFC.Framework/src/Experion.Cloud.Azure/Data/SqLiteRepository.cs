// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="SqLiteRepository.cs">
// // All rights reserved Copyright 2012-2015 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="EFRepository.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

namespace Experion.Cloud.Azure.Data
{
    using EFC.Components.Data;
    using EFC.Components.Enum;
    using Microsoft.WindowsAzure.MobileServices;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// SqLiteRepository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TIdentifier">The type of the identifier.</typeparam>
    public class SqLiteRepository<TEntity, TIdentifier> : RepositoryBase<TEntity, TIdentifier> where TEntity : class, IEntity<TIdentifier>
    {

        #region Properties

        /// <summary>
        /// Gets the entity framework Data Context.
        /// </summary>
        /// <value>
        /// The database context.
        /// </value>
        public IMobileServiceClient DbContext { get; set; }

        #endregion

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="SqLiteRepository{TEntity, TIdentifier}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        public SqLiteRepository(IMobileServiceClient context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.DbContext = context;
        }

        #endregion

        #region Methods


        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <param name="filterType">Type of the filter.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException">Please Async Version of GetAll</exception>
        public override Task<IEnumerable<TEntity>> GetAllOffline(FilterType filterType = FilterType.FilterCommitted)
        {
            return DbContext.GetSyncTable<TEntity>().ToEnumerableAsync();
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="filterType">Type of the filter.</param>
        /// <returns></returns>
        public override Task<IEnumerable<TEntity>> GetAllOnline(FilterType filterType = FilterType.FilterCommitted)
        {
            return DbContext.GetTable<TEntity>().ToEnumerableAsync();
        }

        /// <summary>
        /// Gets the by specification asynchronous.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        public override Task<IEnumerable<TEntity>> GetBySpecificationOnline(Specification<TEntity> specification)
        {
            return DbContext.GetTable<TEntity>().Where(specification.Predicate).ToEnumerableAsync();
        }

        /// <summary>
        /// Returns a list of entities from the repository based on the given specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <param name="filterType">The filter type.</param>
        /// <param name="useCSharpNullComparisonBehavior">Set this flag off when equating nullable types..</param>
        /// <returns>
        /// The list of entities.
        /// </returns>
        /// <exception cref="System.NotImplementedException">Please Async Version of GetBySpecificationOffline</exception>
        /// <exception cref="System.Data.InvalidExpressionException">Argument Predicate is missing</exception>
        public override Task<IEnumerable<TEntity>> GetBySpecificationOffline(Specification<TEntity> specification, FilterType filterType = FilterType.FilterCommitted, bool useCSharpNullComparisonBehavior = false)
        {
            return DbContext.GetSyncTable<TEntity>().Where(specification.Predicate).ToEnumerableAsync();
        }

        /// <summary>
        /// Returns an entity that has the specified entity key.
        /// </summary>
        /// <param name="id">Entity key value.</param>
        /// <returns>
        /// Entity.
        /// </returns>
        /// <exception cref="System.NotImplementedException">Please Async Version of GetByIdOffline</exception>
        /// <exception cref="NotSupportedException">Occurs if the Entity Type(TEntity) is not stored in the given repository.</exception>
        public override async Task<TEntity> GetByIdOffline(TIdentifier id)
        {
            var result = await DbContext.GetSyncTable<TEntity>().ToEnumerableAsync();

            return result.FirstOrDefault(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public override async Task<TEntity> GetByIdOnline(TIdentifier id)
        {
            var result = await DbContext.GetTable<TEntity>().ToEnumerableAsync();

            return result.FirstOrDefault(x => x.Id.Equals(id));
        }

        /// <summary>
        /// AddOffline an entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The entity.</returns>
        public override Task AddOffline(TEntity entity)
        {
            return DbContext.GetSyncTable<TEntity>().InsertAsync(entity);
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// TEntity.
        /// </returns>
        public override Task AddOnline(TEntity entity)
        {
            return DbContext.GetTable<TEntity>().InsertAsync(entity);
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override Task UpdateOnline(TEntity entity)
        {
            return DbContext.GetTable<TEntity>().UpdateAsync(entity);
        }

        /// <summary>
        /// UpdateOffline an entity in the repository.
        /// </summary>
        /// <param name="entity">Entity instance.</param>
        public override Task UpdateOffline(TEntity entity)
        {
            return DbContext.GetSyncTable<TEntity>().UpdateAsync(entity);
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override Task DeleteOnline(TEntity entity)
        {
            return DbContext.GetTable<TEntity>().DeleteAsync(entity);
        }

        /// <summary>
        /// Mark an entity for deletion in the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public override Task DeleteOffline(TEntity entity)
        {
            return this.DbContext.GetSyncTable<TEntity>().DeleteAsync(entity);
        }

        #endregion

        /// <summary>
        /// Synchronizes the specified query identifier.
        /// </summary>
        /// <param name="queryId">The query identifier.</param>
        /// <returns>Task</returns>
        public override Task Sync(string queryId)
        {
            return DbContext.GetSyncTable<TEntity>().PullAsync(queryId, DbContext.GetSyncTable<TEntity>().CreateQuery());
        }

        /// <summary>
        /// Synchronizes the by specification.
        /// </summary>
        /// <param name="queryId">The query identifier.</param>
        /// <param name="specification">The specification.</param>
        /// <returns>Task</returns>
        public override Task SyncBySpecification(string queryId, Specification<TEntity> specification)
        {
            return DbContext.GetSyncTable<TEntity>().PullAsync(queryId, DbContext.GetSyncTable<TEntity>().Where(specification.Predicate));
        }
    }
}
