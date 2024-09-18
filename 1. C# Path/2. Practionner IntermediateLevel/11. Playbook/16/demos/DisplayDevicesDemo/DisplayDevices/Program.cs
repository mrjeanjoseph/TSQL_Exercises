using Pluralsight.CShPlaybook.Interop;
using Pluralsight.CShPlaybook.Interop.VBLib;
using Pluralsight.CShPlaybook.Interop.FShLib;

var monitors = DeviceDisplayer.FindMonitors();

DisplayAdapters(monitors); // C# version
//DisplayUtilsVB.DisplayAdapters(monitors); // VB version
//DisplayUtilsFSh.DisplayAdapters(monitors); // F# version

void DisplayAdapters(IEnumerable<(uint DeviceId, string AdapterName, string MonitorName)> monitors)
{
	foreach (var monitor in monitors)
	{
		Console.WriteLine($"Device Id = {monitor.DeviceId}");
		Console.WriteLine($"Adapter   = {monitor.AdapterName}");
		Console.WriteLine($"Monitor   = {monitor.MonitorName}");
		Console.WriteLine();
	}
}

