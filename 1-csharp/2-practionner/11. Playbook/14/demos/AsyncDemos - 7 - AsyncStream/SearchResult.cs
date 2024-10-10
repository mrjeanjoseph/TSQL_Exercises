namespace Pluralsight.CShPlaybook.AsyncDemo;

public class SearchResult
{
    public PsCourseInfo Course { get; }
    public bool IsSuccess { get; }
    public bool ContainsLinq { get; }

    public SearchResult(PsCourseInfo course, bool containsLinq, bool isSuccess)
    {
        Course = course;
        IsSuccess = isSuccess;
        ContainsLinq = containsLinq;
    }
}