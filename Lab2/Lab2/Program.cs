using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
class Program
{
    static void Main(string[] args)
    {
        var task1 = new RunTask1();
        task1.WorkWithArray();

        var task2 = new RunTask2();
        task2.IntersectArray();

        var task3 = new RunTask3();
        task3.CheckPalindrom();

        var task4 = new RunTask4();
        task4.CountWords();

        var task5 = new RunTask5();
        task5.SumElemArray();
    }
}
}
