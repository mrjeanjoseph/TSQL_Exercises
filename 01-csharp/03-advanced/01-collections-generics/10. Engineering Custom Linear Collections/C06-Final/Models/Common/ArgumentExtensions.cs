namespace Models.Common;

public static class ArgumentExtensions
{
    public static string NonEmpty(this string value, string name) =>
        !string.IsNullOrWhiteSpace(value) ? value
        : throw new ArgumentException(name);

    public static decimal NonNegative(this decimal value, string name) =>
        value >= 0 ? value
        : throw new ArgumentException(name);

    public static decimal NonZero(this decimal value, string name) =>
        value != 0 ? value
        : throw new ArgumentException(name);

    public static float NonZero(this float value, string name) =>
        value != 0 ? value
        : throw new ArgumentException(name);

    public static float FromInterval(
        this float value, float inclusive, float exclusive, string name) =>
        value >= inclusive && value < exclusive ? value
        : throw new ArgumentException($"{name} is outside the interval [{inclusive}, {exclusive})");

    public static float FromClosedInterval(
        this float value, float lowerInclusive, float upperInclusive, string name) =>
        value >= lowerInclusive && value <= upperInclusive ? value
        : throw new ArgumentException($"{name} is outside the closed interval [{lowerInclusive}, {upperInclusive}]");

    public static int NonNegative(this int value, string name) =>
        value >= 0 ? value
        : throw new ArgumentException(name);

    public static int InRange(this int value, int minInclusive, int maxExclusive, string name) =>
        value >= minInclusive && value < maxExclusive ? value
        : throw new IndexOutOfRangeException($"'{name}' is outside of range {minInclusive} thru {maxExclusive - 1}.");

    public static TimeSpan NonZero(this TimeSpan value, string name) =>
        value > TimeSpan.Zero ? value
        : throw new ArgumentException(name);
}
