using System.Diagnostics;
using System.Runtime.InteropServices;
using Windowee.Native;
using Windowee.Settings;
using Monitor = Windowee.Native.Monitor;
using Window = Windowee.Native.Window;

namespace Windowee;

public class Resizer
{
    private MonitorInfo monitorInfo;

    public bool MonitorEnum(IntPtr hMonitor, IntPtr hdcMonitor, ref Rect lprcMonitor, IntPtr dwData)
    {
        var currentMonitorInfo = new MonitorInfo();
        currentMonitorInfo.Size = (uint) Marshal.SizeOf(currentMonitorInfo);

        Monitor.GetMonitorInfo(hMonitor, ref currentMonitorInfo);
        monitorInfo = currentMonitorInfo;

        return true;
    }

    public void Execute()
    {
        Monitor.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero, MonitorEnum, IntPtr.Zero);

        var setting = Settings.Settings.Parse();

        if (setting.Mode == Mode.Listed)
        {
            HandleListed(setting);
        }
        else
        {
            MaximizeAll();
        }
    }

    private void HandleListed(Setting setting)
    {
        var monitorWidth = monitorInfo.Monitor.Right;
        var monitorHeight = monitorInfo.Monitor.Bottom;

        var processes = Process.GetProcesses();

        foreach (var process in processes)
        {
            var handle = process.MainWindowHandle;
            var rect = new Rect();

            if (!Window.GetWindowRect(handle, ref rect))
            {
                continue;
            }

            var window = setting.Windows.Find(window => process.ProcessName.ToLower().Contains(window.Name.ToLower()));

            if (window == null)
            {
                continue;
            }

            var position = window.CalculatePosition(monitorWidth, monitorHeight);

            Window.ShowWindow(handle, 1);
            Window.MoveWindow(handle, position.X, position.Y, position.Width, position.Height, true);
        }
    }

    private void MaximizeAll()
    {
        var processes = Process.GetProcesses();

        foreach (Process process in processes)
        {
            var handle = process.MainWindowHandle;
            var rect = new Rect();

            if (Window.GetWindowRect(handle, ref rect))
            {
                Window.ShowWindow(handle, 3);
            }
        }
    }
}