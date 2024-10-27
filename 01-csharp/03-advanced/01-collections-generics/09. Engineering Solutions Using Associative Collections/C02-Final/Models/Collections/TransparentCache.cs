namespace Models.Collections;

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
    public T GetCached<T>(T item) where T : IEquatable<T> =>
        throw new NotImplementedException();
}