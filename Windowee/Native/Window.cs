using System.Runtime.InteropServices;

namespace Windowee.Native;

public static class Window
{
    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool GetWindowRect(IntPtr handle, ref Rect rect);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool repaint);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool ShowWindow(IntPtr handle, int nCmdShow);
}