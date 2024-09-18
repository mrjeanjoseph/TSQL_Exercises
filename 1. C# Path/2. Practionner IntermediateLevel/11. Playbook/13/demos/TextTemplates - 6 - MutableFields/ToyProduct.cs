namespace Pluralsight.CShPlaybook.AttribsReflection;

[ActualProduct(CanUseInTemplate = true)]
public class ToyProduct : Product
{
	public ToyProduct(string name, ProductStatus status, decimal price, string ageRanges, string category, string weight)
		: base(name, status, price) 
	{
		AgeRanges = ageRanges;
		Category = category;
		Weight = weight;
	}

	public string AgeRanges { get; }
	public string Category { get; }
	public string Weight { get; }
}


