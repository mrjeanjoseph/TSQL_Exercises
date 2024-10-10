namespace Pluralsight.CShPlaybook.DrawingStuff;
public class PolyLine
{
	public List<Point> Vertices { get; private set; } = new List<Point>();
	public double Length { get; private set; }
	public PolyLine(Point start)
	{
		Vertices.Add(start);
	}
	public void AddLineTo(Point vertex)
	{
		if (vertex == Vertices[^1])
			return;
		Length += Vertices[^1].DistFrom(vertex);
		Vertices.Add(vertex);
	}
}