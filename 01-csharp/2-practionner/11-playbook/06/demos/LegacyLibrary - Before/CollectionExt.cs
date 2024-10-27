using System.Text;

namespace Pluralsight.CShPlaybook.NullValues;
public static class CollectionExt
{
	public static TValue GetValueOrNull<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
		where TValue : class
	{
		bool done = dict.TryGetValue(key, out TValue value);
		if (!done)
			return null;
		return value;
	}

	public static string MakeStringList<T>(this IReadOnlyList<T> lst)
	{
		string separator = ", ";

		if (lst == null || lst.Count == 0)
			return string.Empty;
		if (lst.Count == 1)
			return lst[0].ToString();

		StringBuilder sb = new StringBuilder();
		sb.Append(lst[0].ToString());
		for (int i = 1; i < lst.Count; i++)
			sb.Append(separator + lst[i].ToString());

		return sb.ToString();
	}
}
