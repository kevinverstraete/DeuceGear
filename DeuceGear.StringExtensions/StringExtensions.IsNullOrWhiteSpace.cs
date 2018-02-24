namespace DeuceGear
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Indicates whether a specified string is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="string">The string to test</param>
        /// <returns>
        /// True if the value parameter is null or System.String.Empty, or if value consists
        /// exclusively of white-space characters.
        /// </returns>
        public static bool IsNullOrWhiteSpace(this string @string)
        {
            return string.IsNullOrWhiteSpace(@string);
        }
    }
}
