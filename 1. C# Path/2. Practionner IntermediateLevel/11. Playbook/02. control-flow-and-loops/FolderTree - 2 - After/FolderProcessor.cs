namespace Pluralsight.CShPlaybook.ControlFlow;

public class FolderProcessor
{
	public static void DisplayParentNames_While(string filePath)
	{
		var folder = new DirectoryInfo(Path.GetDirectoryName(filePath)!);
		while (folder != null)
		{
			Console.WriteLine(folder.Name);
			folder = folder.Parent;
		}
	}

	public static List<string> GetParentNames_While(string filePath)
	{
		var results = new List<string>();

		var folder = new DirectoryInfo(Path.GetDirectoryName(filePath)!);
		while (folder != null)
		{
			results.Add(folder.Name);
			folder = folder.Parent;
		}
		return results;
	}
	public static IEnumerable<string> EnumParentNames_While(string filePath)
	{
		var folder = new DirectoryInfo(Path.GetDirectoryName(filePath)!);
		while (folder != null)
		{
			yield return folder.Name;
			folder = folder.Parent;
		}
	}
	public static IEnumerable<string> EnumParentNames_For(string filePath)
	{
		var folder = new DirectoryInfo(Path.GetDirectoryName(filePath)!);
		for (; folder != null; folder = folder.Parent)
			yield return folder.Name;
	}
	public static IEnumerable<string> EnumParentNames_Do(string filePath)
	{
		var folder = new DirectoryInfo(Path.GetDirectoryName(filePath)!);
		do
		{
			yield return folder.Name;
			folder = folder.Parent;
		} while (folder != null);
	}
}

