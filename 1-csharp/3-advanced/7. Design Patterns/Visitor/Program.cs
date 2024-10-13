using Visitor;

Console.Title = "Visitor";

// create container & add concrete elements
var container = new Container();

container.Customers.Add(new Customer("Louna", 500));
container.Customers.Add(new Customer("Veleenah", 500));
container.Customers.Add(new Customer("Raoul", 1000));
container.Customers.Add(new Customer("Natacha", 800));
container.Employees.Add(new Employee("Jerodette", 18));
container.Employees.Add(new Employee("Julie Duree", 5));

// create visitor
DiscountVisitor discountVisitor = new();

// pass it through
container.Accept(discountVisitor);

// write out gathered amount
Console.WriteLine($"Total discount: {discountVisitor.TotalDiscountGiven}");

Console.ReadKey();