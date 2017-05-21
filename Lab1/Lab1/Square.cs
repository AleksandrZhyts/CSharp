using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class Square
{
    int side;
 
    public void SetSide()
    {
        Console.WriteLine("Enter side of the square:");
        do
        {
            var inputData = Console.ReadLine();
            if (!int.TryParse(inputData, out side) || side <= 0)
            {
                Console.WriteLine("Invalid input. Please, repeat the input:");
            }
            else break;
        } while (true);
    }

    public int GetSide()
    {
        return side;
    }
}
}
