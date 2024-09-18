namespace Pluralsight.CShPlaybook.EventsDemo;
public class BookmarkProduct
{
	public string Id { get; init; }
	public string Name { get; init; }
	private decimal _price;
	public decimal Price
	{
		get => _price;
		set
		{
			if (value != _price)
			{
				var eventArgs = new PriceChangedEventArgs(_price);
                _price = value;
                PriceChanged?.Invoke(this, eventArgs);			}
		}
	}
	public event PriceChangedEventHandler? PriceChanged;

	public BookmarkProduct(string id, string name, decimal price)
	{
		if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name) || price < 0.01m)
			throw new ArgumentException("Invalid product details");
		Id = id;
		Name = name;
		Price = price;
	}
}

