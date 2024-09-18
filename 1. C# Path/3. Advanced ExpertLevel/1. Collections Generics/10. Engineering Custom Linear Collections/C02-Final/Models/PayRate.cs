namespace Models;

public record PayRate : IComparable<PayRate>
{
    private TimeSpan _duration;

    public PayRate(Money pay, TimeSpan duration)
    {
        this.Pay = pay;
        this.Duration = duration;
    }

    public Money Pay { get; init; }

    public TimeSpan Duration
    {
        get => this._duration;
        init => this._duration = value.NonZero(nameof(Duration));
    }

    public int CompareTo(PayRate? other) =>
        other is null ? 1
        : this.In(TimeSpan.FromHours(1)).CompareTo(other.In(TimeSpan.FromHours(1)));

    public Money In(TimeSpan duration) =>
        duration == TimeSpan.Zero ? this.Pay with { Amount = 0 }
        : this.Pay.Divide(this.Ratio(duration));

    private decimal Ratio(TimeSpan duration) =>
        (decimal)(duration.TotalSeconds / this.Duration.TotalSeconds);

    public override string ToString() =>
        $"{this.In(TimeSpan.FromHours(1))}/h";
}