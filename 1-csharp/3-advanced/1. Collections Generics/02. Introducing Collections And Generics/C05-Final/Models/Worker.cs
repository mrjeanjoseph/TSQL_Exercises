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

    public override string ToString() =>
        $"{this.Name} ({this.HourlyRate}/h)";

    private Money HourlyRate =>
        this.Rate.In(TimeSpan.FromHours(1));
}
