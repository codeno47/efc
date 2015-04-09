// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="IRepositoryContext.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="IRepositoryContext.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using EFC.Components.Data;

namespace Experion.Cloud.Azure.Data
{
    /// <summary>
    /// The interface that manages the repository context.
    /// 
    /// </summary>
    public interface IRepositoryContext : IUnitOfWork
    {
        /// <summary>
        /// This method will return the repository of the specified entity.
        /// 
        /// </summary>
        /// <typeparam name="TEntity">The type of the data item.</typeparam><typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam>
        /// <returns>
        /// Instance of the repository.
        /// </returns>
        Experion.Cloud.Azure.Data.IRepository<TEntity, TIdentifier> GetRepository<TEntity, TIdentifier>() where TEntity : class, IEntity<TIdentifier>;
    }
}
