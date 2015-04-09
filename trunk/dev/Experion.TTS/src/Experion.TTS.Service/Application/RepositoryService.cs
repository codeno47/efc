// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="RepositoryService.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="RepositoryService.cs"/> file.
// // </summary>
// // //---------------------------------------------------------------------------------------------

namespace Experion.TTS.Service.Application
{
    using System.Data;

    using EFC.Common.Service;
    using EFC.Components.Data;

    using Experion.TTS.Service.Model;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// Repository Application Service
    /// </summary>
    public class RepositoryService : ApplicationService<Entities>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        public RepositoryService(IUnityContainer unity, IRepositoryContext context)
            : base(unity, context)
        {
        }
        
        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>Return status</returns>
        public int Save()
        {
            try
            {
                return this.DataContext.Commit();
            }
            catch (DataException exception)
            {
                //this.DataContext.Rollback();
                return 0;
            }
        }

        /// <summary>
        /// Refreshes the context.
        /// </summary>
        public void RefreshContext()
        {
            this.DataContext.Refresh();
        }
    }
}
