using System.ComponentModel;

namespace Pluralsight.CShPlaybook.EventsDemo;

public class PriceAlerter
{
    public static string GetMessage(BookmarkProduct product, string? propName)
    {
        return propName switch
        {
            nameof(BookmarkProduct.Name) => $"{product.Id} has new name {product.Name}",
            nameof(BookmarkProduct.Price) => $"{product.Name}: Price changed to {product.Price}",
            _ => "Error - unknown property name"
        };
    }
	public static void AlertPriceChanged(object? sender, PropertyChangedEventArgs e)
	{
		BookmarkProduct product = (BookmarkProduct)sender!;
        if (product.Price < 0)
        {
            Console.WriteLine($"{product.Name} is no longer for sale");
            product.PropertyChanged -= AlertPriceChanged;
        }
        else
            Console.WriteLine(GetMessage(product, e.PropertyName));
    }
}