namespace Models.Common;

public static class Operators
{
    public static IEnumerable<T> Once<T>(this IEnumerable<T> sequence) =>
        new SinglePassSequence<T>(sequence);
}