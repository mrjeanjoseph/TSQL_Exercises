using System.Text;

namespace ProductImporter.Shared;

public class ImportStatistics : IImportStatistics
{
    private int _productsImportedCount;
    private int _productsOutputtedCount;

    public void IncrementImportCount()
    {
        _productsImportedCount++;
    }

    public void IncrementOutputCount()
    {
        _productsOutputtedCount++;
    }

    public string GetStatistics()
    {
        var sb = new StringBuilder();
        sb.AppendFormat("Read a total of {0} products from source", _productsImportedCount);
        sb.AppendLine();
        sb.AppendFormat("Written a total of {0} products to target", _productsOutputtedCount);

        return sb.ToString();
    }
}