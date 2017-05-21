using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask1
{
class RunTask4
{
    public void OutputData()
    {
        var taskInput = new InputIntPositiveData();

        Console.WriteLine("Enter first positive number :");
        int numberFirst = taskInput.InputData();

        Console.WriteLine("Enter second positive number :");
        int numberSecond = taskInput.InputData();

        if (numberFirst > numberSecond )
        {
            numberFirst ^= numberSecond;
            numberSecond ^= numberFirst;
            numberFirst ^= numberSecond;
        }
        var taskOutput = new OutputIdenticalNumbers();
        for (int i = numberFirst; i <= numberSecond; i++)
        {
            taskOutput.OutputData(i);
        }
    }
}
}
