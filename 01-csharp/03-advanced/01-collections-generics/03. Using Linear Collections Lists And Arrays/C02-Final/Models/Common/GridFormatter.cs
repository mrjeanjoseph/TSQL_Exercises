namespace Models.Common;

public class GridFormatter<T>
{
    public GridFormatter(IEnumerable<T> data)
    {
        this.Data = new List<T>(data);
    }

    private IList<T> Data { get; }

    public IEnumerable<string> Format() => Enumerable.Empty<string>();
}