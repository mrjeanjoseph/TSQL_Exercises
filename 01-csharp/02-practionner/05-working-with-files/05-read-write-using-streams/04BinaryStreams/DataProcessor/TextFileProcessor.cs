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
		using StreamReader inputStreamReader = File.OpenText(InputFilePath);
		using var outputStreamWriter = new StreamWriter(OutputFilePath);

		var currentLineNumber = 1;

		while (!inputStreamReader.EndOfStream)
        {
			string inputLine = inputStreamReader.ReadLine()!;

			if (currentLineNumber == 2)
			{
				inputLine = inputLine.ToUpperInvariant();
			}
			bool isLastLine = inputStreamReader.EndOfStream;

			if (isLastLine)
			{
				outputStreamWriter.Write(inputLine);
			}
			else
			{
				outputStreamWriter.WriteLine(inputLine);
			}

			currentLineNumber++;
		}




	}
}
