namespace EFC.Components.Threading
{
    using System;
    using System.ComponentModel;

    using EFC.Components.Validations;

    /// <summary>
    /// Allows asynchronous execution of <see cref="Func{TResult}"/> operation.
    /// </summary>
    /// <typeparam name="TResult">Type of operation result.</typeparam>
    public class AsyncOperation<TResult>
    {
        #region Delegates

        /// <summary>
        /// Delegate, used to operation asynchronously.
        /// </summary>
        /// <param name="asyncOp">Asynchronous operation.</param>
        /// <param name="userOperation">User operation.</param>
        private delegate void WorkerEventHandler(AsyncOperation asyncOp, Func<TResult> userOperation);

        #endregion

        #region Events

        /// <summary>
        /// Event, raised when asynchronous operation completes.
        /// </summary>
        private event EventHandler<AsyncOperationCompletedEventArgs<TResult>> OnOperationCompleted;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncOperation{TResult}"/> class.
        /// </summary>
        /// <param name="operationCompletedHandler">Event handler for <see cref="OnOperationCompleted"/> event.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design",
            "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "Design concern")]
        public AsyncOperation(EventHandler<AsyncOperationCompletedEventArgs<TResult>> operationCompletedHandler)
        {
            Requires.NotNull(operationCompletedHandler, "operationCompletedHandler");

            this.OnOperationCompleted += operationCompletedHandler;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Callback method, executed when asynchronous operation completes.
        /// </summary>
        /// <param name="operationState">Operation state.</param>
        private void OperationCompleted(object operationState)
        {
            this.OnOperationCompleted(this, operationState as AsyncOperationCompletedEventArgs<TResult>);
        }

        /// <summary>
        /// Starts specified user operation asynchronously.
        /// </summary>
        /// <param name="userState">User state.</param>
        /// <param name="userOperation">User operation.</param>
        public void Start(object userState, Func<TResult> userOperation)
        {
            AsyncOperation asyncOperation = AsyncOperationManager.CreateOperation(userState);

            WorkerEventHandler workerDelegate = this.OperationWorker;
            workerDelegate.BeginInvoke(asyncOperation, userOperation, null, null);
        }

        /// <summary>
        /// Internal worker method to run user operation asynchronously.
        /// </summary>
        /// <param name="asyncOperation">Asynchronous operation.</param>
        /// <param name="userOperation">User operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031", Justification = "Design concern")]
        private void OperationWorker(AsyncOperation asyncOperation, Func<TResult> userOperation)
        {
            Exception e = null;
            TResult result = default(TResult);

            try
            {
                result = userOperation();
            }
            catch (Exception ex)
            {
                e = ex;
            }

            var ea = new AsyncOperationCompletedEventArgs<TResult>(result, e, false, asyncOperation.UserSuppliedState);
            asyncOperation.PostOperationCompleted(this.OperationCompleted, ea);
        }

        #endregion
    }
}
