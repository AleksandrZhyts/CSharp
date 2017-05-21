using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class RunTask1
{
    public void RunConvertValue()
    {
        var taskInput = new InputTemperature();
        var tempratureF = taskInput.InputData();

        var taskConvert = new ConvertTemperature();
        var tempratureC = taskConvert.ConvertFahrenheitToCelsius(tempratureF);

        Console.WriteLine(String.Format("{0} F = {1:F2} C",tempratureF, tempratureC));
    }
}
}
