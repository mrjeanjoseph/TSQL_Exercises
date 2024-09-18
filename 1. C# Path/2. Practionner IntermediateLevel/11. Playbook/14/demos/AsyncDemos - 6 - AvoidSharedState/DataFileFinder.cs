using System.Reflection;

namespace Pluralsight.CShPlaybook.AsyncDemo
{
	public static class DataFileFinder
	{
		public static string GetFilePath(string fileName) => Path.Combine(GetDataFolder(), fileName);

		// works out the folder that the project files are in
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

		private static string GetDataFolder() => Path.Combine(GetCodeFolder(), "Data");
	}
}
