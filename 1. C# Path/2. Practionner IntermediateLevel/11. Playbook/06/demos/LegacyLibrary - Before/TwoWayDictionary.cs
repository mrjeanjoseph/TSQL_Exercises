using System.Collections.ObjectModel;

namespace Pluralsight.CShPlaybook.NullValues;
public class TwoWayReadOnlyDictionary<T1, T2> 
{
	public ReadOnlyDictionary<T1, T2> ForwardDict { get; private init; }
	public ReadOnlyDictionary<T2, T1> ReverseDict { get; private init; }

	public TwoWayReadOnlyDictionary(IDictionary<T1, T2> forwardValues)
	{
		var forwardDict = new Dictionary<T1, T2>();
		var reverseDict = new Dictionary<T2, T1>();
		foreach (var pair in forwardValues)
		{
			forwardDict.Add(pair.Key, pair.Value);
			reverseDict.Add(pair.Value, pair.Key);
		}
		ForwardDict = new ReadOnlyDictionary<T1, T2>(forwardDict);
		ReverseDict = new ReadOnlyDictionary<T2, T1>(reverseDict);
	}
}