using Models.Common.Formatting;
using Models.Common.Shuffling;
using Models.Common.Pagination;
using Models.Common.Caching;
using Models.Collections;
using Models.Common.Analytics;

namespace Models.Common;

public static class Operators
{
    public static IOrderedList<T> RemoveOutliers<T>(
        this IOrderedList<T> list, float relativeCount) =>
        new OrderedOutliersRemover<T>(list).RemoveOutliers(relativeCount);

    public static (T min, T max) GetExtremes<T>(
        this IEnumerable<T> sequence, IComparer<T> comparer)
    {
        using IEnumerator<T> item = sequence.GetEnumerator();

        if (!item.MoveNext()) throw new ArgumentException("Sequence contains no elements");
        (T min, T max) = (item.Current, item.Current);

        while (item.MoveNext())
        {
            if (comparer.Compare(item.Current, min) < 0)
                min = item.Current;
            else if (comparer.Compare(item.Current, max) > 0)
                max = item.Current;
        }

        return (min, max);
    }

    public static IEnumerable<Percentile<T>> GetPercentiles<T>(
        this IOrderedList<T> list, float start, float step)
    {
        start = start.FromInterval(inclusive: 0, exclusive: 1, nameof(start));
        step = step.NonZero(nameof(step));
        IPercentilesReader<T> reader = new OrderedPercentilesReader<T>(list);
        for (float pos = start; pos >= 0 && pos < 1; pos += step)
            yield return reader.GetPercentile(pos);
    }

    public static IEnumerable<Percentile<T>> GetExtremesAndPercentiles<T>(
        this IOrderedList<T> list, float start, float step)
    {
        if (start > 0 && list.Count > 0) yield return new(0, list[0]);
        foreach (var percentile in list.GetPercentiles(start, step))
            yield return percentile;
        if (list.Count > 0) yield return new(1, list[^1]);
    }

    public static IEnumerable<T> ShareRepeated<T>(this IEnumerable<T> items)
        where T : IEquatable<T> =>
        new TransparentCache<T>().GetCached(items);

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