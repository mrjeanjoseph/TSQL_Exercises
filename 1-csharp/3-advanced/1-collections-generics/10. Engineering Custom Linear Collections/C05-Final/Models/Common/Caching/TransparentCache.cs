namespace Models.Common.Caching;

public class TransparentCache<T> where T : IEquatable<T>
{
    private HashSet<T> KnownObjects { get; } = new();

    public T GetCached(T obj)
    {
        if (!this.KnownObjects.TryGetValue(obj, out T? result))
        {
            this.KnownObjects.Add(obj);
            result = obj;
        }
        return result;
    }

    public IEnumerable<T> GetCached(IEnumerable<T> items)
    {
        foreach (T item in items)
            yield return this.GetCached(item);
    }
}

public class TransparentCache
{
    private Dictionary<Type, object> KnownCaches { get; } = new();

    public T GetCached<T>(T item) where T : IEquatable<T> =>
        this.GetCache<T>().GetCached(item);
    
    public IEnumerable<T> GetCached<T>(IEnumerable<T> items) where T : IEquatable<T> =>
        items.Select(this.GetCached);
    
    private TransparentCache<T> GetCache<T>() where T : IEquatable<T>
    {
        if (this.KnownCaches.TryGetValue(typeof(T), out object? known) &&
            known is TransparentCache<T> existing)
            return existing;

        TransparentCache<T> cache = new();
        this.KnownCaches[typeof(T)] = cache;
        return cache;
    }
}