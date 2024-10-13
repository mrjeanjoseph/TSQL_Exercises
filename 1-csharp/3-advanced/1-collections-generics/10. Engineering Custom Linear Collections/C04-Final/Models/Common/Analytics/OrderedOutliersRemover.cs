using Models.Collections;

namespace Models.Common.Analytics;

public class OrderedOutliersRemover<T> : IOutliersRemover<T>
{
    public OrderedOutliersRemover(IOrderedList<T> items)
    {
        this.Items = items;
    }

    private IOrderedList<T> Items { get; }

    public IEnumerable<T> RemoveOutliers(float relativeCount) =>
        this.RemoveOutliers(this.ToCount(relativeCount));

    private int ToCount(float relativeCount) =>
        (int)(this.Items.Count * relativeCount.FromClosedInterval(0, 1, nameof(relativeCount)));

    private IEnumerable<T> RemoveOutliers(int count) =>
        this.Items.GetRange(count / 2, this.Items.Count - count);
}
