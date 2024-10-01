using System.Text;

namespace ProductImporter.Logic.Shared;

public class ImportStatistics : IGetImportStatistics, IWriteImportStatistics
{
    private int _productsImportedCount;
    private int _productsOutputtedCount;
    private int _productsTransformedCount;

    public void IncrementImportCount()
    {
        _productsImportedCount++;
    }

    public void IncrementOutputCount()
    {
        _productsOutputtedCount++;
    }

    public void IncrementTransformationCount()
    {
        _productsTransformedCount++;
    }

    public string GetStatistics()
    {
        var sb = new StringBuilder();
        sb.AppendFormat("Read a total of {0} products from source", _productsImportedCount);
        sb.AppendLine();
        sb.AppendFormat("Transformed a total of {0} products", _productsTransformedCount);
        sb.AppendLine();
        sb.AppendFormat("Written a total of {0} products to target", _productsOutputtedCount);

        return sb.ToString();
    }
}