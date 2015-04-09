// //----------------------------------------------------------------------------
// // <copyright company="Experion Global P Ltd" file ="ExtensionPoint.cs">
// // All rights reserved Copyright 2012-2013 Experion Global
// // This computer program may not be used, copied, distributed, corrected, modified,
// // translated, transmitted or assigned without Experion Global's prior written authorization
// // </copyright>
// // <summary>
// // The <see cref="ExtensionPoint.cs"/> file.
// // </summary>
// //---------------------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using EFC.Components.ComponentModel;
using EFC.Components.Events;
using Microsoft.Practices.Unity;

namespace EFC.Components.Extensibility
{
    /// <summary>
    /// The extension point.
    /// </summary>
    internal class ExtensionPoint : DisposableBase, IExtensionPoint
    {
        #region Fields

        /// <summary>
        /// The container.
        /// </summary>
        private readonly IUnityContainer container = new UnityContainer();

        #endregion

        #region Properties

        /// <summary>
        /// The name of the contract.
        /// </summary>
        private readonly string contractName;
        /// <summary>
        /// Gets the name of the contract.
        /// </summary>
        /// <value>The name of the contract.</value>
        public string ContractName
        {
            get
            {
                this.CheckDisposed();

                return contractName;
            }
        }

        /// <summary>
        /// The values.
        /// </summary>
        private IEnumerable<object> values = Enumerable.Empty<object>();
        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>The values.</value>
        public IEnumerable<object> Values
        {
            get
            {
                CheckDisposed();

                return values;
            }
            internal set
            {
                var e = new RecomposeEventArgs<object>(value.Except(values), values.Except(value));

                OnRecomposing(e);

                values = value;

                OnRecomposed(e);

                OnPropertyChanged("Values");
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when recomposing.
        /// </summary>
        public event EventHandler<RecomposeEventArgs<object>> Recomposing;

        /// <summary>
        /// Occurs when recomposed.
        /// </summary>
        public event EventHandler<RecomposeEventArgs<object>> Recomposed;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionPoint"/> class.
        /// </summary>
        /// <param name="contractName">Name of the contract.</param>
        internal ExtensionPoint(string contractName)
        {
            this.contractName = contractName;

            Initialize();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            container.RegisterInstance<IExtensionPoint>(this, new ExternallyControlledLifetimeManager());

            container.RegisterType(typeof(IExtensionPoint<>),new ContainerControlledLifetimeManager());
        }

        /// <summary>
        /// Returns the contract typed extension point.
        /// </summary>
        /// <typeparam name="TContract">The type of the contract.</typeparam>
        /// <returns>The contract typed extension point.</returns>
        public IExtensionPoint<TContract> AsContractTyped<TContract>()
        {
            CheckDisposed();

            return container.Resolve<IExtensionPoint<TContract>>();
        }

        /// <summary>
        /// Returns the contract typed extension point.
        /// </summary>
        /// <param name="contractType">Type of the contract.</param>
        /// <returns>The contract typed extension point.</returns>
        public object AsContractTyped(Type contractType)
        {
            //Requires.NotNull(contractType, "contractType");

            CheckDisposed();

            Type typeToResolve = typeof(IExtensionPoint<>).MakeGenericType(new Type[] { contractType });
            return container.Resolve(typeToResolve);
        }

        /// <summary>
        /// Raises the <see cref="E:Recomposing"/> event.
        /// </summary>
        /// <param name="e">The <see cref="object"/> instance containing the event data.</param>
        private void OnRecomposing(RecomposeEventArgs<object> e)
        {
            if (Recomposing != null)
            {
                Recomposing(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Recomposed"/> event.
        /// </summary>
        /// <param name="e">The <see cref="object"/> instance containing the event data.</param>
        private void OnRecomposed(RecomposeEventArgs<object> e)
        {
            if (Recomposed != null)
            {
                Recomposed(this, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
        public IEnumerator<object> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        /// <summary>
        /// Releases the unmanaged resources and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><c>True</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
       protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                container.Dispose();
            }
        }
    }
}
