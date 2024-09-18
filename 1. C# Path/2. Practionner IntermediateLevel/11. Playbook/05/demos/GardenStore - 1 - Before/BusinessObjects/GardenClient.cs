namespace Pluralsight.CShPlaybook.Interfaces.Demo.BusinessObjects;

public class GardenClient
{
	public int Id { get; private init; }

	public string Name { get; private init; }

	public List<string> ShoppingCart { get; private init; } = new();

	public GardenClient(int id, string name)
	{
		Id = id;
		Name = name;
	}

	public void AddToCart(string itemName)
	{
		ShoppingCart.Add(itemName);
	}
}

