public class Point
{
    public required int X { get; init; }
    public required int Y { get; init; }

    public override string ToString() => $"({X}, {Y})";
}
