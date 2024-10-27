using System.Collections.Concurrent;

namespace Pluralsight.CShPlaybook.AsyncDemo;

public class DownloadedPages
{
    public readonly object SyncLock = new object();

    public ConcurrentDictionary<string, string> PageTexts { get; } = new();

    private int _nPagesLoaded;

    public int NPagesLoaded
    {
        get => _nPagesLoaded;
        private set => _nPagesLoaded = value;
    }

    public void Add(string courseName, string pageBody)
    {
        PageTexts.TryAdd(courseName, pageBody);
        Interlocked.Increment(ref _nPagesLoaded);
    }
}
