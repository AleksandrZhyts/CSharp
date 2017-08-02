using System;
using System.Runtime.InteropServices;

/*Разработать приложение, позволяющее определить размер диагонали монитора текущего компьютера в дюймах.*/

namespace SecondVariant
{
class Program
{
    class ImportWinApi
    {
        public const int HORZSIZE = 4, 
                         VERTSIZE = 6;
        public const double MM_IN_INCH = 25.4;
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("Gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr Dc, int index);
    }

    static void Main(string[] args)
    {
        IntPtr hDc = ImportWinApi.GetDC((IntPtr)null);
        int horizontal = ImportWinApi.GetDeviceCaps(hDc, ImportWinApi.HORZSIZE);
        int vertical = ImportWinApi.GetDeviceCaps(hDc, ImportWinApi.VERTSIZE);
        Console.WriteLine($"Diag = {Math.Sqrt((horizontal * horizontal) + (vertical * vertical)) / ImportWinApi.MM_IN_INCH}");
    }
}
}