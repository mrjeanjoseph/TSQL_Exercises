namespace Pluralsight.CShPlaybook.MethodsProps;

public class CookieCustomer
{
	public int Id { get; } // must be > 0

	private string _name;
	public string Name
	{
		get => _name;
		set
		{
			ValidateName(value, nameof(Name));
			_name = value;
		}
	}

	public string? Notes { get; set; }

	public char NameFirstChar => Name[0];

	public CookieCustomer(int id, string name, string? notes=null)
	{
		ValidateName(name, nameof(name));
		ValidateId(id, nameof(id));

		Id = id;
		_name = name;
		Notes = notes;
	}

	private void ValidateName(string name, string paramName)
	{
		if (string.IsNullOrWhiteSpace(name))
			throw new ArgumentException("Customer name cannot be null or whitespace", paramName);
	}

	private void ValidateId(int id, string paramName)
	{
		if (id <= 0)
			throw new ArgumentException($"Customer ID must be >0. Actual value was: {id}", paramName);
	}

	public override string ToString() => $"Customer Id={Id}, Name={Name}";


}
