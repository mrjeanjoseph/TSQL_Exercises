namespace Pluralsight.CShPlaybook.DrawingStuff;
public readonly record struct Point(int X, int Y)
{
	public int DistSqFrom(Point other)
		=> (X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y);
	public double DistFrom(Point other) => Math.Sqrt(DistSqFrom(other));
	public override string ToString() => $"({X}, {Y})";
}