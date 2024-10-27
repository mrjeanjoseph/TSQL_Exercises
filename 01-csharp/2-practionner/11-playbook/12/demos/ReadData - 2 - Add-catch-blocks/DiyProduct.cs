using System.Diagnostics;
namespace Pluralsight.CShPlaybook.Exceptions;

public class DiyProduct
{
	public int Id { get; private init; }
    public string Name { get; private init; }
    public DiyProduct(int id, string name)
    {
        Id = id;
        Name = name;
        CheckValid();
    }
	private void CheckValid()
	{
		if (string.IsNullOrWhiteSpace(Name))
			throw new Exception("Name cannot be null or whitespace");
		if (Id <= 0)
			throw new Exception("Id must be positive number > 0");
	}
	public override string ToString() => $"Id={Id}, Name={Name}";
	public bool IsSpecialProduct
	{
		get
		{
			Debug.Assert(Id > 0);
			Debug.Assert(!string.IsNullOrWhiteSpace(Name));
			return Name.Contains("Special");
		}
	}
}
