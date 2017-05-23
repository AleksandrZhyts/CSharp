using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
class RunTask5
{
    public void SumElemArray()
    {
        var taskRun = new TwoArray();
        taskRun.countLine = 5;
        taskRun.countRow = 5;
        taskRun.leftBoderToRand = -100;
        taskRun.rightBoderToRand = 100;
        taskRun.fraction = 1;
        taskRun.InitMultyArray();
        taskRun.PrintMultyArray();
        Console.WriteLine($"\nThe sum elements between min and max = {taskRun.SumBetweenMinMax():F0}");
    }
}
}
