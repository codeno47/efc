using Microsoft.Practices.Unity;

namespace EFC.Templates
{
    using System.Data.Entity;

    using EFC.Common.Service;
    using EFC.Components.Data;

    /// <summary>
    /// Application Service
    /// </summary>
    public class SampleApplicationService : ApplicationService<DbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleApplicationService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        public SampleApplicationService(IUnityContainer unity, IRepositoryContext context)
            : base(unity, context)
        {
        }
    }
}
