using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeuceGear
{
    /// <summary>
    /// EnumExtensions
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Get all the values defined in the enum using a <c>EnumValueAttribute</c>.
        /// </summary>
        /// <param name="@enum">Enum</param>
        /// <returns>
        /// Returns all defined string values using a <c>EnumValueAttribute</c>.
        /// </returns>
        public static IEnumerable<string> Values(this Enum @enum)
        {
            if (@enum == null)
                yield break;
            var info = @enum.GetType().GetField(@enum.ToString());
            if (info == null)
                yield break;
            var attributes = (EnumValueAttribute[])info.GetCustomAttributes(typeof(EnumValueAttribute), false);
            for (var i = 0; i < attributes.Length; i++)
            {
                yield return attributes[i].Value;
            }
        }

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
