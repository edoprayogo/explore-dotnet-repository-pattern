using System.Globalization;

namespace explore_pattern.Domain.Helpers
{
    public static class MessageFormatter
    {

        /// <summary>
        /// Formats using a provided composite format string and arguments.
        /// </summary>
        /// <param name="format">Composite format string, e.g. "Not found: {0}".</param>
        /// <param name="args">Arguments to be applied to the format string.</param>
        /// <returns>Formatted string.</returns>
        public static string Format(string format, params object?[] args)
        {
            if (string.IsNullOrWhiteSpace(format))
                return string.Empty;

            return string.Format(CultureInfo.CurrentCulture, format, args);
        }

    }
}
