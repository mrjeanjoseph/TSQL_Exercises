namespace Models.Collections;

public class WorkItemsTimeWindow
{
    public WorkItemsTimeWindow(TimeSpan interval)
    {
        this.Interval = interval;
        this.MoneySum = new DelegatingAccumulator<WorkItem, MoneyBag>(
            MoneyBag.Empty,
            (sum, item) => sum.Add(item.Cost),
            (sum, item) => sum.Subtract(item.Cost));
        this.Queue = new MaximumQueue<WorkItem>(
            Comparer<WorkItem>.Create((a, b) => a.Cost.CompareTo(b.Cost)));
        this.Window = new(this.Queue, this.ShouldRemoveHead, this.MoneySum);
    }

    private TimeSpan Interval { get; }
    private SlidingWindow<WorkItem> Window { get; }
    private IAccumulator<WorkItem, MoneyBag> MoneySum { get; }
    private MaximumQueue<WorkItem> Queue { get; }

    public void Add(WorkItem item) => this.Window.Append(item);
    public void SetCurrentTime(DateTime time) => this.Purge(time);

    public int Count => this.Window.Count;
    public MoneyBag TotalCost => this.MoneySum.Value;
    public WorkItem Maximum => this.Queue.Maximum;
    public WorkItem Head => this.Window.Head;
    public WorkItem Tail => this.Window.Tail;

    private bool ShouldRemoveHead(WorkItem head, WorkItem tail) =>
        this.ShouldRemoveHead(head, tail.AssignmentTime);
    
    private bool ShouldRemoveHead(WorkItem head, DateTime lastKnownTime) =>
        lastKnownTime - head.AssignmentTime >= this.Interval;
    
    private void Purge(DateTime lastKnownTime)
    {
        while (this.Count > 0 && this.ShouldRemoveHead(this.Head, lastKnownTime))
            this.Window.RemoveHead();
    }
}