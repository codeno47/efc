// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="ApplicationService.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="ApplicationService.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System;
using System.Data.Linq;
using EFC.Service.Phone.RepositoryBase;
using Microsoft.Practices.Unity;

namespace EFC.Service.Phone
{
    /// <summary>
    /// ApplicationService base.
    /// </summary>
    public abstract class ApplicationService<TContext> where TContext : DataContext, IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unity.
        /// </summary>
        /// <value>
        /// The unity.
        /// </value>
        protected IUnityContainer Unity { get; set; }

        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        protected IRepositoryContext RepositoryContext { get; set; }

        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        protected LNQRepositoryContext<TContext> DataContext { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationService" /> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        /// <param name="context">The context.</param>
        protected ApplicationService(IUnityContainer unity, IRepositoryContext context)
        {
            Unity = unity;
            RepositoryContext = context;
            InitilizeContext();
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>Status code.</returns>
        protected void Save()
        {
            DataContext.DbContext.SubmitChanges();
        }
            
        /// <summary>
        /// Initilizes the context.
        /// </summary>
        private void InitilizeContext()
        {
            DataContext = RepositoryContext as LNQRepositoryContext<TContext>;

            if (DataContext == null)
            {
                throw new ArgumentException(string.Format("DataContext does not implement EFRepositoryContext"));
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            DataContext.DbContext.Dispose();
        }
    }
}
