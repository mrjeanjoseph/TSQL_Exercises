public class Point
{
    private int _x;
    private int _y;

    public int X
    {
        get { return _x; }
        set { _x = value; }
    }

    public int Y
    {
        get { return _y; }
        set { _y = value; }
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}
