using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pluralsight.CShPlaybook.OpenHoursLibrary.Test;

public class HoursRepository_TestDouble : IHoursRepository
{
	private static TimeOnly eight30Am = new TimeOnly(8, 30);
	private static TimeOnly midday = new TimeOnly(12, 0);
	private static TimeOnly onePm = new TimeOnly(13, 0);
	private static TimeOnly five30Pm = new TimeOnly(17, 30);

	private ReadOnlyCollection<OpenPeriod> weekdayHours =
		new List<OpenPeriod>()
		{
			new OpenPeriod(eight30Am, midday),
			new OpenPeriod(onePm, five30Pm)
		}
		.AsReadOnly();
	public IReadOnlyList<OpenPeriod> GetTodayOpenHours() => weekdayHours;
	public IReadOnlyList<OpenPeriod> GetTomorrowOpenHours() => weekdayHours;
}

