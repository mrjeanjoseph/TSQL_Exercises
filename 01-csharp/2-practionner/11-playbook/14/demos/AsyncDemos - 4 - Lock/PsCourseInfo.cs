namespace Pluralsight.CShPlaybook.AsyncDemo;

public class PsCourseInfo
{
    public string Name { get; }
    public string Path { get; }

    public PsCourseInfo(string name, string path)
    {
        Name = name;
        Path = path;
    }

    private static string _prefix = "https://app.pluralsight.com/library/courses/";
    private static string _toc = "/table-of-contents";
    public string Url => _prefix + Path + _toc;
}
