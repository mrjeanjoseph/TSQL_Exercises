using Moq;
using ProductImporter.Logic.Shared;
using ProductImporter.Logic.Source;
using ProductImporter.Logic.Target;
using ProductImporter.Logic.Transformation;
using ProductImporter.Model;
using System.Threading.Tasks;
using Xunit;

namespace ProductImporter.Logic.Test
{
    public class ProductImporterTest
    {
        private readonly Mock<IProductSource> _productSource;
        private readonly Mock<IProductTransformer> _productTransformer;
        private readonly Mock<IProductTarget> _productTarget;
        private readonly Mock<IImportStatistics> _importStatistics;

        private readonly ProductImporter _subjectUnderTest;

        public ProductImporterTest()
        {
            _productSource = new Mock<IProductSource>();
            _productTransformer = new Mock<IProductTransformer>();
            _productTarget = new Mock<IProductTarget>();
            _importStatistics = new Mock<IImportStatistics>();

            _subjectUnderTest = new ProductImporter(_productSource.Object, _productTransformer.Object, _productTarget.Object, _importStatistics.Object);
        }
        

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public async Task WhenItReadsNProductsFromSource_ThenItWritesNProductsToTarget(int numberOfProducts)
        {
            var productCounter = 0;

            _productSource
                .Setup(x => x.hasMoreProducts())
                .Callback(() => productCounter++)
                .Returns(() => productCounter <= numberOfProducts);

            await _subjectUnderTest.RunAsync();

            _productTarget
                .Verify(x => x.AddProduct(It.IsAny<Product>()), Times.Exactly(numberOfProducts));
        }
    }
}