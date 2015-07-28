// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="EFRepository.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="EFRepository.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using EFC.Components.Enum;

namespace EFC.Components.Data
{
    using System.Data.Entity.Core;

    /// <summary>
    /// Implementation of <see cref="RepositoryBase{TEntity,TIdentifier}"/> class that uses Entity Framework
    /// for the repository operations.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that the repository encapsulates.</typeparam>
    /// <typeparam name="TIdentifier">The identifier that uniquely identifes the entity.</typeparam>
    public class EFRepository<TEntity, TIdentifier> : RepositoryBase<TEntity, TIdentifier> where TEntity : class, IEntity<TIdentifier>
    {

        #region Properties

        /// <summary>
        /// Gets the entity framework Data Context.
        /// </summary>
        public DbContext DbContext { get; set; }

        /// <summary>
        /// Gets the entity framework Object Context.
        /// </summary>
        private System.Data.Entity.Core.Objects.ObjectContext Context
        {
            get { return ((IObjectContextAdapter)this.DbContext).ObjectContext; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of EFRepository.
        /// </summary>
        /// <param name="context">The DbContext.</param>
        public EFRepository(DbContext context)
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
        /// Returns list of entities from the repository or store.
        /// </summary>
        /// <param name="filterType">The filter type.</param>
        /// <returns>Strongly typed <see cref="IEnumerable{TEntity}"/>.</returns>
        public override IEnumerable<TEntity> GetAll(FilterType filterType = FilterType.FilterCommitted)
        {
            if (filterType == FilterType.FilterAll)
            {
                return this.GetCommittedAndChangedEntites();
            }
            else
            {
                DbSet<TEntity> dataSet = this.DbContext.Set<TEntity>();
                return dataSet.ToList();
            }
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
        /// <exception cref="System.Data.InvalidExpressionException">Argument Predicate is missing</exception>
        public override IEnumerable<TEntity> GetBySpecification(Specification<TEntity> specification, FilterType filterType = FilterType.FilterCommitted, bool useCSharpNullComparisonBehavior = false)
        {
            IEnumerable<TEntity> items;

            if (specification.Predicate == null)
            {
                throw new InvalidExpressionException("Argument Predicate is missing");
            }

            var adapter = (IObjectContextAdapter)DbContext;
            var objectContext = adapter.ObjectContext;
            objectContext.ContextOptions.UseCSharpNullComparisonBehavior = useCSharpNullComparisonBehavior;


      
            if (filterType == FilterType.FilterAll)
            {
                items = this.GetCommittedAndChangedEntites().Where(specification.Predicate.Compile());
            }
            else
            {
                items = this.DbContext.Set<TEntity>().Where(specification.Predicate).AsEnumerable();
            }

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
        /// <returns>Entity.</returns>
        /// <exception cref="NotSupportedException">Occurs if the Entity Type(TEntity) is not stored in the given repository.</exception>
        public override TEntity GetById(TIdentifier id)
        {
            DbSet<TEntity> dataSet = this.DbContext.Set<TEntity>();

            var objSet = this.Context.CreateObjectSet<TEntity>();
            var entitySet = objSet.EntitySet;
            string[] keyNames = entitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();

            if (keyNames.Length == 1)
            {
                return dataSet.Find(id);
            }
            else
            {
                object[] compositeIds = new object[keyNames.Length];
                object compositeKeyIdentifier = id;
                PropertyDescriptorCollection keyObjectProperties = TypeDescriptor.GetProperties(compositeKeyIdentifier);
                int counter = 0;
                foreach (var keyMember in keyNames)
                {
                    PropertyDescriptor propertyDescriptor = keyObjectProperties.Find(keyMember, true);
                    var val = propertyDescriptor.GetValue(compositeKeyIdentifier);
                    compositeIds[counter++] = val;
                }
                return dataSet.Find(compositeIds);
            }
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
                throw new InvalidExpressionException("Argument could not be default");
            }

            DbSet<TEntity> dataSet = this.DbContext.Set<TEntity>();
            this.OnRepositoryChanging(RepositoryChangeType.Add, entity);
            dataSet.Add(entity);
            this.OnRepositoryChanged(RepositoryChangeType.Add, entity);
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
                throw new InvalidExpressionException("Argument could not be default");
            }

            var entityState = DbContext.Entry<TEntity>(entity).State;
            if (entityState == System.Data.Entity.EntityState.Deleted)
            {
                throw new InvalidExpressionException("Argument could not be updated");
            }

            var objSet = Context.CreateObjectSet<TEntity>();
            var entityKey = Context.CreateEntityKey(objSet.EntitySet.Name, entity);
            object originalItem;
            if (!Context.TryGetObjectByKey(entityKey, out originalItem))
            {
                throw new OptimisticConcurrencyException(string.Format("ObjectDoesNotLongerExists{0}{1}", entity.GetType().Name, entityKey));
            }

            this.OnRepositoryChanging(RepositoryChangeType.Update, entity);
            this.DbContext.Entry<TEntity>(entity).State = System.Data.Entity.EntityState.Modified;
            this.OnRepositoryChanged(RepositoryChangeType.Update, entity);
        }

        /// <summary>
        /// Mark an entity for deletion in the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public override void Delete(TEntity entity)
        {
            if (Equals(entity, default(TEntity)))
            {
                throw new InvalidExpressionException("Argument could not be default");
            }

            var objSet = Context.CreateObjectSet<TEntity>();
            var entityKey = Context.CreateEntityKey(objSet.EntitySet.Name, entity);
            object originalItem;

            if (!Context.TryGetObjectByKey(entityKey, out originalItem))
            {
                throw new OptimisticConcurrencyException(string.Format("ObjectDoesNotLongerExists{0}{1}", entity.GetType().Name, entityKey));
            }

            this.OnRepositoryChanging(RepositoryChangeType.Delete, entity);
            this.Context.DeleteObject(entity);
            this.OnRepositoryChanged(RepositoryChangeType.Delete, entity);
        }

        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="InvalidExpressionException">Argument could not be default</exception>
        /// <exception cref="OptimisticConcurrencyException"></exception>
        /// <exception cref="System.Data.InvalidExpressionException">Argument could not be default</exception>
        /// <exception cref="System.Data.OptimisticConcurrencyException"></exception>
        public override void Attach(TEntity entity)
        {
            if (Equals(entity, default(TEntity)))
            {
                throw new InvalidExpressionException("Argument could not be default");
            }

            var objSet = Context.CreateObjectSet<TEntity>();
            var entityKey = Context.CreateEntityKey(objSet.EntitySet.Name, entity);
            object originalItem;

            if (!Context.TryGetObjectByKey(entityKey, out originalItem))
            {
                throw new OptimisticConcurrencyException(string.Format("ObjectDoesNotLongerExists{0}{1}", entity.GetType().Name, entityKey));
            }

            Context.AttachTo(objSet.EntitySet.Name, entity);
        }

        /// <summary>
        /// Detaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="InvalidExpressionException">Argument could not be default</exception>
        /// <exception cref="OptimisticConcurrencyException"></exception>
        /// <exception cref="System.Data.InvalidExpressionException">Argument could not be default</exception>
        /// <exception cref="System.Data.OptimisticConcurrencyException"></exception>
        public override void Detach(TEntity entity)
        {
            if (Equals(entity, default(TEntity)))
            {
                throw new InvalidExpressionException("Argument could not be default");
            }

            var objSet = Context.CreateObjectSet<TEntity>();
            var entityKey = Context.CreateEntityKey(objSet.EntitySet.Name, entity);
            object originalItem;

            if (!Context.TryGetObjectByKey(entityKey, out originalItem))
            {
                throw new OptimisticConcurrencyException(string.Format("ObjectDoesNotLongerExists{0}{1}", entity.GetType().Name, entityKey));
            }

            Context.Detach(entity);
        }

        /// <summary>
        /// Get committed and changed entities.
        /// </summary>
        /// <returns>The list of entities.</returns>
        private IEnumerable<TEntity> GetCommittedAndChangedEntites()
        {
            // Refresh the context so that the objext state manager always refers the latest entries in persistance.
            DbContext.Set<TEntity>().ToList();

            var stateEntries = Context.ObjectStateManager.GetObjectStateEntries(System.Data.Entity.EntityState.Added | System.Data.Entity.EntityState.Modified | System.Data.Entity.EntityState.Unchanged);
            var entityEntries = stateEntries.Select(s => s.Entity).OfType<TEntity>();

            return entityEntries;
        }

        #endregion
    }
}
