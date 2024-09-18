namespace Pluralsight.CShPlaybook.DrawingStuff;
public class PolyLine
{
	private List<Point> _vertices = new ();
    public IReadOnlyList<Point> Vertices { get; private set; }
	public double Length { get; private set; }
    public IEnumerable<Point> EnumerateVertices()
    {
        foreach (Point vertex in Vertices)
            yield return vertex;
    }

    public PolyLine(Point start)
	{
		_vertices.Add(start);
        Vertices = _vertices.AsReadOnly();
	}
	public void AddLineTo(Point vertex)
	{
		if (vertex == _vertices[^1])
			return;
		Length += _vertices[^1].DistFrom(vertex);
		_vertices.Add(vertex);
	}
}