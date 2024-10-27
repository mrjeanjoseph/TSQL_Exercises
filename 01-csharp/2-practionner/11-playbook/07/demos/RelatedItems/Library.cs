namespace Pluralsight.CShPlaybook.Generics
{
	public class Library : ProductBase<Library>
	{
		public string Name { get; init; }
		public Library(string name)
		{
			this.Name = name;
		}
	}
}
