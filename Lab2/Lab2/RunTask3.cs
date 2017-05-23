using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
class RunTask3
{
    public void CheckPalindrom()
    {
        Console.WriteLine("Enter the string to check palindrom:");
        string str = Console.ReadLine();
        var taskRun = new WorkWithString();
        if (taskRun.IsPalindrom(str))
            Console.WriteLine("\nThe string is palindrom!\n");
        else
            Console.WriteLine("\nThe string isn't palindrom!\n");      
    }
}
}
