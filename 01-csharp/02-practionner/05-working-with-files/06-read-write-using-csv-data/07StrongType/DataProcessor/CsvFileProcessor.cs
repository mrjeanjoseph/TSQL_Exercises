using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace DataProcessor;

internal class CsvFileProcessor
{
    public string InputFilePath { get; }
    public string OutputFilePath { get; }

    public CsvFileProcessor(string inputFilePath, string outputFilePath)
    {
        InputFilePath = inputFilePath;
        OutputFilePath = outputFilePath;
    }

    public void Process()
    {
        using StreamReader inputReader = File.OpenText(InputFilePath);

        var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Comment = '@',
            AllowComments = true,
            TrimOptions = TrimOptions.Trim,
            IgnoreBlankLines = true, // this is the default
            HasHeaderRecord = true, // this is the default
            Delimiter = "," // this is the default
        };
        using CsvReader csvReader = new CsvReader(inputReader, csvConfiguration);

        IEnumerable<Order> records = csvReader.GetRecords<Order>();

        foreach (var order in records)
        {
            Console.WriteLine($"Order Number: {order.OrderNumber}");
            Console.WriteLine($"Customer Number: {order.CustomerNumber}");
            Console.WriteLine($"Description: {order.Description}");
            Console.WriteLine($"Quantity: {order.Quantity}");
        }
    }
}
