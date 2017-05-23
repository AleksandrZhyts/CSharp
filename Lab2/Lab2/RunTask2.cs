using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
class RunTask2
{
    public void IntersectArray()
    {
        var taskInput = new Lab1.InputIntData();
        var createArray1 = new TwoArray();
        Console.WriteLine("Enter size of the array M:");
        createArray1.SizeArray = taskInput.InputData();

        var createArray2 = new TwoArray();
        Console.WriteLine("Enter size of the array N:");
        createArray2.SizeArray = taskInput.InputData();

        createArray1.InitSingleArray();
        createArray2.InitSingleArray();

        double[] array = createArray1.CreateIntersecArray(createArray1.GetSingleArray(), createArray2.GetSingleArray());
        Console.WriteLine("\nIntersect array:");
        createArray1.Print(array);
        Console.WriteLine();
    }
}
}
