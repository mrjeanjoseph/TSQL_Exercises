namespace Models.Collections;

public class OrderedListProjection<T> : IOrderedList<T>
{
    public OrderedListProjection(IOrderedList<T> list, int offset, int count)
    {
        this.List = list;
        this.Offset = offset.NonNegative(nameof(offset));
        this.MaximumCount = count.NonNegative(nameof(count));
    }

    public T this[int index] => 
        this.List[this.Offset + index.InRange(0, this.Count, nameof(index))];

    private int Offset { get; }
    private int ExclusiveEndOffset => this.Offset + this.Count;
    private int MaximumCount { get; }
    public int Count => Math.Max(Math.Min(this.MaximumCount, this.List.Count - this.Offset), 0);

    private IOrderedList<T> List { get; }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Offset; i < this.ExclusiveEndOffset; i++)
            yield return this.List[i];
    }

    public IOrderedList<T> GetRange(int index, int count) =>
        new OrderedListProjection<T>(
            this.List, this.Offset + index.NonNegative(nameof(index)),
            Math.Max(Math.Min(this.MaximumCount - index, count.NonNegative(nameof(count))), 0));

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}