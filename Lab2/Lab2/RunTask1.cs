using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
class RunTask1
{
    public void WorkWithArray()
    {
        var taskRun = new TwoArray();
        taskRun.SizeArray = 5;
        taskRun.countLine = 3;
        taskRun.countRow = 4;

        taskRun.InitSingleArray();
        taskRun.InitMultyArray();

        Console.WriteLine("\nA:");
        taskRun.Print();

        Console.WriteLine("\nB:");
        taskRun.PrintMultyArray();

        double maxCommonElement;
        if (taskRun.IsCommonMaxElement(out maxCommonElement))
        {
             Console.WriteLine($"\nThe maximum common element is {maxCommonElement:F2}");
        }

        double minCommonElement;
        if (taskRun.IsCommonMaxElement(out minCommonElement))
        {
            Console.WriteLine($"\nThe maximum common element is {minCommonElement:F2}");
        }

        var sum = taskRun.SumElemSingleArray() + taskRun.SumElemMultyArray();
        Console.WriteLine($"\nThe sum all elements of the array A and B is {sum:F2}");

        var multipl = taskRun.MultElemSingleArray() * taskRun.MultElemMultyArray();
        Console.WriteLine($"\nThe product all elements of the array A and B is {multipl:F2}");

        var sumEven = taskRun.SumEvenElemSingleArray();
        Console.WriteLine($"\nThe sum even elements of the array A is {sumEven:F2}");

        var sumOddRow = taskRun.SumOddRowMultyArray();
        Console.WriteLine($"\nThe sum odd rows of the array B is {sumOddRow:F2}\n");
    }
}
}
