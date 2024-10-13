namespace Models;

public interface IWorkersService
{
    IEnumerable<Worker> GetAll();
    Worker Find(Guid id);
}