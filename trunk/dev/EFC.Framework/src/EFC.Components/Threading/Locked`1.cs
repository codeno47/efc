// ----------------------------------------------------------------------------
// <copyright company="EFC" file ="Locked`1.cs">
// All rights reserved Copyright 2015  Enterprise Foundation Classes
// 
// </copyright>
//  <summary>
//  The <see cref="Locked`1.cs"/> file.
//  </summary>
//  ---------------------------------------------------------------------------------------------


namespace EFC.Components.Threading
{
    using System.Collections.Generic;

    using EFC.Components.Validations;

    /// <summary>
    /// The locked value.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    public class Locked<T>
    {
        #region Fields

        /// <summary>
        /// The access synchronization object.
        /// </summary>
        private readonly object syncObject = new object();

        /// <summary>
        /// The comparer.
        /// </summary>
        private readonly IEqualityComparer<T> comparer;

        /// <summary>
        /// The value.
        /// </summary>
        private T value;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public T Value
        {
            get
            {
                lock (this.syncObject)
                {
                    return this.value;
                }
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Locked&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="comparer">The comparer.</param>
        public Locked(T value, IEqualityComparer<T> comparer)
        {
            Requires.NotNull(comparer, "comparer");

            this.value = value;
            this.comparer = comparer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Locked&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Locked(T value) : this(value, EqualityComparer<T>.Default)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Locked&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public Locked(IEqualityComparer<T> comparer) : this(default(T), comparer)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Locked&lt;T&gt;"/> class.
        /// </summary>
        public Locked() : this(default(T))
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Switches to the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The original value.</returns>
        public T Switch(T value)
        {
            lock (this.syncObject)
            {
                T original = this.value;

                this.value = value;

                return original;
            }
        }

        /// <summary>
        /// Switches to the specified value if <paramref name="comparand"/> equals the current value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="comparand">The comparand.</param>
        /// <returns><c>True</c> if value has been switched; otherwise, <c>false</c>.</returns>
        public bool Switch(T value, T comparand)
        {
            lock (this.syncObject)
            {
                if (this.comparer.Equals(this.value, comparand))
                {
                    this.value = value;

                    return true;
                }

                return false;
            }
        }

        #endregion
    }
}
