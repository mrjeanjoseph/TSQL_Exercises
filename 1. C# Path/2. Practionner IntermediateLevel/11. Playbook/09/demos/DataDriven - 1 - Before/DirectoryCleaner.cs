namespace Pluralsight.CShDemo.ControlFlow;

public enum FileAction { Backup, Ignore, Delete}

public static class DirectoryCleaner
{
	public static void DoBackupAndClean(DirectoryInfo targetDirectory)
	{
		foreach (System.IO.FileSystemInfo item in targetDirectory.EnumerateFileSystemInfos())
			BackupAndCleanItem(item);

		// In a real app you'd recursively clean sub-directories too
	}

	private static void ProcessItem(FileAction fileAction, FileSystemInfo item) =>
		Console.WriteLine($"{fileAction}: {item.Name}");

	private static void BackupAndCleanItem(FileSystemInfo fileSystemItem)
	{
		const int MB100 = 104_857_600;
		switch(fileSystemItem)
		{
			case DirectoryInfo { Name: "bin" or "obj" }:
				ProcessItem(FileAction.Delete, fileSystemItem);
				break;
			case DirectoryInfo { Name: ".hg" }:
			case FileInfo { Length: > MB100 }:
			case FileInfo { Name: "TemporaryFile.tmp" }:
				ProcessItem(FileAction.Ignore, fileSystemItem);
				break;
			default:
				ProcessItem(FileAction.Backup, fileSystemItem);
				break;
		};
	}
}
