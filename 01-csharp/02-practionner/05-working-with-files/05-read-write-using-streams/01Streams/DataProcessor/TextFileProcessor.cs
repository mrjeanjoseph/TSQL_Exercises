namespace DataProcessor;

internal class TextFileProcessor
{
    public string InputFilePath { get; }
    public string OutputFilePath { get; }

	public TextFileProcessor(string inputFilePath, string outputFilePath)
	{
		InputFilePath = inputFilePath;
		OutputFilePath = outputFilePath;
	}

	public void Process()
	{
		var openToReadFrom = new FileStreamOptions { Mode = FileMode.Open };
		using var inputFileStream = new FileStream(InputFilePath, openToReadFrom);
		using var inputStreamReader = new StreamReader(inputFileStream);

		var createToWriteTo = new FileStreamOptions 
		{ 
			Mode = FileMode.CreateNew,
			Access = FileAccess.Write
		};
		using var outputFileStream = new FileStream(OutputFilePath, createToWriteTo);
		using var outputStreamWriter = new StreamWriter(outputFileStream);

        while (!inputStreamReader.EndOfStream)
        {
			string inputLine = inputStreamReader.ReadLine()!;
			string processedLine = inputLine.ToUpperInvariant();
			outputStreamWriter.WriteLine(processedLine);
		}




	}
}
