namespace Models.Collections;

public interface IOrderedList<out T> : IReadOnlyList<T>
{
    IOrderedList<T> GetRange(int index, int count);
}