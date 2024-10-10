using System.Diagnostics.CodeAnalysis;

namespace Pluralsight.CShPlaybook.LinqDemos;

public class ExamResultEqualityComparer : IEqualityComparer<ExamResult>
{
	public static ExamResultEqualityComparer Instance = new ExamResultEqualityComparer();

	public bool Equals(ExamResult? x, ExamResult? y)
	{
		if (x == null && y == null)
			return true;
		if (x == null || y == null)
			return false;
		if (x.StudentId != y.StudentId && x.Subject != y.Subject)
			return false;
		if (x.Mark != y.Mark)
			throw new Exception("Found same exam result but different marks!");
		return true;
	}


	public int GetHashCode([DisallowNull] ExamResult obj)
	{
		return obj.StudentId.GetHashCode() ^ obj.Subject.GetHashCode();
	}

	private ExamResultEqualityComparer() { }
}