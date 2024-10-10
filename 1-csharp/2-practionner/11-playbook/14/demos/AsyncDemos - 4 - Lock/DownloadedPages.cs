namespace Pluralsight.CShPlaybook.AsyncDemo;

public class DownloadedPages
{
    public readonly object SyncLock = new object();

    public Dictionary<string, string> PageTexts { get; } = new();

    public int NPagesLoaded { get; set; }

    public void Add(string courseName, string pageBody)
    {
        lock (SyncLock)
        {
            PageTexts.Add(courseName, pageBody);
            ++NPagesLoaded;
        }
    }
}
