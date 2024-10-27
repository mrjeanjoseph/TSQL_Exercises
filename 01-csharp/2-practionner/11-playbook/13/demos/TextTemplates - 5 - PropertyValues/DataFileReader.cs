using System.Reflection;

namespace Pluralsight.CShPlaybook.AttribsReflection;

public static class DataFileReader
{ 
	public static string ReadDataFile(string fileName)
	{
		string filePath = Path.Combine(GetDataFolder(), fileName);
		return File.ReadAllText(filePath);
	}

	private static string GetCodeFolder()
	{
		string exeFolder = Assembly.GetEntryAssembly()!.Location!;
		DirectoryInfo info = new DirectoryInfo(exeFolder);
		while (info.Name != "bin")
		{
			if (info.Parent == null)
				throw new Exception("Can't find folder");
			info = info.Parent;
		}
		return info.Parent!.FullName;
	}

	public static string GetDataFolder() => Path.Combine(GetCodeFolder(), "Data");

}


