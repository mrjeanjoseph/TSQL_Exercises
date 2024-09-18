namespace Pluralsight.CShPlaybook.Interfaces.Demo.BusinessObjects;

public interface ILogger
{
	void LogState(ILoggable source);
	void LogMethodCall(ILoggable source, string methodName) 
		=> throw new NotImplementedException(nameof(LogMethodCall));

	bool CanLogMethodCall { get => false; }

	bool TryLogMethodCall(ILoggable source, string methodName)
	{
		bool canLog = CanLogMethodCall;
		if (canLog)
			LogMethodCall(source, methodName);
		return canLog;
	}
}

public interface ILoggable
{
	// Should return a string that uniquely identifies the object being logged.
	string Name { get; }

	// Should return a string representation of current state of the object
	string CurrentState { get; }
}
