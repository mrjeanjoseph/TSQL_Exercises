using Pluralsight.CShPlaybook.NullValues;

DeliveryTimes deliveries = new DeliveryTimes();

Console.WriteLine("What is the current time?");
bool ok = TimeOnly.TryParse(Console.ReadLine(), out TimeOnly currentTime);
if (!ok)
{
	Console.WriteLine("That isn't a time!");
	return;
}

Console.WriteLine($"Last delivery is at {deliveries.GetLastDeliveryTime()}");

TimeOnly? nextDeliveryTime = deliveries.GetNextDeliveryTime(currentTime);
if (nextDeliveryTime == null)
	Console.WriteLine("There are no more deliveries today");
else
	Console.WriteLine($"Next delivery is at {nextDeliveryTime}");

Console.WriteLine(
	$"Delivery expected within 30 minutes? {deliveries.IsDeliveryExpectedWithin30Mins(currentTime)}");



