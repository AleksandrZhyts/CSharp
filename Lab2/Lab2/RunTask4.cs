using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
class RunTask4
{
    public void CountWords()
    {
        Console.WriteLine("Enter the string to count words:");
        string str = Console.ReadLine();
        var taskRun = new WorkWithString();
        Console.WriteLine($"\nNumber of words is {taskRun.CountWords(str)}\n");
    }
}
}
