using System.Text.RegularExpressions;

namespace NetLs_Fedoriv
{
    /// <summary>
    /// Provides extension methods for string manipulation.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Removes extra spaces from a string by replacing consecutive spaces with a single space and trimming leading/trailing spaces.
        /// </summary>
        /// <param name="str">The input string.</param>
        /// <returns>The string with extra spaces removed.</returns>
        public static string RemoveExtraSpaces(this string str)
        {
            return Regex.Replace(str, @"\s+", " ").Trim();
        }
    }
}
