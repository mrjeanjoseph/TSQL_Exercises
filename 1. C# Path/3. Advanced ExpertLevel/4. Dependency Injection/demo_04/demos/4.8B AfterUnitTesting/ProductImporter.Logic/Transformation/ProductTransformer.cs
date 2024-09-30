using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Model;
using ProductImporter.Logic.Shared;
using ProductImporter.Logic.Transformations;
using ProductImporter.Transformations;

namespace ProductImporter.Logic.Transformation;

public class ProductTransformer : IProductTransformer
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IImportStatistics _importStatistics;

    public ProductTransformer(IServiceScopeFactory serviceScopeFactory, IImportStatistics importStatistics)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _importStatistics = importStatistics;
    }

    public Product ApplyTransformations(Product product)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var transformationContext = scope.ServiceProvider.GetRequiredService<IProductTransformationContext>();
        transformationContext.SetProduct(product);

        var productTransformers = scope.ServiceProvider.GetRequiredService<IEnumerable<IProductTransformation>>();

        Thread.Sleep(2000);

        foreach(var productTransformer in productTransformers)
        {
            productTransformer.Execute();
        }

        if (transformationContext.IsProductChanged())
        {
            _importStatistics.IncrementTransformationCount();
        }

        return transformationContext.GetProduct();
    }
}
