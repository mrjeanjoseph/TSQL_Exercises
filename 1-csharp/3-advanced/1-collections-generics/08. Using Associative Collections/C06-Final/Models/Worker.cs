namespace Models;

public class Worker : Employee
{
    public Worker(string name, PayRate rate) : base(name)
    {
        this.Rate = rate;
        this.HourlyRate = rate.In(TimeSpan.FromHours(1));
    }

    public PayRate Rate { get; }
    public Money HourlyRate { get; }

    public static IComparer<Worker> DefaultWorkerComparer
    {
        get
        {
            IComparer<Employee> baseComparer = Employee.DefaultEmployeeComparer;
            return Comparer<Worker>.Create((a, b) =>
                baseComparer.Compare(a, b) is int baseResult && baseResult != 0 ? baseResult
                : a.HourlyRate.CompareTo(b.HourlyRate));
        }
    }

    public static IComparer<Worker> RateComparer =>
        Comparer<Worker>.Create((a, b) => a.HourlyRate.CompareTo(b.HourlyRate));

    public override string ToString() =>
        $"{base.ToString()} ({this.Rate})";

    public Worker ScalePayRate(decimal factor) =>
        new(base.Name, this.Rate with { Pay = this.Rate.Pay.Multiply(factor) });
}
