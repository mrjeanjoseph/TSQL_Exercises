using System;
using NUnit.Framework;

namespace Pluralsight.CShPlaybook.OpenHoursLibrary.Test;
public class OfficeHoursTests
{
	[Test]
	public void GetTotalOpenHoursToday_IsCorrect()
	{
		// arrange
		TimeSpan expectedAnswer = new TimeSpan(8, 0, 0);
		HoursRepository_TestDouble repository = new();
		OfficeHours sut = new OfficeHours(repository);

		// act
		TimeSpan totalHoursOpen = sut.GetTotalOpenHoursToday();

		// assert
		Assert.That(totalHoursOpen, Is.EqualTo(expectedAnswer));
	}

	[Test]
	[TestCase(7, 0, 1, 30)]
	[TestCase(8, 30, 0, 0)]
	[TestCase(10, 37, 0, 0)]
	[TestCase(12, 00, 1, 0)]
	[TestCase(12, 22, 0, 38)]
	[TestCase(17, 45, 14, 45)]
	public void GetTimeUntilNextOpen_IsCorrect(int timeNowHours, int timeNowMinutes, int expectedAnswerHours, int expectedAnswerMinutes)
	{
		// arrange
		TimeOnly timeNow = new TimeOnly(timeNowHours, timeNowMinutes);
		TimeSpan expectedAnswer = new TimeSpan(expectedAnswerHours, expectedAnswerMinutes, 0);
		HoursRepository_TestDouble repository = new();
		TimeNowProvider_TestDouble timeNowProvider = new(timeNow);
		OfficeHours officeHours = new OfficeHours(repository);

		// act
		TimeSpan howLongUntilOpen = officeHours.GetTimeUntilNextOpen(timeNowProvider);

		// assert
		Assert.That(howLongUntilOpen, Is.EqualTo(expectedAnswer));
	}
}
