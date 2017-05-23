using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class InputDoubleData
{
    public double InputData()
    {
        double data;
        do
        {
            var inputData = Console.ReadLine();
            if (!double.TryParse(inputData, out data))
            {
                Console.WriteLine("Invalid input. Please, repeat the input:");
            }
            else break;
        } while (true);

        return data;
    }
}
}
