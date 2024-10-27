using Pluralsight.CShPlaybook.DrawingStuff;

PolyLine shape = new PolyLine(new Point());
Point point1 = new Point(2, 0);
Point point2 = new Point(2, 2);
Point point3 = new Point(0, 2);
Point point4 = new Point(0, 0);

shape.AddLineTo(point1);
shape.AddLineTo(point2);
shape.AddLineTo(point3);
shape.AddLineTo(point4);
Console.WriteLine($"Length of shape is {shape.Length}");
foreach (Point pt in shape.EnumerateVertices())
    Console.WriteLine(pt);
