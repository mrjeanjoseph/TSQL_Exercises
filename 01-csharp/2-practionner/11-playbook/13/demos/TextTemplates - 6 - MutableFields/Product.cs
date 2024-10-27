namespace Pluralsight.CShPlaybook.AttribsReflection;

public class Product
{
	public string Name { get; }
	public ProductStatus Status { get; }
	public decimal Price { get; }

	public Product(string name, ProductStatus status, decimal price)
	{
		Name = name;
		Status = status;
		Price = price;
	}
}

