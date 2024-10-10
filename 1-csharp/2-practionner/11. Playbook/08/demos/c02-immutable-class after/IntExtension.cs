namespace Pluralsight.CShPlaybook.DrawingStuff;
public static class IntExtension
{
	public static int LimitToRange(this int i, int min, int max)
	{
		if (i < min)
			i = min;
		if (i > max)
			i = max;
		return i;
	}
}