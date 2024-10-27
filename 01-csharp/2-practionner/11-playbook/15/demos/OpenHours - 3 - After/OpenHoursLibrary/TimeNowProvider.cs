namespace Pluralsight.CShPlaybook.OpenHoursLibrary;

public interface ITimeNowProvider
{
	TimeOnly GetTimeNow();
}
public class TimeNowProvider : ITimeNowProvider
{
	public TimeOnly GetTimeNow() => TimeOnly.FromDateTime(DateTime.Now);
}

