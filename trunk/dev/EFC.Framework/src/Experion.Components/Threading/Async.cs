

namespace EFC.Components.Threading
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    using EFC.Components.Exception;
    using EFC.Components.Validations;

    #region Delegates

    /// <summary>
    /// The async begin delegate.
    /// </summary>
    /// <param name="callback">The callback.</param>
    /// <param name="state">The state.</param>
    /// <returns>The async result.</returns>
    public delegate IAsyncResult AsyncBegin(AsyncCallback callback, object state);

    /// <summary>
    /// The async end delegate.
    /// </summary>
    /// <param name="result">The async result.</param>
    public delegate void AsyncEnd(IAsyncResult result);

    /// <summary>
    /// The async end delegate.
    /// </summary>
    /// <typeparam name="T">The type of the operation result.</typeparam>
    /// <param name="result">The async result.</param>
    /// <returns>The operation result.</returns>
    public delegate T AsyncEnd<T>(IAsyncResult result);

    #endregion

    /// <summary>
    /// The async helper class.
    /// </summary>
    public static class Async
    {
        #region Methods

        /// <summary>
        /// Begins the wrapped operation.
        /// </summary>
        /// <param name="begin">The begin.</param>
        /// <param name="end">The end.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        /// <returns>The async result.</returns>
        public static IAsyncResult BeginWrap(AsyncBegin begin, AsyncEnd end, AsyncCallback callback, object state)
        {
            Requires.NotNull(begin, "begin");
            Requires.NotNull(end, "end");

            return new AsyncResultWrapper(begin, end, callback, state);
        }

        /// <summary>
        /// Begins the wrapped operation.
        /// </summary>
        /// <typeparam name="T">The type of the operation result.</typeparam>
        /// <param name="begin">The begin.</param>
        /// <param name="end">The end.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        /// <returns>The async result.</returns>
        public static IAsyncResult BeginWrap<T>(AsyncBegin begin, AsyncEnd<T> end, AsyncCallback callback, object state)
        {
            Requires.NotNull(begin, "begin");
            Requires.NotNull(end, "end");

            return new AsyncResultWrapper<T>(begin, end, callback, state);
        }

        /// <summary>
        /// Ends the wrapped operation.
        /// </summary>
        /// <param name="result">The result.</param>
        public static void EndWrap(IAsyncResult result)
        {
            Requires.NotNull(result, "result");

            AsyncResultWrapper wrapper = result as AsyncResultWrapper;
            if (wrapper == null)
            {
                throw ExceptionBuilder.ArgumentNotExpectedType("result", typeof(AsyncResultWrapper));
            }

            wrapper.End();
        }

        /// <summary>
        /// Ends the wrapped operation.
        /// </summary>
        /// <typeparam name="T">The type of the operation result.</typeparam>
        /// <param name="result">The result.</param>
        /// <returns>The operation result.</returns>
        public static T EndWrap<T>(IAsyncResult result)
        {
            Requires.NotNull(result, "result");

            AsyncResultWrapper<T> wrapper = result as AsyncResultWrapper<T>;
            if (wrapper == null)
            {
                throw ExceptionBuilder.ArgumentNotExpectedType("result", typeof(AsyncResultWrapper<T>));
            }

            return wrapper.End();
        }

        /// <summary>
        /// Begins the queued operation.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        /// <param name="args">The args.</param>
        /// <returns>The async result.</returns>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Wraps all exceptions that can ocour during asynchronous operation.")]
        public static IAsyncResult BeginQueue(Delegate method, AsyncCallback callback, object state, params object[] args)
        {
            Requires.NotNull(method, "method");

            AsyncResult<object> result = new AsyncResult<object>(callback, state);

            ThreadPool.QueueUserWorkItem(s =>
            {
                try
                {
                    object value = method.DynamicInvoke(args);

                    result.Complete(value);
                }
                catch (Exception e)
                {
                    result.Complete(e);
                }
            });

            return result;
        }

        /// <summary>
        /// Ends the queued operation.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>The operation result.</returns>
        public static object EndQueue(IAsyncResult result)
        {
            return AsyncResult<object>.End(result);
        }

        #endregion

        #region Nested types

        /// <summary>
        /// The async result wrapper.
        /// </summary>
        private class AsyncResultWrapper : IAsyncResult
        {
            #region Fields

            /// <summary>
            /// The async result.
            /// </summary>
            private readonly IAsyncResult result;

            /// <summary>
            /// The end.
            /// </summary>
            private readonly AsyncEnd end;

            /// <summary>
            /// The callback.
            /// </summary>
            private readonly AsyncCallback callback;

            /// <summary>
            /// The state.
            /// </summary>
            private readonly object state;

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
                get { return this.result.AsyncWaitHandle; }
            }

            /// <summary>
            /// Gets a value that indicates whether the asynchronous operation completed synchronously.
            /// </summary>
            /// <value><c>True</c> if the asynchronous operation completed synchronously; otherwise, <c>False</c>.</value>
            public bool CompletedSynchronously
            {
                get { return this.result.CompletedSynchronously; }
            }

            /// <summary>
            /// Gets a value that indicates whether the asynchronous operation has completed.
            /// </summary>
            /// <value><c>True</c> if the operation is complete; otherwise, <c>False</c>.</value>
            public bool IsCompleted
            {
                get { return this.result.IsCompleted; }
            }

            #endregion

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="AsyncResultWrapper"/> class.
            /// </summary>
            /// <param name="begin">The begin.</param>
            /// <param name="end">The end.</param>
            /// <param name="callback">The callback.</param>
            /// <param name="state">The state.</param>
            internal AsyncResultWrapper(AsyncBegin begin, AsyncEnd end, AsyncCallback callback, object state)
            {
                this.end = end;
                this.callback = callback;
                this.state = state;

                this.result = begin(this.OnCompleted, null);
            }

            #endregion

            #region Methods

            /// <summary>
            /// Called when completed.
            /// </summary>
            /// <param name="result">The result.</param>
            private void OnCompleted(IAsyncResult result)
            {
                if (this.callback != null)
                {
                    this.callback(this);
                }
            }

            /// <summary>
            /// Ends this instance.
            /// </summary>
            internal void End()
            {
                this.end(this.result);
            }

            #endregion
        }

        /// <summary>
        /// The async result wrapper.
        /// </summary>
        /// <typeparam name="T">The type of the operation result.</typeparam>
        private class AsyncResultWrapper<T> : IAsyncResult
        {
            #region Fields

            /// <summary>
            /// The async result.
            /// </summary>
            private readonly IAsyncResult result;

            /// <summary>
            /// The end.
            /// </summary>
            private readonly AsyncEnd<T> end;

            /// <summary>
            /// The callback.
            /// </summary>
            private readonly AsyncCallback callback;

            /// <summary>
            /// The state.
            /// </summary>
            private readonly object state;

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
                get { return this.result.AsyncWaitHandle; }
            }

            /// <summary>
            /// Gets a value that indicates whether the asynchronous operation completed synchronously.
            /// </summary>
            /// <value><c>True</c> if the asynchronous operation completed synchronously; otherwise, <c>False</c>.</value>
            public bool CompletedSynchronously
            {
                get { return this.result.CompletedSynchronously; }
            }

            /// <summary>
            /// Gets a value that indicates whether the asynchronous operation has completed.
            /// </summary>
            /// <value><c>True</c> if the operation is complete; otherwise, <c>False</c>.</value>
            public bool IsCompleted
            {
                get { return this.result.IsCompleted; }
            }

            #endregion

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="AsyncResultWrapper"/> class.
            /// </summary>
            /// <param name="begin">The begin.</param>
            /// <param name="end">The end.</param>
            /// <param name="callback">The callback.</param>
            /// <param name="state">The state.</param>
            internal AsyncResultWrapper(AsyncBegin begin, AsyncEnd<T> end, AsyncCallback callback, object state)
            {
                this.end = end;
                this.callback = callback;
                this.state = state;

                this.result = begin(this.OnCompleted, null);
            }

            #endregion

            #region Methods

            /// <summary>
            /// Called when completed.
            /// </summary>
            /// <param name="result">The result.</param>
            private void OnCompleted(IAsyncResult result)
            {
                if (this.callback != null)
                {
                    this.callback(this);
                }
            }

            /// <summary>
            /// Ends this instance.
            /// </summary>
            /// <returns>The operation result.</returns>
            internal T End()
            {
                return this.end(this.result);
            }

            #endregion
        }

        #endregion
    }
}
