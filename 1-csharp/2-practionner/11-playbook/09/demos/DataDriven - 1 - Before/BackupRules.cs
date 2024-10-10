using System.Collections.Immutable;
using System.Text.Json;

namespace Pluralsight.CShDemo.ControlFlow;

public class BackupRules
{
	public List<string> IgnoreDirNames { get; init; }
	public List<string> DeleteDirNames { get; init; }
	public List<string> IgnoreFileNames { get; init; }
	public List<string> DeleteFileNames { get; init; }
	public int? IgnoreMinSize { get; init; }

	public BackupRules(List<string> ignoreDirNames, List<string> deleteDirNames, List<string> ignoreFileNames, List<string> deleteFileNames, int? ignoreMinSize)
	{
		IgnoreDirNames = ignoreDirNames;
		DeleteDirNames = deleteDirNames;
		IgnoreFileNames = ignoreFileNames;
		DeleteFileNames = deleteFileNames;
		IgnoreMinSize = ignoreMinSize;
	}

	public FileAction GetItemAction(FileSystemInfo item)
	{
		if (item is FileInfo fileInfo)
		{
			if (IgnoreFileNames.Contains(item.Name, StringComparer.OrdinalIgnoreCase))
				return FileAction.Ignore;
			if (DeleteFileNames.Contains(item.Name, StringComparer.OrdinalIgnoreCase))
				return FileAction.Delete;
			if (IgnoreMinSize != null && fileInfo.Length > IgnoreMinSize)
				return FileAction.Ignore;
		}
		else if (item is DirectoryInfo)
		{
			if (IgnoreDirNames.Contains(item.Name, StringComparer.OrdinalIgnoreCase))
				return FileAction.Ignore;
			if (DeleteDirNames.Contains(item.Name, StringComparer.OrdinalIgnoreCase))
				return FileAction.Delete;
		}


		return FileAction.Backup;
	}

}
