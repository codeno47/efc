

namespace EFC.Components.Events
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a publication comparer.
    /// </summary>
    internal class PublicationComparerer : IEqualityComparer<Publication>
    {
        #region IEqualityComparer Members

        /// <summary>
        /// Checks equality of two publications.
        /// </summary>
        /// <param name="x">First publication.</param>
        /// <param name="y">Second publication.</param>
        /// <returns>Comparition result.</returns>
        public bool Equals(Publication x, Publication y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (!string.Equals(x.EventName, y.EventName))
            {
                return false;
            }
            if (x.IsAlive && y.IsAlive)
            {
                return ReferenceEquals(x.Publisher, y.Publisher);
            }
            return false;
        }

        /// <summary>
        /// GetHashCode overriding.
        /// </summary>
        /// <param name="obj">Publication.</param>
        /// <returns>Computed hash code.</returns>
        public int GetHashCode(Publication obj)
        {
            return obj.GetHashCode();
        }

        #endregion
    }
}
