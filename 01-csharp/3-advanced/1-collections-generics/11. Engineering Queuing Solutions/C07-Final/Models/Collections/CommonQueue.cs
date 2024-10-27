namespace Models.Collections;

public class CommonQueue<T> : IQueue<T>
{
    private Queue<T> Queue { get; } = new();

    public int Count => this.Queue.Count;
    public void Enqueue(T item) => this.Queue.Enqueue(item);
    public T Dequeue() => this.Queue.Dequeue();
    public T Peek() => this.Queue.Peek();

    public IEnumerator<T> GetEnumerator() => this.Queue.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
