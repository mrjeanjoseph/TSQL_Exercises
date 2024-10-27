namespace Models;

public class WorkItem
{
    public WorkItem(Money cost, Guid assignedToWorker)
    {
        this.Cost = cost;
        this.AssignedToWorker = assignedToWorker;
    }

    public Money Cost { get; }
    public Guid AssignedToWorker { get; }

    public override string ToString() =>
        $"Work {this.Cost} assigned to {this.AssignedToWorker}";
}