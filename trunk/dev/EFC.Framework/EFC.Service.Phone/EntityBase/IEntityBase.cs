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