using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class InputTemperature
{
    public double InputData()
    {
        Console.WriteLine("Enter the temperature in Fahrenheit: ");

        var taskInputTemperature = new InputDoubleData();

        return taskInputTemperature.InputData();
    }
}
}
