// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="LNQSQLDataService.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="LNQSQLDataService.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using EFC.Service.Phone.Linq;

namespace EFC.Service.Phone.Database
{
    /// <summary>
    /// Implementation of <see cref="DataServiceBase"/> class that uses Entity Framework
    /// for the database operations.
    /// </summary>
    public class LNQSQLDataService : DataServiceBase
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LNQSQLDataService" /> class.
        /// </summary>
        /// <param name="context">The db context.</param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        public LNQSQLDataService(DataContext context)
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
        public DataContext DbContext { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Returns list of data items from the data store.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <returns>
        /// Strongly typed <see cref="IEnumerable{TData}" />.
        /// </returns>
        public override IEnumerable<TData> GetAll<TData>()
        {
            var table = DbContext.GetTable<TData>();
            return table.Select(p => p);
        }

        /// <summary>
        /// Returns a data item that has the specified id.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The data item.
        /// </returns>
        public override TData GetById<TData>(int id)
        {
            var table = DbContext.GetTable<TData>();
            return table.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Adds a data item to the data store.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <param name="data">The data item to insert.</param>
        /// <returns>
        /// The data item.
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        public override TData Add<TData>(TData data)
        {
            if (Equals(data, default(TData)))
            {
                throw new ArgumentException(string.Format("Argument {0} not valid", data));
            }

            DbContext.GetTable<TData>().InsertOnSubmit(data);
            DbContext.SubmitChanges();

            return data;
        }

        /// <summary>
        /// Updates data item within the the data store.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <param name="data">The data item to update.</param>
        public override void Update<TData>(TData data)
        {
            if (Equals(data, default(TData)))
            {
                throw new ArgumentException(string.Format("Argument {0} not valid", data));
            }

            var originalItem = GetById<TData>(data.Id);

            if (originalItem == null)
            {
                throw new InvalidOperationException(string.Format("Object {0} no longer exisit", data.GetType().Name));
            }

            DbContext.GetTable<TData>().DeleteOnSubmit(data);
            DbContext.SubmitChanges();

            DbContext.GetTable<TData>().Attach(data, true);
            DbContext.SubmitChanges();
        }

        /// <summary>
        /// Deletes data item from the data store.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <param name="data">The data item to delete.</param>
        /// <exception cref="System.ArgumentException"></exception>
        public override void Delete<TData>(TData data)
        {
            if (Equals(data, default(TData)))
            {
                throw new ArgumentException(string.Format("Argument {0} not valid", data));
            }

            DbContext.GetTable<TData>().DeleteOnSubmit(data);
            DbContext.SubmitChanges();
        }

        /// <summary>
        /// Returns a list of data items from the data store based on the given specification.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <param name="specification">The specification.</param>
        /// <returns>
        /// The data items matching the specification.
        /// </returns>
        protected override IEnumerable<TData> GetBySpecification<TData>(Specification<TData> specification)
        {
            if (specification.Predicate == null)
            {
                throw new ArgumentNullException("specification", "Argument Predicate is missing");
            }

            IEnumerable<TData> items = DbContext.GetTable<TData>().Where(specification.Predicate).AsEnumerable();
            return items;
        }

        #endregion
    }
}
