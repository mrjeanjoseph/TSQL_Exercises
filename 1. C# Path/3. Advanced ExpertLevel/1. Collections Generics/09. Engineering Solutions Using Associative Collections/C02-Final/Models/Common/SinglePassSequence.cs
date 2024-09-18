namespace Models.Common;

internal class SinglePassSequence<T> : IEnumerable<T>
{
    public SinglePassSequence(IEnumerable<T> other)
    {
        this.Sequence = other;
    }

    private IEnumerable<T> Sequence { get; }
    private bool Used { get; set; }

    public IEnumerator<T> GetEnumerator()
    {
        if (this.Used) throw new InvalidOperationException("Cannot reuse sequence");
        this.Used = true;
        return this.Sequence.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}