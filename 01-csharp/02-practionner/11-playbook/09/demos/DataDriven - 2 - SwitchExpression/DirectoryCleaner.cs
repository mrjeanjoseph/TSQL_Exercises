namespace Pluralsight.CShDemo.ControlFlow;

public enum FileAction { Backup, Ignore, Delete}

public static class DirectoryCleaner
{
	public static void DoBackupAndClean(DirectoryInfo targetDirectory)
	{
		foreach (FileSystemInfo item in targetDirectory.EnumerateFileSystemInfos())
		{
			FileAction action = GetItemAction(item);
			ProcessItem(action, item);
		}
		// In a real app you'd recursively clean sub-directories too
	}

	private static void ProcessItem(FileAction fileAction, FileSystemInfo item) =>
		Console.WriteLine($"{fileAction}: {item.Name}");

	public static FileAction GetItemAction(FileSystemInfo fileSystemItem)
	{
		const int MB100 = 104_857_600;
		return fileSystemItem switch
		{
			DirectoryInfo { Name: "bin" or "obj" } => FileAction.Delete,
			DirectoryInfo { Name: ".hg" } => FileAction.Ignore,
			FileInfo { Length: > MB100 } => FileAction.Ignore,
			FileInfo { Name: "TemporaryFile.tmp" } => FileAction.Ignore,
			_ => FileAction.Backup
		};
	}

}
