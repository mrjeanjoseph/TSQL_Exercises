using Models.Common.Caching;

namespace Models.Common;

public static class TransparentCaching
{
    [ThreadStatic] private static TransparentCache _cache = new();

    public static T Cached<T>(this T item) where T : IEquatable<T> =>
        _cache.GetCached(item);

    public static IEnumerable<T> Cached<T>(this IEnumerable<T> items)
        where T : IEquatable<T> =>
        _cache.GetCached(items);
}