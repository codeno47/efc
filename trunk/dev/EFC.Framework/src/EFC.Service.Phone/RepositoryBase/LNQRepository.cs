// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="LNQRepository.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="LNQRepository.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using EFC.Service.Phone.Database;
using EFC.Service.Phone.EntityBase;
using EFC.Service.Phone.Enum;
using EFC.Service.Phone.Linq;

namespace EFC.Service.Phone.RepositoryBase
{
    /// <summary>
    /// Implementation of <see cref="RepositoryBase{TEntity}" /> class that uses Entity Framework
    /// for the repository operations.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that the repository encapsulates.</typeparam>
    public class LnqRepository<TEntity> : RepositoryBase<TEntity> where TEntity : class, IEntityBase<int>
    {

        #region Properties

        /// <summary>
        /// Gets the entity framework Data Context.
        /// </summary>
        public DataContext DbContext { get; set; }

        /// <summary>
        /// Gets or sets the LNQSQL data service.
        /// </summary>
        /// <value>
        /// The LNQSQL data service.
        /// </value>
        private LNQSQLDataService LnqsqlDataService { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of LNQRepository.
        /// </summary>
        /// <param name="context">The DbContext.</param>
        public LnqRepository(DataContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            LnqsqlDataService = new LNQSQLDataService(context);
            DbContext = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns list of entities from the repository or store.
        /// </summary>
        /// <param name="filterType">The filter type.</param>
        /// <returns>Strongly typed <see cref="IEnumerable{TEntity}"/>.</returns>
        public override IEnumerable<TEntity> GetAll(FilterType filterType = FilterType.FilterCommitted)
        {
            return LnqsqlDataService.GetAll<TEntity>();
        }

        /// <summary>
        /// Returns a list of entities from the repository based on the given specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <param name="filterType">The filter type.</param>
        /// <returns>The list of entities.</returns>
        public override IEnumerable<TEntity> GetBySpecification(Specification<TEntity> specification, FilterType filterType = FilterType.FilterCommitted)
        {
            if (specification.Predicate == null)
            {
                throw new InvalidOperationException("Argument Predicate is missing");
            }

            IEnumerable<TEntity> items = DbContext.GetTable<TEntity>().Where(specification.Predicate).AsEnumerable();

            // This code is added to ensure that the above query executed properly.
            // For example, if data connection is invalid, the above statement will not throw an exception.
            // So, while accessing the items, an exception shall be thrown in case of any failurs.
            var count = items.Count();

            return items;
        }

        /// <summary>
        /// Returns an entity that has the specified entity key.
        /// </summary>
        /// <param name="id">Entity key value.</param>
        /// <returns>
        /// Entity.
        /// </returns>
        /// <exception cref="NotSupportedException">Occurs if the Entity Type(TEntity) is not stored in the given repository.</exception>
        public override TEntity GetById(int id)
        {
            return LnqsqlDataService.GetById<TEntity>(id);
        }

        /// <summary>
        /// Add an entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The entity.</returns>
        public override TEntity Add(TEntity entity)
        {
            if (Equals(entity, default(TEntity)))
            {
                throw new InvalidOperationException("Argument could not be default");
            }

            OnRepositoryChanging(RepositoryChangeType.Add, entity);
            LnqsqlDataService.Add(entity);
            OnRepositoryChanged(RepositoryChangeType.Add, entity);
            return entity;
        }

        /// <summary>
        /// Update an entity in the repository.
        /// </summary>
        /// <param name="entity">Entity instance.</param>
        public override void Update(TEntity entity)
        {
            if (Equals(entity, default(TEntity)))
            {
                throw new InvalidOperationException("Argument could not be default");
            }
            LnqsqlDataService.Update(entity);
        }

        /// <summary>
        /// Mark an entity for deletion in the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public override void Delete(TEntity entity)
        {
            if (Equals(entity, default(TEntity)))
            {
                throw new InvalidOperationException("Argument could not be default");
            }

            LnqsqlDataService.Delete(entity);
        }

        #endregion
    }
}
