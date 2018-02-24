using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeuceGear
{
    /// <summary>
    /// EnumExtensions
    /// </summary>
    public static partial class EnumExtensions
    {
        /// <summary>
        /// Gets the first value defined using a <c>EnumValueAttribute</c>.
        /// </summary>
        /// <param name="@enum">Enum</param>
        /// <returns>
        /// Returns the defined string in the first <c>EnumValueAttribute</c>.
        /// If no attribute is defined, the ToString value is used.
        /// </returns>
        public static string Value(this Enum @enum)
        {
            if (@enum == null)
                return null;
            var possibleValues = Values(@enum);
            if (possibleValues.Count() >= 1)
                return possibleValues.ElementAt(0);
            return @enum.ToString();
        }
    }
}
