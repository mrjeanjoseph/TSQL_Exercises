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
			throw new InvalidProductException(this, "Name cannot be null or whitespace", nameof(Name));
		if (Id <= 0)
			throw new InvalidProductException(this, "Id must be postive number > 0", nameof(Id));
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
