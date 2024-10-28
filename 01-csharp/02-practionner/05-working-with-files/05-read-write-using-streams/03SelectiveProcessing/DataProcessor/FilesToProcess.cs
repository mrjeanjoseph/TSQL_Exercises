using System.Runtime.Caching;

namespace DataProcessor;

static internal class FilesToProcess
{
    public static MemoryCache Files = MemoryCache.Default;
}