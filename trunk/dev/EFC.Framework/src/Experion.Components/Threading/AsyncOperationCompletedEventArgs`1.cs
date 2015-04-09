namespace EFC.Components.Threading
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Event args for asynchronous operation completed event.
    /// </summary>
    /// <typeparam name="TResult">Type of the operation result.</typeparam>
    public class AsyncOperationCompletedEventArgs<TResult> : AsyncCompletedEventArgs
    {
        #region Properties

        /// <summary>
        /// Gets the result of asynchronous operation.
        /// </summary>
        public TResult Result { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncOperationCompletedEventArgs{T}"/> class.
        /// </summary>
        /// <param name="result">Result of the operation.</param>
        /// <param name="error">Exception thrown by operation.</param>
        /// <param name="cancelled">Indicates if operation was cancelled.</param>
        /// <param name="userState">User state, passed to operation on start.</param>
        public AsyncOperationCompletedEventArgs(TResult result, Exception error, bool cancelled, object userState) : base(error, cancelled, userState)
        {
            this.Result = result;
        }

        #endregion
    }
}
