
Public Class DisplayUtilsVB

	Shared Sub DisplayAdapters(monitors As List(Of (DeviceId As UInteger, AdapterName As String, MonitorName As String)))

		Console.WriteLine("Displaying adapters in VB")
		For Each monitor In monitors
			Console.WriteLine(monitor)
			Console.WriteLine($"Device Id = {monitor.DeviceId}")
			Console.WriteLine($"Adapter   = {monitor.AdapterName}")
			Console.WriteLine($"Monitor   = {monitor.MonitorName}")
			Console.WriteLine()
		Next

	End Sub

End Class


