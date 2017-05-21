using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class RunTask4
{
    public void RunCalculate()
    {
        var taskRect = new Rectangle();
        taskRect.SetSides();
        int sideA = taskRect.GetSideA();
        int sideB = taskRect.GetSideB();

        var taskSquare = new Square();
        taskSquare.SetSide();
        int sideSquare = taskSquare.GetSide();

        int countSquare = (sideB / sideSquare) * (sideA / sideSquare);

        if (countSquare > 0)
        {
            int sRectangle = taskRect.Area(sideA, sideB);
            int sSquare = sideSquare * sideSquare;
            int areaDifference = sRectangle - countSquare * sSquare;
            Console.WriteLine($"\nThe number of squares = {countSquare} and the remaining area = {areaDifference}");
        }
            else
            {
                Console.WriteLine($"In a rectangle, you can not place any square with side: {sideSquare}");
            }
    }
}
}
