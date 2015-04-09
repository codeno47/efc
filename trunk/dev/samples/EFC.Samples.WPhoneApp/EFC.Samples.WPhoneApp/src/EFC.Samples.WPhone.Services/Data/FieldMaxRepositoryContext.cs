using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Service.Phone.RepositoryBase;
using Microsoft.Practices.Unity;

namespace EFC.Samples.WPhone.Services.Data
{
    /// <summary>
    ///     The field max repository context.
    /// </summary>
    public class FieldMaxRepositoryContext : LNQRepositoryContext<FieldMaxDataContext>
    {
        #region Fields

        /// <summary>
        ///     The connection string.
        /// </summary>
        private readonly string connectionString;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldMaxRepositoryContext"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public FieldMaxRepositoryContext(IUnityContainer container)
        {
            connectionString = container.Resolve<String>("FieldMaxDataContainer");
        }

        /// <summary>
        /// Creates the context.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override FieldMaxDataContext CreateContext()
        {
            throw new NotImplementedException();
        }
    }
}
