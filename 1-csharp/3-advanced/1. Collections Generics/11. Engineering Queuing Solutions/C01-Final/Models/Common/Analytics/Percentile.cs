namespace Models.Common.Analytics;

public record Percentile<T>(float Position, T Value)
{
    public override string ToString() =>
        $"{this.Position*100,6:0.00}% {this.Value}";
}