namespace Pluralsight.CShPlaybook.OpenHoursLibrary;
public class OfficeHours
{
	public IReadOnlyList<OpenPeriod> OpenHoursToday { get; private init; }
	public IReadOnlyList<OpenPeriod> OpenHoursTomorrow { get; private init; }
	public OfficeHours()
	{
		HoursRepository dataSource = new HoursRepository();
		OpenHoursToday = dataSource.GetTodayOpenHours();
		OpenHoursTomorrow = dataSource.GetTomorrowOpenHours();
	}

	public TimeSpan GetTotalOpenHoursToday()
	{
		IEnumerable<TimeSpan> openTimeSpans = 
			from duration in OpenHoursToday select duration.ClosedTime - duration.OpenTime;
		return SumTimeSpans(openTimeSpans);
	}
	public static TimeSpan SumTimeSpans(IEnumerable<TimeSpan> sequence)
	{
		TimeSpan result = new();
		foreach (TimeSpan t in sequence)
			result += t;
		return result;
	}
}
