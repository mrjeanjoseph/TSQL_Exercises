using System.Collections.Concurrent;

namespace DataProcessor;

static internal class FilesToProcess
{
    public static ConcurrentDictionary<string, string> Files = new();
}