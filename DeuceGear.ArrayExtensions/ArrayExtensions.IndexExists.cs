using System;
using System.Collections.Generic;

namespace DeuceGear
{
    public static partial class ArrayExtensions
    {
        ///<summary>
        ///	Returns true if the given index is valid in the given dimension of the array.
        ///</summary>
        ///<param name="array">array to check agains</param>
        ///<param name="index">index to check</param>
        ///<param name="dimension">dimension to check</param>
        ///<returns>true if the given index is valid in the given dimension of the array.</returns>
        public static bool IndexExists(this Array array, int index, int dimension = 0)
        {
            // object check
            if (array == null)
                return false;
            // dimension check
            if (dimension < 0)
                return false;
            if (array.Rank <= dimension)
                return false;
            // index check
            return index >= array.GetLowerBound(dimension) && index <= array.GetUpperBound(dimension);
        }
    }
}
