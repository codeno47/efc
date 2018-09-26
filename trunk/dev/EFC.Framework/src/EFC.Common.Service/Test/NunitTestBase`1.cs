// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="NunitTestBase`1.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="NunitTestBase`1.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using Microsoft.Practices.Unity;
using NUnit.Framework;
using Rhino.Mocks;
using Unity;

namespace EFC.Common.Service.Test
{
    /// <summary>
    /// NunitTestBase.
    /// </summary>
    /// <typeparam name="TBusinessService">The type of the business service.</typeparam>
    public abstract class NunitTestBase<TBusinessService> where TBusinessService : BusinessService
    {
        #region Properties

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        protected IUnityContainer Container { get; set; }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        protected TBusinessService Service { get; set; }

        #endregion

        #region .ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="NunitTestBase{TBusinessService}"/> class.
        /// </summary>
        protected NunitTestBase()
        {
            Container = MockRepository.GenerateMock<IUnityContainer>();
        }

        #endregion

        #region Abstract

        /// <summary>
        /// Creates the test context.
        /// </summary>
        /// <returns></returns>
        protected abstract TBusinessService CreateTestContext();

        #endregion

        #region Overrides

        /// <summary>
        /// Executes Befores all test.
        /// </summary>
        [OneTimeSetUp]
        protected virtual void BeforeAllTest()
        {
            Service = CreateTestContext();
        }

        /// <summary>
        ///Executes Befores the test.
        /// </summary>
        [SetUp]
        protected virtual void BeforeTest()
        {

        }

        /// <summary>
        /// Executes Afters the test.
        /// </summary>
        [TearDown]
        protected virtual void AfterTest()
        {

        }

        /// <summary>
        /// Executes Afters all test.
        /// </summary>
        [OneTimeTearDown]
        protected virtual void AfterAllTest()
        {
            Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
        {

        }

        #endregion

    }
}
