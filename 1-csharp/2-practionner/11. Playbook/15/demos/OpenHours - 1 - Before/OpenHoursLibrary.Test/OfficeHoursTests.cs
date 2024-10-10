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
		OfficeHours sut = new OfficeHours();

		// act
		TimeSpan totalHoursOpen = sut.GetTotalOpenHoursToday();

		// assert
		Assert.That(totalHoursOpen, Is.EqualTo(expectedAnswer));
	}
}
