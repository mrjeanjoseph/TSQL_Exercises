namespace Pluralsight.CShPlaybook.MethodsProps;

public class SalesList
{
	private List<Sale> _sales = new();

	public IEnumerable<Sale> EnumerateItems()
	{
		foreach (var item in _sales)
			yield return item;
	}

	public void AddSale(Sale item)
	{
		_sales.Add(item);
	}
}