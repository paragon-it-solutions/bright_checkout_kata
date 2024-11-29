namespace Bright.Checkout.Extensions;

/// <summary>
///     Provides extension methods for console-related operations.
/// </summary>
public static class ConsoleExtensions
{
    /// <summary>
    ///     Reads a line from the console, trims any leading or trailing whitespace, and converts it to uppercase.
    /// </summary>
    /// <returns>
    ///     A string containing the line read from the console, trimmed and converted to uppercase.
    ///     If the input is null or empty, it returns an empty string.
    /// </returns>
    public static string GetCleanStringToUpper()
    {
        return Console.ReadLine()?.Trim().ToUpper() ?? string.Empty;
    }
}
