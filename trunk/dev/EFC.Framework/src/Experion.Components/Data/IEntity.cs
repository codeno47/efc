// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="IEntity.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="IEntity.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

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
