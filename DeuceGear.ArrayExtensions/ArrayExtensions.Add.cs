using System;
using System.Collections.Generic;

namespace DeuceGear
{
    public static partial class ArrayExtensions
    {
        /// <summary>
        /// Creates a new 1-dimensional array where the given element has been added.
        /// </summary>
        /// <typeparam name="T">element Type</typeparam>
        /// <param name="array">1-dimensional array</param>
        /// <param name="elementToAdd">element to add</param>
        /// <returns>new 1-dimensional array with element added</returns>
        public static Array Add<T>(this Array array, T elementToAdd)
        {
            return Merge(array, new[] { elementToAdd });
        }

        /// <summary>
        /// Creates a new 1-dimensional array where the given element has been added.
        /// </summary>
        /// <typeparam name="T">element Type</typeparam>
        /// <param name="array">1-dimensional array</param>
        /// <param name="elementToAdd">element to add</param>
        /// <returns>new 1-dimensional array with element added</returns>
        public static T[] Add<T>(this T[] array, T elementToAdd)
        {
            return Merge(array, new[] { elementToAdd });
        }
    }
}
