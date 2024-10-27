namespace Pluralsight.CShPlaybook.Generics;
public class TreeNode<T> where T : notnull
{
	public T Value { get; init; }
	private List<TreeNode<T>> _children = new();
	public TreeNode(T value) => Value = value;
	public TreeNode<T> AddChild(T newChild)
	{
		var childNode = new TreeNode<T>(newChild);
		_children.Add(childNode);
		return childNode;
	}
    public IEnumerable<(int Depth, T Value)> EnumerateSelfAndDescendantsWithDepth(int startDepth = 0)
    {
        yield return (startDepth, this.Value);
        ++startDepth;
        foreach (var child in _children)
        {
            foreach (var child2 in child.EnumerateSelfAndDescendantsWithDepth(startDepth))
                yield return child2;
        }
    }
	public IEnumerable<T> EnumerateSelfAndDescendants()
	{
		yield return this.Value;
		foreach (var child in _children)
		{
			foreach (var child2 in child.EnumerateSelfAndDescendants())
				yield return child2;
		}
	}
}
