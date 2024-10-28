using DataProcessor;
using static System.Console;

WriteLine("Parsing command line options");

// Command line validation omitted for brevity

var command = args[0];

if (command == "--file")
{
    var filePath = args[1];
    WriteLine($"Single file {filePath} selected");
    ProcessSingleFile(filePath);
}
else if (command == "--dir")
{
    var directoryPath = args[1];
    var fileType = args[2];
    WriteLine($"Directory {directoryPath} selected for {fileType} files");
    ProcessDirectory(directoryPath, fileType);
}
else
{
    WriteLine("Invalid command line options");
}

WriteLine("Press enter to quit.");
ReadLine();

static void ProcessSingleFile(string filePath)
{
    var fileProcessor = new FileProcessor(filePath);
    fileProcessor.Process();
}

static void ProcessDirectory(string directoryPath, string fileType)
{

}

