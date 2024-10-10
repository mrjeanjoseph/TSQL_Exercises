using System.Reflection;
namespace Pluralsight.CShPlaybook.Exceptions;

/// <summary>
/// Manages opening the data files that accompany this project
/// </summary>
public class DemoDataFileSet : IDisposable
{
	private const string _lockFileName = "DiyProducts-Locked.txt";
	private const string _missingFileName = "DiyProducts-Missing.txt";
	private FileStream? _lockStrm;
	private bool _disposedValue;

	public DemoDataFileSet()
	{
		// constructor tries to lock the to-be-locked file
		try
		{
			string folder = GetDataFolder();
			string lockFilePath = Path.Combine(folder, _lockFileName);
			_lockStrm = new FileStream(lockFilePath, FileMode.Open, FileAccess.Read, FileShare.None);
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Something went wrong - unable to lock the file {_lockStrm?.Name}. Exception message was {ex.Message}");
		}
	}
	public void UnlockAndCloseFile() => this._lockStrm?.Dispose();

	public (string FilePath, string FileName) AskUserChooseFilePathToRead()
	{
		while (true)
		{
			List<string> dataFiles = GetFilePaths();
			for (int i = 0; i < dataFiles.Count; i++)
				Console.WriteLine($"{i + 1}: {Path.GetFileName(dataFiles[i])}");
			Console.WriteLine("Enter the number of the file to examine>");

			bool done = int.TryParse(Console.ReadLine(), out int value);
			if (done && value >= 1 && value <= dataFiles.Count)
				return (dataFiles[value - 1], Path.GetFileName(dataFiles[value - 1]));
			else
				Console.WriteLine($"Please type in a value between 0 and {dataFiles.Count}!");
		}
	}



	public string GetCodeFolder()
	{
		string exeFolder = Assembly.GetEntryAssembly()!.Location!;
		DirectoryInfo info = new DirectoryInfo(exeFolder);
		while (info.Name != "bin")
		{
			if (info.Parent == null)
				throw new Exception("Can't find folder");
			info = info.Parent;
		}
		return info.Parent!.FullName;
	}

	public string GetDataFolder() => Path.Combine(GetCodeFolder(), "Data");

	public List<string> GetFilePaths()
	{
		string dataFolder = GetDataFolder();
		List<string> files = new();
		foreach (string file in Directory.EnumerateFiles(dataFolder, "*.txt"))
			files.Add(file);
		files.Add(Path.Combine(dataFolder, _missingFileName));
		return files;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposedValue)
		{
			if (disposing)
			{
				UnlockAndCloseFile();
			}

			// TODO: free unmanaged resources (unmanaged objects) and override finalizer
			// TODO: set large fields to null
			_disposedValue = true;
		}
	}

	// // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
	// ~Utilities()
	// {
	//     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
	//     Dispose(disposing: false);
	// }

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}