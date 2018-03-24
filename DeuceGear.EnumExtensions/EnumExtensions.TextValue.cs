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
        /// Gets the first value defined using a <c>EnumTextValueAttribute</c>.
        /// </summary>
        /// <param name="@enum">Enum</param>
        /// <returns>
        /// Returns the defined string in the first <c>EnumTextValueAttribute</c>.
        /// If no attribute is defined, the ToString value is used.
        /// </returns>
        public static string TextValue(this Enum @enum)
        {
            if (@enum == null)
                return null;
            var possibleValues = TextValues(@enum);
            if (possibleValues.Count() >= 1)
                return possibleValues.ElementAt(0);
            return @enum.ToString();
        }

        /// <summary>
        /// Gets the first value defined using a <c>EnumTextValueAttribute</c>.
        /// </summary>
        /// <param name="@enum">SafeEnum</param>
        /// <returns>
        /// Returns the defined string in the first <c>EnumTextValueAttribute</c>.
        /// If no attribute is defined, the ToString value is used.
        /// </returns>
        public static string TextValue<T>(this SafeEnum<T> safeEnum)
            where T : struct, IConvertible
        {
            var possibleValues = TextValues(safeEnum);
            if (possibleValues.Count() >= 1)
                return possibleValues.ElementAt(0);
            return safeEnum.ToString();
        }
    }
}
