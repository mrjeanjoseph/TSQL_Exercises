using Pluralsight.CShPlaybook.MethodsProps;

CookieCustomer customer = new(0, "");

Console.WriteLine(customer);

char firstCh = customer.NameFirstChar;
Console.WriteLine("Customer's name starts with " + firstCh);

