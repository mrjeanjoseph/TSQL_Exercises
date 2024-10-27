namespace Models.Collections;

public interface IAccumulator<in TItem, out TValue>
{
    void Add(TItem item);
    void Remove(TItem item);
    TValue Value { get; }
}