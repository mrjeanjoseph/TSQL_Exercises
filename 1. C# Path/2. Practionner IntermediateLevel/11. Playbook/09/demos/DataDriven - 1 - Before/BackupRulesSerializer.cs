using System.Reflection;
using System.Text.Json;

namespace Pluralsight.CShDemo.ControlFlow;

public static class BackupRulesSerializer
{
	private static string GetJsonFilePath()
	{
		string exeFolder = Assembly.GetEntryAssembly()!.Location!;
		DirectoryInfo info = new DirectoryInfo(exeFolder);
		while (info.Name != "bin")
		{
			if (info.Parent == null)
				throw new Exception("Can't find folder");
			info = info.Parent;
		}
		string folder = Path.Combine(info.Parent!.FullName, "BusinessRules");
		return Path.Combine(folder, "rules.json");
	}
	public static BackupRules DeserializeFromJson()
	{
		string json = File.ReadAllText(GetJsonFilePath());
		JsonSerializerOptions options = new JsonSerializerOptions();
		options.WriteIndented = true;
		return JsonSerializer.Deserialize<BackupRules>(json, options)!;
	}

	public static void InitializeFile()
	{
		//creates the JSON file for the first time with hardcoded data - run this if you don't already have the file
		BackupRules fileRules = new BackupRules(
			new List<string> { ".hg" },
			new List<string> { "bin", "obj" },
			new List<string> { ".hgignore" },
			new List<string>(), 104_857_600
			);
		BackupRulesSerializer.SerializeToJson(fileRules);
	}

	private static void SerializeToJson(BackupRules rules)
	{
		JsonSerializerOptions options = new JsonSerializerOptions();
		options.WriteIndented = true;
		string str = JsonSerializer.Serialize(rules, options);
		File.WriteAllText(GetJsonFilePath(), str);
	}
}
