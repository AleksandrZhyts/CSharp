using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondVariant
{
class Program
{
    const int HORZSIZE = 4, VERTSIZE = 6;
    const double MM_IN_INCH = 25.4;
    [DllImport("user32.dll")]
    static extern IntPtr GetDC(IntPtr hwnd);
    [DllImport("Gdi32.dll")]
    static extern int GetDeviceCaps(IntPtr Dc, int index);
    static void Main(string[] args)
    {
        IntPtr hDc = GetDC((IntPtr)null);
        int horizontal = GetDeviceCaps(hDc, HORZSIZE);
        int vertical = GetDeviceCaps(hDc, VERTSIZE);
        Console.WriteLine(Math.Sqrt((horizontal*horizontal) + (vertical*vertical)) / MM_IN_INCH);
    }
}
}
