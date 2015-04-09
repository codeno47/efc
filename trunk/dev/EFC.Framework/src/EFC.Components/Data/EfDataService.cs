// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="EfDataService.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="EfDataService.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace EFC.Components.Data
{
    using System.Data.Entity.Core;

    /// <summary>
    /// Implementation of <see cref="DataServiceBase"/> class that uses Entity Framework
    /// for the database operations.
    /// </summary>
    public class EfDataService : DataServiceBase
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EfDataService"/> class.
        /// </summary>
        /// <param name="context">The db context.</param>
        public EfDataService(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            DbContext = context;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the entity framework Data Context.
        /// </summary>
        public DbContext DbContext { get; private set; }

        /// <summary>
        /// Gets the entity framework Object Context.
        /// </summary>
        private System.Data.Entity.Core.Objects.ObjectContext Context
        {
            get { return ((IObjectContextAdapter)this.DbContext).ObjectContext; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns list of data items from the data store.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam>
        /// <returns>Strongly typed <see cref="IEnumerable{TData}"/>.</returns>
        public override IEnumerable<TData> GetAll<TData, TIdentifier>()
        {
            DbSet<TData> dataSet = DbContext.Set<TData>();
            return dataSet.ToList();
        }

        /// <summary>
        /// Returns a data item that has the specified id.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>The data item.</returns>
        public override TData GetById<TData, TIdentifier>(TIdentifier id)
        {
            DbSet<TData> dataSet = DbContext.Set<TData>();

            var objSet = Context.CreateObjectSet<TData>();
            var entitySet = objSet.EntitySet;
            string[] keyNames = entitySet.ElementType.KeyMembers.Select(k => k.Name).ToArray();

            if (keyNames.Length == 1)
            {
                return dataSet.Find(id);
            }

            var compositeIds = new object[keyNames.Length];
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

        /// <summary>
        /// Adds a data item to the data store.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam>
        /// <param name="data">The data item to insert.</param>
        /// <returns>The data item.</returns>
        public override TData Add<TData, TIdentifier>(TData data)
        {
            if (Equals(data, default(TData)))
            {
                throw new ArgumentException(string.Format("Argument {0} not valid", data));
            }

            DbSet<TData> dataSet = DbContext.Set<TData>();
            dataSet.Add(data);
            this.DbContext.SaveChangesAsync();

            return data;
        }

        /// <summary>
        /// Updates data item within the the data store.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam>
        /// <param name="data">The data item to update.</param>
        public override async void Update<TData, TIdentifier>(TData data)
        {
            if (Equals(data, default(TData)))
            {
                throw new ArgumentException(string.Format("Argument {0} not valid", data));
            }

            var objSet = Context.CreateObjectSet<TData>();
            var entityKey = Context.CreateEntityKey(objSet.EntitySet.Name, data);
            object originalItem;
            if (!Context.TryGetObjectByKey(entityKey, out originalItem))
            {
                throw new OptimisticConcurrencyException(string.Format("Object {0} no longer exisit", data.GetType().Name));
            }

            this.DbContext.Entry<TData>(data).State = System.Data.Entity.EntityState.Modified;
            await this.DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes data item from the data store.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam>
        /// <param name="data">The data item to delete.</param>
        public override async void Delete<TData, TIdentifier>(TData data)
        {
            if (Equals(data, default(TData)))
            {
                throw new ArgumentException(string.Format("Argument {0} not valid", data));
            }

            var objSet = Context.CreateObjectSet<TData>();
            var entityKey = Context.CreateEntityKey(objSet.EntitySet.Name, data);
            object originalItem;
            if (!Context.TryGetObjectByKey(entityKey, out originalItem))
            {
                throw new OptimisticConcurrencyException(string.Format("Object {0} no longer exisit", data.GetType().Name));
            }

            this.Context.DeleteObject(data);
            await this.DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Returns a list of data items from the data store based on the given specification.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <typeparam name="TIdentifier">The type of identifier.</typeparam>
        /// <param name="specification">The specification.</param>
        /// <returns>The data items matching the specification.</returns>
        protected override IEnumerable<TData> GetBySpecification<TData, TIdentifier>(Specification<TData> specification)
        {
            IEnumerable<TData> items;

            if (specification.Predicate == null)
            {
                throw new InvalidExpressionException("Argument Predicate is missing");
            }

            items = this.DbContext.Set<TData>().Where(specification.Predicate).AsEnumerable();
            return items;
        }

        #endregion
    }
}
