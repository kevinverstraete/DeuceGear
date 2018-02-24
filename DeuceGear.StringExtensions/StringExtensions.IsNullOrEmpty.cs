namespace DeuceGear
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Indicates whether the specified string is null or an System.String.Empty string. 
        /// </summary>
        /// <param name="string">The string to test</param>
        /// <returns>
        /// True if the value parameter is null or an empty string (""); otherwise, false.
        /// </returns>
        public static bool IsNullOrEmpty(this string @string)
        {
            return string.IsNullOrEmpty(@string);
        }
    }
}
