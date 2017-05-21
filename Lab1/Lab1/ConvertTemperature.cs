using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class ConvertTemperature
{
    public double ConvertFahrenheitToCelsius(double temperature)
    {
        return (temperature - 32) * 5 / 9;
    }
}
}
