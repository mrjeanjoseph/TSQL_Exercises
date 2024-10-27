namespace Models;

public class Worker
{
    public Worker(string name, PayRate rate)
    {
        this.Name = name.NonEmpty(nameof(name));
        this.Rate = rate;
    }

    public string Name { get; }
    public PayRate Rate { get; }

    public static IComparer<Worker> RateComparer =>
        Comparer<Worker>.Create((a, b) => a.Rate.CompareTo(b.Rate));

    public override string ToString() =>
        $"{this.Name} ({this.Rate})";

    public Worker ScalePayRate(decimal factor) =>
        new(this.Name, this.Rate with { Pay = this.Rate.Pay.Multiply(factor) });
}
