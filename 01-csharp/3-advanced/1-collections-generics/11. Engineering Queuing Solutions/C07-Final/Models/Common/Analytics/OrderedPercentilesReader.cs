using Models.Collections;

namespace Models.Common.Analytics;

public class OrderedPercentilesReader<T> : IPercentilesReader<T>
{
    public OrderedPercentilesReader(IOrderedList<T> items)
    {
        this.Items = items;
    }

    private IOrderedList<T> Items { get; }

    public Percentile<T> GetPercentile(float position) =>
        new(position, this.Items[this.GetIndex(position)]);
    
    private int GetIndex(float percentile) =>
        (int)(percentile.FromInterval(inclusive: 0, exclusive: 1, nameof(percentile)) *
              this.Items.Count);
}