using Pluralsight.CShPlaybook.Interfaces.Demo.BusinessObjects;

namespace Pluralsight.CShPlaybook.Interfaces.Demo.DataAccess;

public class ClientRepository : IClientRepository
{
	public GardenClient GetClientFromId(int clientId)
	{
		// we assume this is really getting the data from a database
		GardenClient client = new GardenClient(clientId, "Simon the Ace Gardener", this);
		client.AddToCart("Carnations");
		client.AddToCart("Roses");
		return client;
}

	public bool PersistCart(GardenClient client)
	{
		// we assume this will go to the database and log the purchases
		Console.WriteLine("Just for the demo, the cart is being persisted\r\n");
		return true;
	}

	public ClientRepository(string connectionString)
	{
		// we assume this will connect to the database
	}
}
