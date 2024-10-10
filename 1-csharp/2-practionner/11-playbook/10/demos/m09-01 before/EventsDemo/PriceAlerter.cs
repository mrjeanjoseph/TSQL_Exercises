using System.ComponentModel;
namespace Pluralsight.CShPlaybook.EventsDemo;

public class PriceAlerter
{
	public static void AlertPriceChanged(object? sender, EventArgs e)
	{
		BookmarkProduct product = (BookmarkProduct)sender!;
		Console.WriteLine($"{product.Name} changed to {product.Price}");
	}
}