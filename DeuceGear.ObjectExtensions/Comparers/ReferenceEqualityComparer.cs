using System.Collections.Generic;

namespace DeuceGear.Comparers
{
    internal class ReferenceEqualityComparer : EqualityComparer<object>
    {
        /// <summary>
        /// Determines whether two objects have the same reference.
        /// </summary>
        /// <param name="x">The first object to compare</param>
        /// <param name="y">The second object to compare</param>
        /// <returns></returns>
        public override bool Equals(object x, object y)
        {
            return ReferenceEquals(x, y);
        }
        /// <summary>
        /// Serves as a hash function for the specified
        ///     object for hashing algorithms and data structures, such as a hash table.
        /// </summary>
        /// <param name="obj">The object for which to get a hash code.</param>
        /// <returns>A hash code for the specified object.</returns>
        public override int GetHashCode(object obj)
        {
            if (obj == null) return 0;
            return obj.GetHashCode();
        }
    }
}
