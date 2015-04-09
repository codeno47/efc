

namespace EFC.Components.Diagnostic
{
    using System;

    /// <summary>
    /// The disposable helper class.
    /// </summary>
    public static class Disposable
    {
        #region Methods

        /// <summary>
        /// Disposes the specified component if component implements <see cref="T:System.IDisposable"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="component">The component to be disposed.</param>
        /// <returns><c>True</c> if the component was successfully disposed; otherwise, <c>False</c>.</returns>
        public static bool Dispose<T>(T component)
        {
            IDisposable disposable = component as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();

                return true;
            }

            return false;
        }

        #endregion
    }
}
