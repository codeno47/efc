namespace EFC.Sample.Auditing.Services.Data
{
    using EFC.Components.Data;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// SampleRepositoryContext.
    /// </summary>
    public class SampleRepositoryContext : EFRepositoryContext<SampleContainer>
    {
        #region Fields

        /// <summary>
        ///     The connection string.
        /// </summary>
        private readonly string connectionString;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SampleRepositoryContext"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public SampleRepositoryContext(IUnityContainer container)
        {
            this.connectionString = container.Resolve<string>("SampleContainer");
        }
        /// <summary>
        /// Creates the context.
        /// </summary>
        /// <returns></returns>
        protected override SampleContainer CreateContext()
        {
            return new SampleContainer(this.connectionString);
        }

    }
}
