using static System.Console;

namespace DataProcessor;

internal class FileProcessor
{
    private const string BackupDirectoryName = "backup";
    private const string InProgressDirectoryName = "processing";
    private const string CompletedDirectoryName = "complete";

    public string InputFilePath { get; }

    public FileProcessor(string filePath) => InputFilePath = filePath;

    public void Process()
    {
        WriteLine($"Begin process of {InputFilePath}");

        // Check if file exists
        if (!File.Exists(InputFilePath))
        {
            WriteLine($"ERROR: file {InputFilePath} does not exist.");
            return;
        }

        string? rootDirectoryPath = new DirectoryInfo(InputFilePath).Parent?.Parent?.FullName;
        if (rootDirectoryPath is null)
        {
            throw new InvalidOperationException($"Cannot determine root directory path for '{InputFilePath}'.");
        }
        WriteLine($"Root data path is {rootDirectoryPath}");

        // Check if backup dir exists
        string backupDirectoryPath = Path.Combine(rootDirectoryPath, BackupDirectoryName);

        if (!Directory.Exists(backupDirectoryPath))
        {
            WriteLine($"Creating {backupDirectoryPath}");
            Directory.CreateDirectory(backupDirectoryPath);
        }

        // Copy file to backup dir
        string inputFileName = Path.GetFileName(InputFilePath);
        string backupFilePath = Path.Combine(backupDirectoryPath, inputFileName);
        WriteLine($"Copying {InputFilePath} to {backupFilePath}");
        File.Copy(InputFilePath, backupFilePath, true);

        // Move to in progress dir
        Directory.CreateDirectory(Path.Combine(rootDirectoryPath, InProgressDirectoryName));
        string inProgressFilePath =
            Path.Combine(rootDirectoryPath, InProgressDirectoryName, inputFileName);

        if (File.Exists(inProgressFilePath))
        {
            WriteLine($"ERROR: a file with the name {inProgressFilePath} is already being processed.");
            return;
        }

        WriteLine($"Moving {InputFilePath} to {inProgressFilePath}");
        File.Move(InputFilePath, inProgressFilePath);

        // Determine type of file
        string extension = Path.GetExtension(InputFilePath);

        string completedDirectoryPath =
            Path.Combine(rootDirectoryPath, CompletedDirectoryName);

        Directory.CreateDirectory(completedDirectoryPath);

        string fileNameWithCompletedExtension =
            Path.ChangeExtension(inputFileName, ".complete");
        string completedFileName =
            $"{Guid.NewGuid()}_{fileNameWithCompletedExtension}";

        string completedFilePath =
            Path.Combine(completedDirectoryPath, completedFileName);


        switch (extension)
        {
            case ".txt":
                var textProcessor = new TextFileProcessor(inProgressFilePath, completedFilePath);
                textProcessor.Process();
                break;
            case ".data":
                var binaryProcessor = new BinaryFileProcessor(inProgressFilePath, completedFilePath);
                binaryProcessor.Process();
                break;
            default:
                WriteLine($"{extension} is an unsupported file type.");
                break;
        }

        WriteLine($"Completed processing of {inProgressFilePath}");

        WriteLine($"Deleting {inProgressFilePath}");
        File.Delete(inProgressFilePath);
    }
}
