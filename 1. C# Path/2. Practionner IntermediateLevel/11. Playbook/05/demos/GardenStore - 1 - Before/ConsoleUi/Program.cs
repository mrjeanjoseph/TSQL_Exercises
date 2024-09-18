using Pluralsight.CShPlaybook.Interfaces.Demo.BusinessObjects;
using Pluralsight.CShPlaybook.Interfaces.Demo.DataAccess;

GardenClient client = new GardenClient(1, "Simon the Ace Gardener");
client.AddToCart("Carnations");
client.AddToCart("Roses");

DisplayClient(client);

void DisplayClient(GardenClient client)
{
	Console.WriteLine(client.Name);
	foreach (string item in client.ShoppingCart)
		Console.WriteLine($" In cart: {item}");
	Console.WriteLine();
}