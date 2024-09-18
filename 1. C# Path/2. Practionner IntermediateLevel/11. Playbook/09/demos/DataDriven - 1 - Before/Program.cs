using Pluralsight.CShDemo.ControlFlow;

Console.WriteLine("Enter path of directory to backup/clean:");
string directoryPath = Console.ReadLine()!;

DirectoryInfo directoryToBackup = new DirectoryInfo(directoryPath);
Console.WriteLine($"Processing directory {directoryToBackup.Name}");
DirectoryCleaner.DoBackupAndClean(directoryToBackup);
