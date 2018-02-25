using System;

namespace DeuceGear
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Take the left x characters of a string if possible
        /// If the string is to short, take what's there.
        /// </summary>
        /// <param name="string">string to take the left x characters from</param>
        /// <param name="length">amount of characters to take</param>
        /// <returns>
        /// If the string is null or empty, return string.Empty
        /// If the string is to short, return what's there
        /// Otherwise, return the x left characters
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when Length is a negative value</exception>
        public static string Left(this string @string, int length)
        {
            if (length < 0)
                throw new ArgumentException("Length can not be a negative value");
            if (length == 0)
                return string.Empty;
            if (string.IsNullOrEmpty(@string))
                return string.Empty;
            if (@string.Length < length)
                return @string;
            return @string.Substring(0, length);
        }
    }
}
