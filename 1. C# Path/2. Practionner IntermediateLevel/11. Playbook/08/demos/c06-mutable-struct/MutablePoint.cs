namespace Pluralsight.CShPlaybook.DrawingStuff;
public record struct MutablePoint3(double X, double Y, double Z)
{
	public double DistSqFrom(in MutablePoint3 other)
		=> (X - other.X) * (X - other.X) + (Y - other.Y) * (Y - other.Y)
		+ (Z - other.Z) * (Z - other.Z);
	public double DistFrom(in MutablePoint3 other) => Math.Sqrt(DistSqFrom(other));
	public override string ToString() => $"({X}, {Y})";
}

