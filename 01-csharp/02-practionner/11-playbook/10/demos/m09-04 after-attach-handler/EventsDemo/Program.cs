using Pluralsight.CShPlaybook.EventsDemo;

Dictionary<string, BookmarkProduct> allProducts = new()
{ 
	["AVT"] = new BookmarkProduct("AVT", "Aloe Vera Bookmark", 4.50m),
	["HPB"] = new BookmarkProduct("HPB", "Hot Pink Bookmark", 3.50m),
	["TGB"] = new BookmarkProduct("TGB", "Triangular Bookmark", 4.00m),
};

foreach (BookmarkProduct product in allProducts.Values)
    product.PriceChanged += PriceAlerter.AlertPriceChanged;

allProducts["AVT"].Price = 2.75m;
allProducts["AVT"].Price = 2.90m;

