// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="IEntityBase.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="IEntityBase.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Service.Phone.EntityBase
{
    /// <summary>
    /// IEntityBase.
    /// </summary>
    public interface IEntityBase<TIdentifier>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        TIdentifier Id { get; set; }
    }
}