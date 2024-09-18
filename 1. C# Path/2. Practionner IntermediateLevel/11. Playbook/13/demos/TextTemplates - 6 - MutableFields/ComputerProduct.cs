namespace Pluralsight.CShPlaybook.AttribsReflection;

[ActualProduct(CanUseInTemplate = true)]
public class ComputerProduct : Product
{
	public ComputerProduct(string name, ProductStatus status, decimal price, string ram, int processorCount)
		: base(name, status, price) 
	{
		Ram = ram;
		ProcessorCount = processorCount;
	}

	public string Ram { get; }

	public int ProcessorCount { get; }
}


