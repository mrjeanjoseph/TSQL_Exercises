namespace Pluralsight.CShPlaybook.AsyncDemo;

public class SlowFileReader
{
	public static IEnumerable<string> ReadFileSlow(string filePath)
	{
		using StreamReader sr = new StreamReader(filePath);

		while (!sr.EndOfStream)
		{
			Thread.Sleep(500);
			yield return sr.ReadLine()!;
		}
	}
}
