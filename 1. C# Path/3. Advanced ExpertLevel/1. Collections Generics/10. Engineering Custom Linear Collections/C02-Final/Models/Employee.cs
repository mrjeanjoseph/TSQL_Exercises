namespace Models;

public class Employee
{
    public Employee(Guid id, string name)
    {
        this.Id = id;
        this.Name = name.NonEmpty(nameof(name));
    }

    public Guid Id { get; }
    public string Name { get; }

    public static IComparer<Employee> DefaultEmployeeComparer =>
        Comparer<Employee>.Create((a, b) =>
            string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));

    public override string ToString() => this.Name;
}