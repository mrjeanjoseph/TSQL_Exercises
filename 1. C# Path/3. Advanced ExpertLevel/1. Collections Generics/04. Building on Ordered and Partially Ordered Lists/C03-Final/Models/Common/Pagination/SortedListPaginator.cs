namespace Models.Common.Pagination;

internal class SortedListPaginator<T> : IPaginated<T>
{
    public SortedListPaginator(IEnumerable<T> sequence, IComparer<T> comparer)
    {
        List<T> unsorted = new(sequence);
        this.SortedData = new(() => EnsureSorted(unsorted, comparer));
    }

    public IPage<T> this[int offset] => throw new NotImplementedException();

    public int PagesCount => throw new NotImplementedException();

    private Lazy<List<T>> SortedData { get; }
    private List<T> Items => this.SortedData.Value;

    private static List<T> EnsureSorted(List<T> data, IComparer<T> comparer)
    {
        data.Sort(comparer);
        return data;
    }

    public IEnumerator<IPage<T>> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}