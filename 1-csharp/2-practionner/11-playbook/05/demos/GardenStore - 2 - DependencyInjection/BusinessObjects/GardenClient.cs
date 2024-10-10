namespace Pluralsight.CShPlaybook.Interfaces.Demo.BusinessObjects;

public class GardenClient
{
	public int Id { get; private init; }

	public string Name { get; private init; }

	public List<string> ShoppingCart { get; private init; } = new();

	private IClientRepository _repository;

	public GardenClient(int id, string name, IClientRepository repository)
	{
		Id = id;
		Name = name;
		_repository = repository;
	}

	public void AddToCart(string itemName)
	{
		ShoppingCart.Add(itemName);
	}

	public void SaveCart()
	{
		_repository.PersistCart(this);
	}
}

