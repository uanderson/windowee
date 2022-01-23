using System.Runtime.InteropServices;

namespace Windowee.Native;

[StructLayout(LayoutKind.Sequential)]
public struct MonitorInfo
{
    public uint Size;
    public Rect Monitor;
    public Rect WorkArea;
    public uint Flags;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string DeviceName;
}