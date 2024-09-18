using System.Runtime.InteropServices;

namespace Pluralsight.CShPlaybook.Interop;

internal class DeviceDisplayer
{
    [DllImport("User32.dll", CharSet = CharSet.Unicode)]
    private static extern bool EnumDisplayDevices(
        string? lpDevice, uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

    public static List<(uint DeviceId, string AdapterName, string MonitorName)> FindMonitors()
    {
        List<(uint DeviceId, string AdapterName, string MonitorName)> result = new();
        var device = new DISPLAY_DEVICE();
        device.cb = (uint)Marshal.SizeOf(device);

        uint id = 0;
        do
        {
            bool ok = EnumDisplayDevices(null, id, ref device, 0);
            if (!ok)
                break;
            string adapter = device.DeviceString;

            ok = EnumDisplayDevices(device.DeviceName, 0, ref device, 0);
            if (!ok)
                break;
            string monitor = device.DeviceString;

            result.Add((id, adapter, monitor));
            ++id;
        } while (true);
        return result;
    }
}
