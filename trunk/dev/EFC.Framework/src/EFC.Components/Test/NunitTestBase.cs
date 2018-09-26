// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="NunitTestBase.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="NunitTestBase.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------
using System;
using NUnit.Framework;
using Rhino.Mocks;
using Unity;

namespace EFC.Components.Test
{
    /// <summary>
    /// NunitTestBase.
    /// </summary>
    [TestFixture]
    public abstract class NunitTestBase : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        protected IUnityContainer Container { get; set; }


        #endregion

        #region .ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="NunitTestBase"/> class.
        /// </summary>
        protected NunitTestBase()
        {
            Container = MockRepository.GenerateMock<IUnityContainer>();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Executes Befores all test.
        /// </summary>
        [OneTimeSetUp]
        protected virtual void BeforeAllTest()
        {

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
