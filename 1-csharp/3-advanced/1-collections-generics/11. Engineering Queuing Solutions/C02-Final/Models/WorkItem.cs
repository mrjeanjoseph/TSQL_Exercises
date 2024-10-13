namespace Models;

public class WorkItem
{
    public WorkItem(Money cost, Guid assignedToWorker, DateTime assignmentTime)
    {
        this.Cost = cost;
        this.AssignedToWorker = assignedToWorker;
        this.AssignmentTime = assignmentTime;
    }

    public Money Cost { get; }
    public Guid AssignedToWorker { get; }
    public DateTime AssignmentTime { get; }

    public override string ToString() =>
        $"{this.AssignmentTime:HH:mm} work {this.Cost}";
}