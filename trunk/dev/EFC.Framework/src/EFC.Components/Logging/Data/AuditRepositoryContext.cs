﻿// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="AuditRepositoryContext.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="AuditRepositoryContext.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
namespace EFC.Components.Logging.Data
{
    using EFC.Components.Data;
    using global::Unity;

    /// <summary>
    /// AuditRepositoryContext.
    /// </summary>
    public class AuditRepositoryContext : EFRepositoryContext<AuditModelContainer>
    {
        /// <summary>
        /// The connection string
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditRepositoryContext"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public AuditRepositoryContext(IUnityContainer container)
        {
            this.connectionString = container.Resolve<string>("AuditModelContainer");
        }

        /// <summary>
        /// Creates the context.
        /// </summary>
        /// <returns></returns>
        protected override AuditModelContainer CreateContext()
        {
            return new AuditModelContainer(this.connectionString);
        }
    }
}
