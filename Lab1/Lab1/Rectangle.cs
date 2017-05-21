using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class Rectangle
{
    int sideA;
    int sideB;

    public void SetSides()
    {
        Console.WriteLine("Enter side A of the rectangle:");
        do
        {
            var inputData = Console.ReadLine();
            if (!int.TryParse(inputData, out sideA) || sideA <= 0)
            {
                Console.WriteLine("Invalid input. Please, repeat the input:");
            }
            else break;
        } while (true);

        Console.WriteLine("Enter side B of the rectangle:");
        do
        {
            var inputData = Console.ReadLine();
            if (!int.TryParse(inputData, out sideB) || sideB <= 0)
            {
                Console.WriteLine("Invalid input. Please, repeat the input:");
            }
            else break;
        } while (true); 
    }

    public int GetSideA()
    {
        return sideA;
    }

    public int GetSideB()
    {
        return sideB;
    }

    public int Area(int side1, int side2)
    {
        return (side1 * side2);
    }
}
}
