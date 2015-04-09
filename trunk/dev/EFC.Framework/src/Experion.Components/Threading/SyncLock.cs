

namespace EFC.Components.Threading
{
    using System;
    using System.Threading;

    using EFC.Components.ComponentModel;
    using EFC.Components.Validations;

    /// <summary>
    /// The synchronization lock.
    /// </summary>
    public class SyncLock : DisposableBase
    {
        #region Fields

        /// <summary>
        /// The sync lock.
        /// </summary>
        private readonly ReaderWriterLockSlim syncLock;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SyncLock"/> class.
        /// </summary>
        /// <param name="syncLock">The sync lock.</param>
        protected SyncLock(ReaderWriterLockSlim syncLock)
        {
            Requires.NotNull(syncLock, "syncLock");

            this.syncLock = syncLock;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SyncLock"/> class.
        /// </summary>
        /// <param name="recursionPolicy">The recursion policy.</param>
        public SyncLock(LockRecursionPolicy recursionPolicy) : this(new ReaderWriterLockSlim(recursionPolicy))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SyncLock"/> class.
        /// </summary>
        public SyncLock() : this(new ReaderWriterLockSlim())
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Uses the reader.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="reader">The reader.</param>
        /// <returns>The result.</returns>
        public TResult UseReader<TResult>(Func<TResult> reader)
        {
            Requires.NotNull(reader, "reader");

            this.CheckDisposed();

            this.syncLock.EnterReadLock();

            try
            {
                return reader();
            }
            finally
            {
                this.syncLock.ExitReadLock();
            }
        }

        /// <summary>
        /// Uses the reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        public void UseReader(Action reader)
        {
            Requires.NotNull(reader, "reader");

            this.CheckDisposed();

            this.syncLock.EnterReadLock();

            try
            {
                reader();
            }
            finally
            {
                this.syncLock.ExitReadLock();
            }
        }

        /// <summary>
        /// Uses the upgradeable reader.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="reader">The reader.</param>
        /// <returns>The result.</returns>
        public TResult UseUpgradeableReader<TResult>(Func<TResult> reader)
        {
            Requires.NotNull(reader, "reader");

            this.CheckDisposed();

            this.syncLock.EnterUpgradeableReadLock();

            try
            {
                return reader();
            }
            finally
            {
                this.syncLock.ExitUpgradeableReadLock();
            }
        }

        /// <summary>
        /// Uses the upgradeable reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        public void UseUpgradeableReader(Action reader)
        {
            Requires.NotNull(reader, "reader");

            this.CheckDisposed();

            this.syncLock.EnterUpgradeableReadLock();

            try
            {
                reader();
            }
            finally
            {
                this.syncLock.ExitUpgradeableReadLock();
            }
        }

        /// <summary>
        /// Uses the writer.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="writer">The writer.</param>
        /// <returns>The result.</returns>
        public TResult UseWriter<TResult>(Func<TResult> writer)
        {
            Requires.NotNull(writer, "writer");

            this.CheckDisposed();

            this.syncLock.EnterWriteLock();

            try
            {
                return writer();
            }
            finally
            {
                this.syncLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Uses the writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        public void UseWriter(Action writer)
        {
            Requires.NotNull(writer, "writer");

            this.CheckDisposed();

            this.syncLock.EnterWriteLock();

            try
            {
                writer();
            }
            finally
            {
                this.syncLock.ExitWriteLock();
            }
        }

        /// <summary>
        /// Releases the unmanaged resources and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><c>True</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.syncLock.Dispose();
            }
        }

        #endregion
    }
}
