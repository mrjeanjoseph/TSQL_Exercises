namespace Models;

public interface IWorkItemsService
{
    IEnumerable<WorkItem> GetAll();
}