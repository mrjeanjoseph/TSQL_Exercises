using System;

namespace Pluralsight.CShPlaybook.OpenHoursLibrary.Test;
public class TimeNowProvider_TestDouble : ITimeNowProvider
{
	private TimeOnly _value;
	public TimeNowProvider_TestDouble(TimeOnly value)
	{
		_value = value;
	}
	public TimeOnly GetTimeNow() => _value;
}
