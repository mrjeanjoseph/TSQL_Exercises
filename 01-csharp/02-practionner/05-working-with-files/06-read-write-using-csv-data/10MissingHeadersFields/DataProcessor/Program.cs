using DataProcessor;
using System.Runtime.Caching;
using static System.Console;

WriteLine("Parsing command line options");

var directoryToWatch = args[0];

// Command line validation omitted for brevity

if (!Directory.Exists(directoryToWatch))
{
    WriteLine($"ERROR: {directoryToWatch} does not exist");
    WriteLine("Press enter to quit.");
    ReadLine();
    return;
}

ProcessExistingFiles(directoryToWatch);

WriteLine($"Watching directory {directoryToWatch} for changes");
using var inputFileWatcher = new FileSystemWatcher(directoryToWatch);

inputFileWatcher.IncludeSubdirectories = false;
inputFileWatcher.InternalBufferSize = 32_768; // 32 KB
inputFileWatcher.Filter = "*.*"; // this is the default
inputFileWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;

inputFileWatcher.Created += FileCreated;
inputFileWatcher.Changed += FileChanged;
inputFileWatcher.Deleted += FileDeleted;
inputFileWatcher.Renamed += FileRenamed;
inputFileWatcher.Error += WatcherError;

inputFileWatcher.EnableRaisingEvents = true;

WriteLine("Press enter to quit.");
ReadLine();

static void FileCreated(object sender, FileSystemEventArgs e)
{
    WriteLine($"* File created: {e.Name} - type: {e.ChangeType}");

    AddToCache(e.FullPath);
}

static void FileChanged(object sender, FileSystemEventArgs e)
{
    WriteLine($"* File changed: {e.Name} - type: {e.ChangeType}");

    AddToCache(e.FullPath);
}

static void FileDeleted(object sender, FileSystemEventArgs e)
{
    WriteLine($"* File deleted: {e.Name} - type: {e.ChangeType}");
}

static void FileRenamed(object sender, RenamedEventArgs e)
{
    WriteLine($"* File renamed: {e.OldName} to {e.Name} - type: {e.ChangeType}");
}

static void WatcherError(object sender, ErrorEventArgs e)
{
    WriteLine($"ERROR: file system watching may no longer be active: {e.GetException()}");
}


static void AddToCache(string fullPath)
{
    var item = new CacheItem(fullPath, fullPath);

    var policy = new CacheItemPolicy
    {
        RemovedCallback = ProcessFile,
        SlidingExpiration = TimeSpan.FromSeconds(2)
    };

    FilesToProcess.Files.Add(item, policy);
}

static void ProcessFile(CacheEntryRemovedArguments args)
{
    WriteLine($"* Cache item removed: {args.CacheItem.Key} because {args.RemovedReason}");

    if (args.RemovedReason == CacheEntryRemovedReason.Expired)
    {
        var fileProcessor = new FileProcessor(args.CacheItem.Key);
        fileProcessor.Process();
    }
    else
    {
        WriteLine($"WARNING: {args.CacheItem.Key} was removed unexpectedly and may not be processed because {args.RemovedReason}");
    }
}

static void ProcessExistingFiles(string inputDirectory)
{
    WriteLine($"Checking {inputDirectory} for existing files");

    foreach (var filePath in Directory.EnumerateFiles(inputDirectory))
    {
        WriteLine($"  - Found {filePath}");
        AddToCache(filePath);
    }
}