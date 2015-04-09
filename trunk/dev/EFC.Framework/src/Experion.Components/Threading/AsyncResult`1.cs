
namespace EFC.Components.Threading
{
    using System;

    /// <summary>
    /// The async result.
    /// </summary>
    /// <typeparam name="TData">The type of the data.</typeparam>
    public class AsyncResult<TData> : AsyncResult
    {
        #region Fields

        /// <summary>
        /// The data.
        /// </summary>
        private TData data;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>The data.</value>
        public TData Data
        {
            get { return this.data; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncResult&lt;TData&gt;"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        public AsyncResult(TData data, AsyncCallback callback, object state) : base(callback, state)
        {
            this.data = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncResult&lt;TData&gt;"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        public AsyncResult(AsyncCallback callback, object state) : this(default(TData), callback, state)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Completes this instance.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="synchronously"><c>True</c> if completed synchronously; otherwise, <c>False</c>.</param>
        protected void Complete(TData data, bool synchronously)
        {
            this.data = data;

            this.Complete(synchronously);
        }

        /// <summary>
        /// Completes this instance.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Complete(TData data)
        {
            this.Complete(data, false);
        }

        /// <summary>
        /// Ends the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>The data.</returns>
        public static new TData End(IAsyncResult result)
        {
            return End<AsyncResult<TData>>(result).Data;
        }

        #endregion
    }
}
