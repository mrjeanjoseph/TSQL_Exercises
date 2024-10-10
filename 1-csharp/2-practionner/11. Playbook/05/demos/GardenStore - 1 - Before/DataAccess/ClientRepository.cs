using Pluralsight.CShPlaybook.Interfaces.Demo.BusinessObjects;

namespace Pluralsight.CShPlaybook.Interfaces.Demo.DataAccess;

public class ClientRepository
{
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
