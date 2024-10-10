using Models.Collections;

namespace Models.Common.Analytics;

public class OrderedOutliersRemover<T> : IOutliersRemover<T>
{
    public OrderedOutliersRemover(IOrderedList<T> items)
    {
        this.Items = items;
    }

    private IOrderedList<T> Items { get; }

    IEnumerable<T> IOutliersRemover<T>.RemoveOutliers(float relativeCount) =>
        this.RemoveOutliers(relativeCount);

    public IOrderedList<T> RemoveOutliers(float relativeCount) =>
        this.RemoveOutliers(this.ToCount(relativeCount));

    private int ToCount(float relativeCount) =>
        (int)(this.Items.Count * relativeCount.FromClosedInterval(0, 1, nameof(relativeCount)));

    private IOrderedList<T> RemoveOutliers(int count) =>
        this.Items.GetRange(count / 2, this.Items.Count - count);
}
