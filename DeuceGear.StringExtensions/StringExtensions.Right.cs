namespace DeuceGear
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Take the right x characters of a string if possible.
        /// If the string is to short, take what's there.
        /// </summary>
        /// <param name="string">string to take the right x characters from</param>
        /// <param name="length">amount of characters to take</param>
        /// <returns>
        /// If the string is null or empty, return string.Empty
        /// If the string is to short, return what's there
        /// If the amount is negative, return string.Empty
        /// Otherwise, return the x right characters
        /// </returns>
        public static string Right(this string @string, int length)
        {
            if (length < 0)
                return string.Empty;
            if (string.IsNullOrEmpty(@string))
                return string.Empty;
            if (@string.Length < length)
                return @string;
            return @string.Substring(@string.Length - length, length);
        }
    }
}
