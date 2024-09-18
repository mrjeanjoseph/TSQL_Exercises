namespace Pluralsight.CShPlaybook.EventsDemo;

public class PriceAlerter
{
	public static void AlertPriceChanged(object? sender, PriceChangedEventArgs e)
	{
		BookmarkProduct product = (BookmarkProduct)sender!;
        if (product.Price < 0)
        {
            Console.WriteLine($"{product.Name} is no longer for sale");
            product.PriceChanged -= AlertPriceChanged;
        }
        else
			Console.WriteLine($"{product.Name} changed from {e.OldPrice} to {product.Price}");
	}
}