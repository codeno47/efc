// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="DataServiceBase.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="DataServiceBase.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System.Collections.Generic;
using EFC.Service.Phone.EntityBase;
using EFC.Service.Phone.Linq;

namespace EFC.Service.Phone.Database
{
    /// <summary>
    /// The base class for data service operations which is used to handle simple data operations.
    /// 
    /// </summary>
    public abstract class DataServiceBase
    {
        /// <summary>
        /// Returns list of data items from the data store.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <returns>
        /// Strongly typed <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public abstract IEnumerable<TData> GetAll<TData>() where TData : class, IEntityBase<int>;

        /// <summary>
        /// Returns a data item that has the specified id.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The data item.
        /// </returns>
        public abstract TData GetById<TData>(int id) where TData : class, IEntityBase<int>;

        /// <summary>
        /// Adds a data item to the data store.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <param name="data">The data item to add.</param>
        /// <returns>
        /// The data item.
        /// </returns>
        public abstract TData Add<TData>(TData data) where TData : class, IEntityBase<int>;

        /// <summary>
        /// Updates data item within the the data store.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <param name="data">The data item to update.</param>
        public abstract void Update<TData>(TData data) where TData : class, IEntityBase<int>;

        /// <summary>
        /// Deletes data item from the data store.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <param name="data">The data item to delete.</param>
        public abstract void Delete<TData>(TData data) where TData : class, IEntityBase<int>;
        /// <summary>
        /// Returns a list of data items from the data store based on the given specification.
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam>
        /// <param name="specification">The specification.</param>
        /// <returns>
        /// The data items matching the specification.
        /// </returns>
        protected abstract IEnumerable<TData> GetBySpecification<TData>(Specification<TData> specification) where TData : class, IEntityBase<int>;
    }
}
