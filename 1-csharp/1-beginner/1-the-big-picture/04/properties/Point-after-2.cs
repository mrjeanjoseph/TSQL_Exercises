public class Point
{
    public int X { get; init; }
    public int Y { get; init; }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}
