namespace Models.Common.Shuffling;

internal class SequenceShuffle<T> : IEnumerator<T>
{
    public SequenceShuffle(IEnumerable<T> sequence)
    {
        this.Data = sequence.ToArray();
    }

    public T Current => this.Data[this.Position];

    private T[] Data { get; }
    private Random RandomNumbers { get; } = new Random(new Guid().GetHashCode());
    private int Position { get; set; } = -1;

    object? IEnumerator.Current => this.Current;

    public void Dispose() { }

    public bool MoveNext()
    {
        if (this.Position >= this.Data.Length - 1) return false;
        this.Position += 1;
        int pick = this.RandomNumbers.Next(this.Position, this.Data.Length);
        (Data[Position], Data[pick]) = (Data[pick], Data[Position]);
        return true;
    }

    public void Reset()
    {
        this.Position = -1;
    }
}