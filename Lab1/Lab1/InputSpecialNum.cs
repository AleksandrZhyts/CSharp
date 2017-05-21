using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class InputSpecialNum
    {
        public int InputData()
        {
            int num;

            Console.WriteLine("Enter a number to write, more than 100 but less 999: ");
            var taskInput = new InputIntData();
            do
            {
                num = taskInput.InputData();
                if (num < 100 || num > 999)
                {
                    Console.WriteLine("Invalid input. Please, repeat the input:");
                }
                else break;

            } while (true);

            return num;
        }
    }
}
