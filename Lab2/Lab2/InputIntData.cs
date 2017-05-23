using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class InputIntData
{
    public int InputData()
    {
        int data;
        do 
        {
            var inputData = Console.ReadLine();
            if (!int.TryParse(inputData, out data))
            {
                Console.WriteLine("Invalid input. Please, repeat the input:");
            }
            else break;
        } while (true);

        return data;
    }
}
}
