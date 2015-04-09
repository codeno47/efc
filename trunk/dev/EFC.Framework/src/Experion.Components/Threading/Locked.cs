
using System.Threading;

namespace EFC.Components.Threading
{
    /// <summary>
    /// The locked value.
    /// </summary>
    public class Locked
    {
        #region Fields

        /// <summary>
        /// The value.
        /// </summary>
        private long value;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public long Value
        {
            get { return Interlocked.Read(ref value); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Locked"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Locked(long value)
        {
            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Locked"/> class.
        /// </summary>
        public Locked()
            : this(default(long))
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Switches to the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The original value.</returns>
        public long Switch(long value)
        {
            return Interlocked.Exchange(ref this.value, value);
        }

        /// <summary>
        /// Switches to the specified value if <paramref name="comparand"/> equals the current value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="comparand">The comparand.</param>
        /// <returns><c>True</c> if value has been switched; otherwise, <c>false</c>.</returns>
        public bool Switch(long value, long comparand)
        {
            return Interlocked.CompareExchange(ref this.value, value, comparand) == comparand;
        }

        #endregion
    }
}
