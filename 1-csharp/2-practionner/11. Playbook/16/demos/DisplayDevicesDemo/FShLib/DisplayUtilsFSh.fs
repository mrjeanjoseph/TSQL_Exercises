namespace Pluralsight.CShPlaybook.Interop.FShLib

open System

// using C# naming conventions to make code a bit less unfamiliar
module DisplayUtilsFSh =

    let DisplayAdapters(monitors:struct (uint*string*string) seq)  =
        Console.WriteLine "Displaying adapters in F#"
        for monitor in monitors do
            let struct (DeviceId, AdapterName, MonitorName) = monitor
            Console.WriteLine $"Device Id = {DeviceId}" 
            Console.WriteLine $"Adapter   = {AdapterName}"
            Console.WriteLine $"Monitor   = {MonitorName}" 
            Console.WriteLine ""