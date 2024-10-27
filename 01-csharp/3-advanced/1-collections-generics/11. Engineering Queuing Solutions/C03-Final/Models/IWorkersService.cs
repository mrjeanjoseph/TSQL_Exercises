using Models.Common.Caching;

namespace Models;

public interface IWorkersService
{
    IEnumerable<Worker> GetAll();
    Worker Find(Guid id);

    public IWorkersService Cached(int capacity) =>
        this is CachingWorkersService caching && caching.Capacity >= capacity ? this
        : new CachingWorkersService(this, capacity);
}