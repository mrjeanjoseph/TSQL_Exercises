namespace Pluralsight.CShPlaybook.OpenHoursLibrary;

public readonly record struct OpenPeriod(TimeOnly OpenTime, TimeOnly ClosedTime)
{
}

