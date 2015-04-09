namespace EFC.Components.Threading
{
    using System;
    using System.Threading;

    using EFC.Components.Diagnostic;
    using EFC.Components.Exception;
    using EFC.Components.Validations;

    /// <summary>
    /// The async result.
    /// </summary>
    public class AsyncResult : IAsyncResult, IDisposable
    {
        #region Fields

        /// <summary>
        /// The access synchronization object.
        /// </summary>
        private readonly object syncObject = new object();

        /// <summary>
        /// The complete state.
        /// </summary>
        private readonly Locked complete = new Locked();

        /// <summary>
        /// The end state.
        /// </summary>
        private readonly Locked end = new Locked();

        /// <summary>
        /// The callback.
        /// </summary>
        private readonly AsyncCallback callback;

        /// <summary>
        /// The state.
        /// </summary>
        private readonly object state;

        /// <summary>
        /// The handle.
        /// </summary>
        private EventWaitHandle handle;

        /// <summary>
        /// The exception.
        /// </summary>
        private Exception exception;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a user-defined object that qualifies or contains information about an asynchronous operation.
        /// </summary>
        /// <value>A user-defined object that qualifies or contains information about an asynchronous operation.</value>
        public object AsyncState
        {
            get { return this.state; }
        }

        /// <summary>
        /// Gets a <see cref="T:System.Threading.WaitHandle"/> that is used to wait for an asynchronous operation to complete.
        /// </summary>
        /// <value>A <see cref="T:System.Threading.WaitHandle"/> that is used to wait for an asynchronous operation to complete.</value>
        public WaitHandle AsyncWaitHandle
        {
            get
            {
                if (this.handle == null)
                {
                    lock (this.syncObject)
                    {
                        if (this.handle == null)
                        {
                            this.handle = new ManualResetEvent(this.IsCompleted);
                        }
                    }
                }

                return this.handle;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the asynchronous operation completed synchronously.
        /// </summary>
        /// <value><c>True</c> if the asynchronous operation completed synchronously; otherwise, <c>False</c>.</value>
        public bool CompletedSynchronously
        {
            get { return this.complete.Value == 1; }
        }

        /// <summary>
        /// Gets a value that indicates whether the asynchronous operation has completed.
        /// </summary>
        /// <value><c>True</c> if the operation is complete; otherwise, <c>False</c>.</value>
        public bool IsCompleted
        {
            get { return this.complete.Value != 0; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncResult"/> class.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        public AsyncResult(AsyncCallback callback, object state)
        {
            this.callback = callback;
            this.state = state;
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the object is reclaimed by garbage collection.
        /// </summary>
        ~AsyncResult()
        {
            this.Dispose(false);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Completes this instance.
        /// </summary>
        /// <param name="synchronously"><c>True</c> if completed synchronously; otherwise, <c>False</c>.</param>
        protected void Complete(bool synchronously)
        {
            if (synchronously ? !this.complete.Switch(1, 0) : !this.complete.Switch(2, 0))
            {
                throw ExceptionBuilder.InvalidOperation(Messages.AsyncCompleted);
            }

            if (this.handle != null)
            {
                this.handle.Set();
            }

            if (this.callback != null)
            {
                this.callback(this);
            }
        }

        /// <summary>
        /// Completes this instance.
        /// </summary>
        /// <param name="synchronously"><c>True</c> if completed synchronously; otherwise, <c>False</c>.</param>
        /// <param name="exception">The exception.</param>
        protected void Complete(bool synchronously, Exception exception)
        {
            this.exception = exception;

            this.Complete(synchronously);
        }

        /// <summary>
        /// Completes this instance.
        /// </summary>
        public void Complete()
        {
            this.Complete(false);
        }

        /// <summary>
        /// Completes this instance.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void Complete(Exception exception)
        {
            this.Complete(false, exception);
        }

        /// <summary>
        /// Ends this instance.
        /// </summary>
        private void End()
        {
            if (!this.end.Switch(1, 0))
            {
                throw ExceptionBuilder.InvalidOperation(Messages.AsyncEnded);
            }

            if (!this.IsCompleted)
            {
                this.AsyncWaitHandle.WaitOne();

                this.AsyncWaitHandle.Close();

                this.handle = null;
            }

            if (this.exception != null)
            {
                throw this.exception;
            }
        }

        /// <summary>
        /// Ends the specified result.
        /// </summary>
        /// <typeparam name="TAsyncResult">The type of the async result.</typeparam>
        /// <param name="result">The result.</param>
        /// <returns>The async result.</returns>
        protected static TAsyncResult End<TAsyncResult>(IAsyncResult result) where TAsyncResult : AsyncResult
        {
            Requires.NotNull(result, "result");

            TAsyncResult asyncResult = result as TAsyncResult;
            if (asyncResult == null)
            {
                throw ExceptionBuilder.ArgumentNotExpectedType("result", typeof(TAsyncResult));
            }

            asyncResult.End();

            return asyncResult;
        }

        /// <summary>
        /// Ends the specified result.
        /// </summary>
        /// <param name="result">The result.</param>
        public static void End(IAsyncResult result)
        {
            End<AsyncResult>(result);
        }

        /// <summary>
        /// Releases the unmanaged and managed resources.
        /// </summary>
        void IDisposable.Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><c>True</c> to release both managed and unmanaged resources; <c>False</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Disposable.Dispose(this.handle);
            }
        }

        #endregion
    }
}
