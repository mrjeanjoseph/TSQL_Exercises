namespace Pluralsight.CShPlaybook.LinqDemos;

public class Student
{
	public string Name { get; }
	public int AnonymousId { get; }

	public Student (string name, int anonymousId)
	{
		Name = name;
		AnonymousId = anonymousId;
	}

	public override string ToString() => $"{Name.PadRight(10)}";
}
