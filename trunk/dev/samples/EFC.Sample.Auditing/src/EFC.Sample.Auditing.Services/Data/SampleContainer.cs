using System;

namespace EFC.Sample.Auditing.Services.Data
{
    using System.Data.Entity;

    /// <summary>
    /// SampleContainer.
    /// </summary>
    public partial class SampleContainer : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleContainer"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public SampleContainer(String connectionString)
            : base(connectionString)
        {

        }
    }
}
