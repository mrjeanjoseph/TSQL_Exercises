using System.Collections.Concurrent;

namespace Pluralsight.CShPlaybook.AsyncDemo;

public class DownloadedPages
{
    public Dictionary<string, string> PageTexts { get; } = new();

    public int NPagesLoaded { get; set; }

    public void Add(string courseName, string pageBody)
    {
        PageTexts.Add(courseName, pageBody);
        ++NPagesLoaded;
    }
}
