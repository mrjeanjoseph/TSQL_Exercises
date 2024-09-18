using Pluralsight.CShPlaybook.Interfaces.Demo.BusinessObjects;

public class FileLogger : ILogger
{
	private string _filePath;
	public FileLogger(string filePath)
	{
		_filePath = filePath;
	}
	public void LogState(ILoggable source)
	{
		string msg = $"{source.Name}:\r\n{source.CurrentState}\r\n\r\n";
		using StreamWriter sw = new StreamWriter(_filePath, true);
		sw.WriteLine(msg);
	} 
}

public class ConsoleLogger : ILogger
{
	public void LogState(ILoggable source)
	{
		string msg = $"{source.Name}:\r\n{source.CurrentState}\r\n\r\n";
		Console.WriteLine(msg);
	}

	public bool CanLogMethodCall => true;

	public void LogMethodCall(ILoggable source, string methodName)
	{
		string msg = $"{source.Name}: Calling method {methodName}\r\n";
		Console.WriteLine(msg);
	}
}
