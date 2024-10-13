using Models.Common.Formatting;
using Models.Common.Shuffling;
using Models.Common.Pagination;

namespace Models.Common;

public static class Operators
{
    public static IPaginated<T> Paginate<T>(
        this IEnumerable<T> sequence, IComparer<T> comparer, int pageSize) =>
        new SortedListPaginator<T>(sequence, comparer, pageSize);

    public static IEnumerable<T> Once<T>(this IEnumerable<T> sequence) =>
        new SinglePassSequence<T>(sequence);

    public static IEnumerable<string> ToGrid<T>(
        this IEnumerable<T> sequence, int width, int gap) =>
        new GridFormatter<T>(sequence).Format(width, gap);

    public static IEnumerator<T> BeginShuffle<T>(this IEnumerable<T> sequence) =>
        new SequenceShuffle<T>(sequence);

    public static IEnumerable<T> Iterate<T>(this IEnumerator<T> enumerator)
    {
        while (enumerator.MoveNext()) yield return enumerator.Current;
    }
}