// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IEntity.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IEntity.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Components.Data
{
    /// <summary>
    /// Base contract for storing and retrieving the unique identifier of an entity.
    /// </summary>
    /// <typeparam name="TIdentifier">The type of identifier that uniquely identifes the entity.</typeparam>
    public interface IEntity<TIdentifier>
    {
        /// <summary>
        /// Gets an identifier that uniquely identifies an entity.
        /// </summary>
        /// <value>The identifier that uniquely identifes the entity.</value>
        TIdentifier Id { get; }
    }
}
