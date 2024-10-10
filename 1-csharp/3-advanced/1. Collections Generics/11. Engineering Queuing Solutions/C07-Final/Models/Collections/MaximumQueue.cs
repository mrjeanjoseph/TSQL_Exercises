namespace Models.Collections;

public class MaximumQueue<T> : IQueue<T>
{
    public MaximumQueue(IComparer<T> comparer)
    {
        this.Comparer = comparer;
    }

    private IComparer<T> Comparer { get; }

    public T Maximum =>
        !this.HasInput ? this.OutputMaximum
        : !this.HasOutput ? this.InputMaximum
        : this.Greater(this.InputMaximum, this.OutputMaximum);

    public int Count => this.InputStack.Count + this.OutputStack.Count;

    public void Enqueue(T item) => this.PushToInput(item);

    public T Dequeue() => this.PopFromOutput();

    public T Peek()
    {
        this.EnsureHasOutput();
        return this.OutputStack.Peek().value;
    }

    public IEnumerator<T> GetEnumerator() => throw new NotImplementedException();

    private Stack<T> InputStack { get; } = new();
    private bool HasInput => this.InputStack.Count > 0;

    private T _inputMaximum = default!;
    private T InputMaximum
    {
        get => this.HasInput ? this._inputMaximum : throw new InvalidOperationException();
        set => this._inputMaximum = value;
    }

    private Stack<(T value, T max)> OutputStack { get; } = new();
    private bool HasOutput => this.OutputStack.Count > 0;

    private T OutputMaximum =>
        this.HasOutput ? this.OutputStack.Peek().max
        : throw new InvalidOperationException();
    
    private T Greater(T a, T b) => this.Comparer.Compare(a, b) >= 0 ? a : b;

    private void PushToInput(T item)
    {
        this.InputMaximum = this.HasInput ? this.Greater(item, this.InputMaximum) : item;
        this.InputStack.Push(item);
    }

    private void EnsureHasOutput()
    {
        if (this.HasOutput) return;
        if (!this.HasInput) throw new InvalidOperationException();

        T max = this.InputStack.Pop();
        this.OutputStack.Push((max, max));

        while (this.InputStack.TryPop(out T? item) && item is not null)
        {
            max = this.Greater(item, max);
            this.OutputStack.Push((item, max));
        }
    }

    private T PopFromOutput()
    {
        this.EnsureHasOutput();
        return this.OutputStack.Pop().value;
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}