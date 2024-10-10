namespace Models.Collections;

public class DelegatingAccumulator<TItem, TValue> : IAccumulator<TItem, TValue>
{
    public DelegatingAccumulator(
        TValue seed,
        Func<TValue, TItem, TValue> add,
        Func<TValue, TItem, TValue> remove)
    {
        this.Value = seed;
        this.AddStrategy = add;
        this.RemoveStrategy = remove;
    }

    public void Add(TItem item) => this.Value = this.AddStrategy(this.Value, item);
    public void Remove(TItem item) => this.Value = this.RemoveStrategy(this.Value, item);

    public TValue Value { get; private set; }

    private Func<TValue, TItem, TValue> AddStrategy { get; }
    private Func<TValue, TItem, TValue> RemoveStrategy { get; }
}