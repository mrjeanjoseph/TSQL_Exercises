namespace Pluralsight.CShPlaybook.Exceptions;

public class InvalidProductException : Exception
{
	public DiyProduct Product { get; private init; }
	public string PropName { get; private init; }
	public InvalidProductException(DiyProduct product, string message, string propName)
		: base(message)
	{
		this.Product = product;
		this.PropName = propName;
	}
	public InvalidProductException(DiyProduct product, string message, string propName, Exception innerException)
		: base(message, innerException)
	{
		this.Product = product;
		this.PropName = propName;
	}

}