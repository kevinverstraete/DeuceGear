using System;
using System.Collections.Generic;

namespace DeuceGear
{
    public static partial class ArrayExtensions
    {
        ///<summary>
        ///	returns true if the array is null or has no elements.
        ///</summary>
        ///<param name="array">array to check agains</param>
        ///<returns>true if the array is null or has no elements.</returns>
        public static bool IsNullOrEmpty(this Array array)
        {
            return array == null || array.Length == 0;
        }
    }
}
