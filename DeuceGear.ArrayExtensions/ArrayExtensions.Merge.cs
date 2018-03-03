using System;
using System.Collections.Generic;

namespace DeuceGear
{
    public static partial class ArrayExtensions
    {
        /// <summary>
        /// Merges two 1-dimensional arrays together. 
        /// </summary>
        /// <param name="array">1-dimensional Array</param>
        /// <param name="arrayToAdd">1-dimensional Array to merge with</param>
        /// <returns>new 1-dimensional Array with all elements</returns>
        public static Array Merge(this Array array, Array arrayToAdd)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (array.Rank > 1)
                throw new ArgumentException("Only single rank arrays are supported");
            if (arrayToAdd == null)
                arrayToAdd = Array.CreateInstance(array.GetType().GetElementType(), 0);

            if (array.GetType().GetElementType() != arrayToAdd.GetType().GetElementType())
                throw new ArgumentException("Type mismatch between " + array.GetType().GetElementType() + " and " + arrayToAdd.GetType().GetElementType());

            var result = Array.CreateInstance(array.GetType().GetElementType(), array.Length + arrayToAdd.Length);
            if (array.Length > 0)
                array.CopyTo(result, 0);
            if (arrayToAdd.Length > 0)
                arrayToAdd.CopyTo(result, array.Length);
            return result;
        }

        /// <summary>
        /// Merges two 1-dimensional arrays together. 
        /// </summary>
        /// <typeparam name="T">element Type</typeparam>
        /// <param name="array">1-dimensional Array</param>
        /// <param name="arrayToAdd">1-dimensional Array to merge with</param>
        /// <returns>new 1-dimensional Array with all elements</returns>
        public static T[] Merge<T>(this T[] array, T[] arrayToAdd)
        {
            if (array == null)
                throw new ArgumentNullException("array");
            if (arrayToAdd == null)
                arrayToAdd = new T[0];

            var result = new T[array.Length + arrayToAdd.Length];
            if (array.Length > 0)
                array.CopyTo(result, 0);
            if (arrayToAdd.Length > 0)
                arrayToAdd.CopyTo(result, array.Length);
            return result;
        }
    }
}
