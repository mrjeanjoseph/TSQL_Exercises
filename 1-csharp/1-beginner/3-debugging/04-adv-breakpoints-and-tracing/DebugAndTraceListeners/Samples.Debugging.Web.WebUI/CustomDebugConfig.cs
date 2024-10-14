using System.Diagnostics;

namespace Samples.Debugging.Web.WebUI
{
    public class CustomDebugConfig
    {
        public static void ConfigureTraceListeners()
        {
            string diagnosticsFilesPath = @"C:\diagnosticsfiles";

            if (!Directory.Exists(diagnosticsFilesPath))
            {
                DirectoryInfo di = Directory.CreateDirectory(diagnosticsFilesPath);
                Console.WriteLine("Directory {0} successfully created.", diagnosticsFilesPath);
            }

            // Create TraceListeners

            DefaultTraceListener defaultListener = new DefaultTraceListener();
            // defaultListener.LogFileName = Path.Combine(diagnosticsFilesPath, "DefaultListener_output.txt");

            ConsoleTraceListener consoleListener = new ConsoleTraceListener();

            TextWriterTraceListener textWriterListener = 
                new TextWriterTraceListener(Path.Combine(diagnosticsFilesPath, "TextWriterTraceListener_output.txt"));

            XmlWriterTraceListener xmlListener = new XmlWriterTraceListener(
                Path.Combine(diagnosticsFilesPath, "XmlWriterTraceListener_output.xml"));

            EventLogTraceListener eventLogListener = 
                new EventLogTraceListener(".NET Runtime");

            // Add TraceListeners to collections
            // remove default tracelistener
            Trace.Listeners.RemoveAt(0);

            Trace.Listeners.Add(defaultListener);
            Trace.Listeners.Add(consoleListener);
            Trace.Listeners.Add(textWriterListener);
            Trace.Listeners.Add(xmlListener);
            Trace.Listeners.Add(eventLogListener);

            Trace.AutoFlush = true;
        }
    }
}
