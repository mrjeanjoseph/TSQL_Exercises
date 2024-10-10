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

string name = sales.GetHighestValueCustomer(out decimal totalValue, out int nSales);

Console.WriteLine("Highest spender:");
Console.WriteLine($"{name} Spent {totalValue} in {nSales} purchases");

