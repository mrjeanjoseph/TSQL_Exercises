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

(var name, var totalValue, var nSales) = sales.GetHighestValueCustomer();

Console.WriteLine("Highest spender:");
Console.WriteLine($"{name} Spent {totalValue} in {nSales} purchases");

var highest = sales.GetHighestValueCustomer();
Console.WriteLine("Highest spender:");
Console.WriteLine($"{highest.CustomerName} Spent {highest.TotalSpent} in {highest.NSales} purchases");
