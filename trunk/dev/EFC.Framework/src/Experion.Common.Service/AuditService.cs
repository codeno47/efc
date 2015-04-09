using System.Data.Entity;

using Microsoft.Practices.Unity;

namespace EFC.Common.Service
{
    using System;

    using EFC.Components.Data;
    using EFC.Components.Logging;
    using EFC.Components.Logging.Data;

    /// <summary>
    /// Application Service
    /// </summary>
    public class AuditService : ApplicationService<AuditModelContainer>, IAuditService
    {

        /// <summary>
        /// Gets the audit log repository.
        /// </summary>
        /// <value>
        /// The audit log repository.
        /// </value>
        private IRepository<AuditLog, int> AuditLogRepository
        {
            get { return DataContext.GetRepository<AuditLog, int>(); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        public AuditService(IUnityContainer unity, AuditRepositoryContext context)
            : base(unity, context)
        {
        }

        /// <summary>
        /// Adds the log.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <returns>
        /// Status.
        /// </returns>
        public bool AddLog(AuditLog log)
        {
            AuditLogRepository.Add(log);
            return (this.Save() > 0);
        }

    }
}
