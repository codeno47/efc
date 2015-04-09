using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFC.Samples.Service.Model;
using Experion.Components.Data;
using Experion.Components.Enum;
using Experion.Components.Unity;
using Microsoft.Practices.Unity;

namespace EFC.Samples.Service.Data
{
    public class FieldMaxRepositoryContext : EFRepositoryContext<FieldMaxDataContainer>
    {
        #region Fields

        /// <summary>
        /// The connection string.
        /// </summary>
        private readonly string connectionString;

        #endregion

        protected override FieldMaxDataContainer CreateContext()
        {
            return new FieldMaxDataContainer(connectionString);
        }

        public FieldMaxRepositoryContext(IUnityContainer container)
        {
            connectionString = container.Resolve<string>("FieldMaxDataContainer");

            //    var entityConnectionStringBuilder = new EntityConnectionStringBuilder(connectionString);

            //    DbProviderFactory factory = DbProviderFactories.GetFactory(entityConnectionStringBuilder.Provider);
            //    DbConnectionStringBuilder providerBuilder = factory.CreateConnectionStringBuilder();

            //    providerBuilder.ConnectionString = entityConnectionStringBuilder.ProviderConnectionString;

            //    string serverLogin = providerBuilder[ConnectionStringKeys.UserId].ToString();

            //    entityConnectionStringBuilder.ProviderConnectionString = providerBuilder.ToString();

            //    connectionString = entityConnectionStringBuilder.ToString();
        }
    }
}
