using Pluralsight.CShPlaybook.DrawingStuff;

MutablePoint3 point = new MutablePoint3(4, 4, 4);
Console.WriteLine($"Norm is {Norm(point)}");

static double Norm(in MutablePoint3 pt) => pt.DistSqFrom(new MutablePoint3(0, 0, 0));