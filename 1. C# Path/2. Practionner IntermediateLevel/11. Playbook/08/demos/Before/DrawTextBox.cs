namespace Pluralsight.CShPlaybook.DrawingStuff;
public class DrawTextBox
{
	public string Text { get; init; }
	private readonly int _zIndex;
	public int ZIndex
	{
		get => _zIndex;
	}
	public DrawTextBox(string text, int zIndex)
	{
		Text = text;
		_zIndex = zIndex.LimitToRange(0, 100);
	}
	public DrawTextBox BringForward() => new DrawTextBox(Text, _zIndex + 1);
	//public void BringForward() => _zIndex = (_zIndex + 1).LimitToRange(0, 100);
}