namespace EFC.Sample.MEF.Data.Contracts
{
    public interface IPlugin
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        void Execute();
    }
}
