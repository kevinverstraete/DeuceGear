using System;
using System.Text.RegularExpressions;

namespace DeuceGear
{
    /// <summary>
    /// Extension Methods for regularExpressions
    /// </summary>
    public static class RegexExtensions
    {
        /// <summary>
        /// Get a specific group value based on the name.
        /// </summary>
        /// <param name="match">match to search in</param>
        /// <param name="name">group name to search for</param>
        /// <returns>
        /// Value of the given group in the <c>Match</c>, if there is one
        /// </returns>
        public static string GetGroupValue(this Match match, string name)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            var group = match.Groups[name];
            if (group == null)
                return null;
            return group.Value;
        }
    }
}
