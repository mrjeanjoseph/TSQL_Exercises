using System.Text.RegularExpressions;

namespace Pluralsight.CShPlaybook.AsyncDemo;

public static class PsCourseInfoParser
{
	// this pattern will match strings like 
	// "What's New in C# 10", "c-sharp-10-whats-new/table-of-contents"
	// into a name-uri pair
	private static string _pattern = @"\""([^\""]+)\""\s*,\s*\""([^\""]+)\""";

	private static Regex regex = new Regex(_pattern);

	public static PsCourseInfo ParseCsv(string text)
	{
		Match match = regex.Match(text);
		if (!match.Success)
			throw new Exception("Can't parse text into a PSCourse");
		// Groups[0] is the entire string, so discarded
		return new PsCourseInfo(match.Groups[1].Value, match.Groups[2].Value);
	}

	public static List<PsCourseInfo> LoadCourseInfoDataFromFileName(string fileName)
	{
		string filePath = DataFileFinder.GetFilePath(fileName);
		return LoadCourseInfoDataFromFilePath(filePath);
	}

	public static List<PsCourseInfo> LoadCourseInfoDataFromFilePath(string filePath)
	{
		List<PsCourseInfo> list = new List<PsCourseInfo>();
		foreach (string line in File.ReadAllLines(filePath))
			list.Add(ParseCsv(line));
		return list;
	}

}
