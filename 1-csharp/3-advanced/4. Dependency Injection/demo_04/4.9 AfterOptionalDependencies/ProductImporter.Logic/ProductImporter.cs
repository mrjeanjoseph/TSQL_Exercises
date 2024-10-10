using Microsoft.Extensions.DependencyInjection;
using ProductImporter.Logic.Shared;
using ProductImporter.Logic.Source;
using ProductImporter.Logic.Target;
using ProductImporter.Logic.Transformation;

namespace ProductImporter.Logic;

public class ProductImporter
{
    private readonly IProductSource _productSource;
    private readonly IProductTarget _productTarget;
    private readonly IProductTransformer _productTransformer;
    private readonly IImportStatistics _importStatistics;

    public ProductImporter(
        IProductSource productSource, 
        IProductTransformer productTransformer,
        IProductTarget productTarget, 
        IImportStatistics importStatistics)
    {
        _productSource = productSource;
        _productTransformer = productTransformer;
        _productTarget = productTarget;
        _importStatistics = importStatistics;
    }

    public async Task RunAsync()
    {
        await _productSource.OpenAsync();

        _productTarget.Open();

        while (_productSource.hasMoreProducts())
        {
            var product = _productSource.GetNextProduct();

            var transformedProduct = _productTransformer.ApplyTransformations(product);

            _productTarget.AddProduct(transformedProduct);
        }

        _productSource.Close();
        _productTarget.Close();

        Console.WriteLine("Importing complete!");
        Console.WriteLine(_importStatistics.GetStatistics());
    }
}



// THIS IS THE FIRST EXAMPLE FROM THIS CLIP
//
//using Microsoft.Extensions.DependencyInjection;
//using ProductImporter.Logic.Shared;
//using ProductImporter.Logic.Source;
//using ProductImporter.Logic.Target;
//using ProductImporter.Logic.Transformation;

//namespace ProductImporter.Logic;

//public class ProductImporter
//{
//    private readonly IProductSource _productSource;
//    private readonly IProductTarget _productTarget;
//    private readonly IImportStatistics _importStatistics;
//    private readonly IServiceProvider _serviceProvider;

//    public ProductImporter(
//        IProductSource productSource,
//        IProductTarget productTarget,
//        IImportStatistics importStatistics,
//        IServiceProvider serviceProvider)
//    {
//        _productSource = productSource;
//        _productTarget = productTarget;
//        _importStatistics = importStatistics;
//        _serviceProvider = serviceProvider;
//    }

//    public async Task RunAsync()
//    {
//        await _productSource.OpenAsync();

//        _productTarget.Open();

//        while (_productSource.hasMoreProducts())
//        {
//            var product = _productSource.GetNextProduct();

//            var productTransformer = _serviceProvider.GetService<IProductTransformer>();

//            var transformedProduct = productTransformer == null
//                ? product
//                : productTransformer.ApplyTransformations(product);

//            _productTarget.AddProduct(transformedProduct);
//        }

//        _productSource.Close();
//        _productTarget.Close();

//        Console.WriteLine("Importing complete!");
//        Console.WriteLine(_importStatistics.GetStatistics());
//    }
//}