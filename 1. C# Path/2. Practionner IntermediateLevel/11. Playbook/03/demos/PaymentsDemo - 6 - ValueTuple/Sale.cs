namespace Pluralsight.CShPlaybook.MethodsProps;

public class Sale
{
	public CookieCustomer Customer { get; }

	// Assume this value is in $
	public decimal Value { get; }

	// a real app would have sales details and date etc.

	public Sale(CookieCustomer customer, decimal amount)
	{
		if (customer == null)
			throw new ArgumentNullException("A sale cannot have a null customer", nameof(customer));
		Customer = customer;
		Value = amount;
	}
}

