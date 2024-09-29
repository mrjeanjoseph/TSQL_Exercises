using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Model;
using ProductImporter.Shared;
using ProductImporter.Target.EntityFramework;

namespace ProductImporter.Target;

public class SqlProductTarget : IProductTarget
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IImportStatistics _importStatistics;

    public SqlProductTarget(IServiceScopeFactory serviceScopeFactory, IImportStatistics importStatistics)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public void AddProduct(Product product)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<TargetContext>();

        _importStatistics.IncrementOutputCount();

        context.Products.Add(product);
        context.SaveChanges();
    }

    public void Close()
    {
        ;
    }

    public void Open()
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<TargetContext>();

        context.Database.EnsureCreated();
    }
}