using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask1
{
class RunTask5
{
    public void Inverse()
    {
        Console.WriteLine("Enter positive number to inverse:");
        var taskInput = new InputIntPositiveData();
        int number = taskInput.InputData();

        var taskRun = new InverseNumber();
        Console.WriteLine("Inverse number is " + taskRun.Inverse(number));
    }
}
}
