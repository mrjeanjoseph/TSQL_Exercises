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
            HasHeaderRecord = false
        };
        using CsvReader csvReader = new CsvReader(inputReader, csvConfiguration);

        IEnumerable<dynamic> records = csvReader.GetRecords<dynamic>();

        foreach (var record in records)
        {
            Console.WriteLine(record.Field1);
            Console.WriteLine(record.Field2);
            Console.WriteLine(record.Field3);
            Console.WriteLine(record.Field4);
        }
    }
}
