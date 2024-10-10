namespace Pluralsight.CShPlaybook.LinqDemos;

public static class LinqExtensions
{
	public static IEnumerable<T> Throttle<T>(this IEnumerable<T> sequence)
	{
		foreach (T item in sequence)
		{
			Thread.Sleep(1000);
			yield return item;
		}
	}

	public static IEnumerable<T> Log<T>(this IEnumerable<T> sequence)
	{
		foreach (T item in sequence)
		{
			Console.WriteLine($"Enumerating {item}");
			yield return item;
		}
	}
}
