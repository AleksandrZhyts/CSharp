using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class Program
{
    static void Main(string[] args)
    {
        var task1 = new RunTask1();
        task1.RunConvertValue();

        var task2 = new RunTask2();
        task2.RunCalculate();

        var task3 = new RunTask3();
        task3.RunWriteNumber();

        var task4 = new RunTask4();
        task4.RunCalculate();

        var task5 = new RunTask5();
        task5.RunCalculateDeposit();

    }
}
}
