using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask1
{
class Program
{
    static void Main(string[] args)
    {
        var task1 = new RunTask1();
        task1.RunCount();

        var task2 = new RunTask2();
        task2.RunChek();

        var task3 = new RunTask3();
        task3.ConvertSymbols();

        var task4 = new RunTask4();
        task4.OutputData();

        var task5 = new RunTask5();
        task5.Inverse();
    }
}
}
