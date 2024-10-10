using Pluralsight.CShPlaybook.MethodsProps;

CookieCustomer pluralsight = new(1, "Pluralsight");
CookieCustomer simon = new(2, "Simon the Soon-to-be-overweight");
CookieCustomer browserRobot = new(3, "Browser Robot");

SalesList sales = new();
sales.AddSale(new(simon, 200))
	.AddSale(new(pluralsight, 80))
	.AddSale(new(simon, 50))
	.AddSale(new(browserRobot, 500))
	.AddSale(new(pluralsight, 1000))
	.AddSale(new(browserRobot, 50))
	.AddSale(new(pluralsight, 20));

// Fluent coding in LINQ
var highValueSales = sales.EnumerateItems()
	.Where(sale => sale.Value > 100)
	.OrderBy(sale => sale.Customer.Name);

