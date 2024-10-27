namespace Pluralsight.CShDemo.ControlFlow;

public enum FileAction { Backup, Ignore, Delete}

public static class DirectoryCleaner
{
	public static void DoBackupAndClean(DirectoryInfo targetDirectory, BackupRules backupRules)
	{
		foreach (FileSystemInfo item in targetDirectory.EnumerateFileSystemInfos())
        {
            FileAction action = backupRules.GetItemAction(item);
            ProcessItem(action, item);
        }
		// In a real app you'd recursively clean sub-directories too
	}

	private static void ProcessItem(FileAction fileAction, FileSystemInfo item) =>
		Console.WriteLine($"{fileAction}: {item.Name}");

}
