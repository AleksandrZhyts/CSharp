using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            
            Пришлось изменить файл манифеста, чтобы Windows корректно выдавал размеры экрана без учёта масштабирования
            <application xmlns="urn:schemas-microsoft-com:asm.v3">
                <windowsSettings>
                    <dpiAware xmlns="http://schemas.microsoft.com/SMI/2005/WindowsSettings">true</dpiAware>
                </windowsSettings>
            </application>
            */

            int height = WinApi.GetSystemMetrics(SystemMetric.SM_CXSCREEN);
            int weight = WinApi.GetSystemMetrics(SystemMetric.SM_CYSCREEN);

            IntPtr desktopDc = WinApi.GetDC(IntPtr.Zero);

            double x_dpi = WinApi.GetDeviceCaps(desktopDc, (int)DeviceCap.LOGPIXELSX); ;
            double y_dpi = WinApi.GetDeviceCaps(desktopDc, (int)DeviceCap.LOGPIXELSY); ;

            WriteLine(height);
            WriteLine(weight);
            WriteLine(x_dpi);
            WriteLine(y_dpi);
            WriteLine(Math.Sqrt((Math.Pow((double)height / x_dpi, 2) + Math.Pow((double)weight / y_dpi, 2))));

            // Так и не получилось получить реальный dpi для монитора. В зависимости от коэффициента масштабирования
            // экрана мне возвращало 3 разных dpi - 96 (100%), 120 (125%) и 144 (150%).
            // Последний и является реальным физическим dpi монитора, но подтвертить это программно не представляется возможным.

            ReadKey();
        }

        class WinApi
        {
            [DllImport("user32.dll")]
            public static extern int GetSystemMetrics(SystemMetric smIndex);

            [DllImport("user32.dll", EntryPoint = "GetDC")]
            public static extern IntPtr GetDC(IntPtr hWnd);

            [DllImport("gdi32.dll")]
            public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        }
    }
}