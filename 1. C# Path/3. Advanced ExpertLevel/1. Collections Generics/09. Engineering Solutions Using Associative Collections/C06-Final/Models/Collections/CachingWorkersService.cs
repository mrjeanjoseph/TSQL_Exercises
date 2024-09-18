using Models.Collections;

namespace Models;

public class CachingWorkersService : IWorkersService
{
    public CachingWorkersService(IWorkersService service, int capacity)
    {
        this.Service = service;
        this.Cache = new(capacity, this.Service.Find);
    }

    private IWorkersService Service { get; }
    private LruCache<Guid, Worker> Cache { get; }

    public int Capacity => this.Cache.Capacity;

    public IEnumerable<Worker> GetAll() => this.Service.GetAll();

    public Worker Find(Guid id) => this.Cache.Read(id);
}