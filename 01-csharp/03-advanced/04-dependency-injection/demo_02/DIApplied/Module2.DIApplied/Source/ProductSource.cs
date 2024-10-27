using Microsoft.VisualBasic.FileIO;
using Module2.DIApplied.Model;
using Module2.DIApplied.Shared;

namespace Module2.DIApplied.Source;

public class ProductSource : IProductSource
{
    private readonly Configuration _configuration;
    private readonly IPriceParser _priceParser;

    private TextFieldParser? _textFieldParser;

    public ProductSource(Configuration configuration, IPriceParser priceParser)
    {
        _configuration = configuration;
        _priceParser = priceParser;
    }

    public void Open()
    {
        _textFieldParser = new TextFieldParser(_configuration.SourceCsvPath);
        _textFieldParser.SetDelimiters(",");
    }

    public bool hasMoreProducts()
    {
        if (_textFieldParser == null)
            throw new InvalidOperationException("Cannot read from a source that is not yet open");

        return !_textFieldParser.EndOfData;
    }

    public Product GetNextProduct()
    {
        if (_textFieldParser == null)
            throw new InvalidOperationException("Cannot read from a source that is not yet open");

        var fields = _textFieldParser.ReadFields() ?? throw new InvalidOperationException("Could not read from source");

        var id = Guid.Parse(fields[0]);
        var name = fields[1];
        var price = _priceParser.Parse(fields[2]);
        var stock = int.Parse(fields[3]);

        var product = new Product(id, name, price, stock);
        return product;
    }

    public void Close()
    {
        if (_textFieldParser == null)
            throw new InvalidOperationException("Cannot close a source that is not yet open");

        _textFieldParser.Close();
        ((IDisposable)_textFieldParser).Dispose();
    }
}