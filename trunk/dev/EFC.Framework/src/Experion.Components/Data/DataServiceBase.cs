// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="DataServiceBase.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="DataServiceBase.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace EFC.Components.Data
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
        /// <typeparam name="TData">The type of the data item.</typeparam><typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam>
        /// <returns>
        /// Strongly typed <see cref="T:System.Collections.Generic.IEnumerable`1"/>.
        /// </returns>
        public abstract IEnumerable<TData> GetAll<TData, TIdentifier>() where TData : class, IEntity<TIdentifier>;
        /// <summary>
        /// Returns a data item that has the specified id.
        /// 
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam><typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam><param name="id">The identifier.</param>
        /// <returns>
        /// The data item.
        /// </returns>
        public abstract TData GetById<TData, TIdentifier>(TIdentifier id) where TData : class, IEntity<TIdentifier>;
        /// <summary>
        /// Adds a data item to the data store.
        /// 
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam><typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam><param name="data">The data item to add.</param>
        /// <returns>
        /// The data item.
        /// </returns>
        public abstract TData Add<TData, TIdentifier>(TData data) where TData : class, IEntity<TIdentifier>;
        /// <summary>
        /// Updates data item within the the data store.
        /// 
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam><typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam><param name="data">The data item to update.</param>
        public abstract void Update<TData, TIdentifier>(TData data) where TData : class, IEntity<TIdentifier>;
        /// <summary>
        /// Deletes data item from the data store.
        /// 
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam><typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam><param name="data">The data item to delete.</param>
        public abstract void Delete<TData, TIdentifier>(TData data) where TData : class, IEntity<TIdentifier>;
        /// <summary>
        /// Returns a list of data items from the data store based on the given specification.
        /// 
        /// </summary>
        /// <typeparam name="TData">The type of the data item.</typeparam><typeparam name="TIdentifier">The type of identifier.</typeparam><param name="specification">The specification.</param>
        /// <returns>
        /// The data items matching the specification.
        /// </returns>
        protected abstract IEnumerable<TData> GetBySpecification<TData, TIdentifier>(Specification<TData> specification) where TData : class, IEntity<TIdentifier>;
    }
}
