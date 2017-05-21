using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class InputInteres
{
    public double InputData()
    {
        double percentDeposit;
        
        Console.WriteLine("Enter the non zero interest on the deposit: ");
        var taskInput = new InputDoubleData();
        do
        {
            percentDeposit = taskInput.InputData();
            if (percentDeposit <= 0)
            {
                Console.WriteLine("Invalid input. Please, repeat the input:");
            }
            else break;

        } while (true);

        return percentDeposit;
    }
}
}
