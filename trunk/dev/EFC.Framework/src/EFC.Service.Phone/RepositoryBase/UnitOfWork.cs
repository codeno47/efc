// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="UnitOfWork.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="UnitOfWork.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using System.Data.Linq;
using System.Diagnostics;

namespace EFC.Service.Phone.RepositoryBase
{
    /// <summary>
    /// UnitOfWork.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public DataContext Context { get; private set; }

        /// <summary>
        /// Gets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The id.</param>
        public UnitOfWork(DataContext context, int id)
        {
            Id = id;
            Context = context;
            Context.DeferredLoadingEnabled = false;
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            Debug.Assert(Context != null, "Context != null");

            Context.SubmitChanges();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
                Context = null;
            }

            GC.SuppressFinalize(this);
        }
    }
}
