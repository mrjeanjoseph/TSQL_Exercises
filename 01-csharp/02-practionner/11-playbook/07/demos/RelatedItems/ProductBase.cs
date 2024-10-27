namespace Pluralsight.CShPlaybook.Generics
{
	public class ProductBase<T> where T : notnull
	{
		// list of related products to go here
		public List<T> RelatedItems { get; init; } = new();

	}
}
