using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask1
{
class InputNumberTicket
{
    public int InputData()
    {
        Console.WriteLine("Enter the six-digit ticket number :");
        var taskInput = new InputIntPositiveData();
        int numberTicket = taskInput.InputData();
        do
        {  
            if (numberTicket < 100000 || numberTicket > 999999)
            {
                Console.WriteLine("Invalid input. Please, repeat the input:");
                numberTicket = taskInput.InputData();
            }
            else break;
        } while (true);

        return numberTicket;
    }
}
}
