namespace ConsoleDemo;

internal static class Operators
{
    public static void WriteLines(this IEnumerable<string> lines)
    {
        foreach (string line in lines)
            Console.WriteLine(line);
    }

    public static void WriteLines<T>(this IEnumerable<T> items) =>
        items.Select(item => item?.ToString() ?? string.Empty).WriteLines();
}