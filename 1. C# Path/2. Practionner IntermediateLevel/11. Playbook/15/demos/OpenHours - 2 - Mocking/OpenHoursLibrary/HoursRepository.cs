namespace Pluralsight.CShPlaybook.OpenHoursLibrary;

public interface IHoursRepository
{
	IReadOnlyList<OpenPeriod> GetTodayOpenHours();
	IReadOnlyList<OpenPeriod> GetTomorrowOpenHours();
}
public class HoursRepository : IHoursRepository
{
	public IReadOnlyList<OpenPeriod> GetTodayOpenHours()
	{
		// we assume this will get the data from an external database
		throw new NotImplementedException();
	}

	public IReadOnlyList<OpenPeriod> GetTomorrowOpenHours()
	{
		// we assume this will get the data from an external database
		throw new NotImplementedException();
	}
}


