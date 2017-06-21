using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class Triangle
{
    double[] arrayCoordinates;
    const int size = 6;

    public Triangle()
    {
        arrayCoordinates = new double[size];
    }

    public void InitTriangle()
    {
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine("Enter the " + (i + 1) + " coordinate:");
            do
            {
                var inputData = Console.ReadLine();
                if (!double.TryParse(inputData, out arrayCoordinates[i]))
                {
                    Console.WriteLine("Invalid input. Please, repeat the input:");
                }
                else break;
            } while (true);
        }
    }

    public bool IsTriangle(double side1, double side2, double side3)
    {
        return ((side1 + side2 > side3) && (side2 + side3 > side1) && (side1 + side3 > side2));
    }

    public double GetSideA()
    {
        double x0 = arrayCoordinates[0];
        double y0 = arrayCoordinates[1];
        double x1 = arrayCoordinates[2];
        double y1 = arrayCoordinates[3];
        double sideA = Math.Sqrt(Math.Pow((x1 - x0), 2) + Math.Pow((y1 - y0), 2));
        return sideA;
    }

    public double GetSideB()
    {
        double x1 = arrayCoordinates[2];
        double y1 = arrayCoordinates[3];
        double x2 = arrayCoordinates[4];
        double y2 = arrayCoordinates[5];
        double sideB = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        return sideB;
    }

    public double GetSideC()
    {
        double x0 = arrayCoordinates[0];
        double y0 = arrayCoordinates[1];
        double x2 = arrayCoordinates[4];
        double y2 = arrayCoordinates[5];
        double sideC = Math.Sqrt(Math.Pow((x2 - x0), 2) + Math.Pow((y2 - y0), 2));
        return sideC;
    }

    public double Perimetr(double side1, double side2, double side3)
    {
        return (side1 + side2 + side3);
    }

    public double Area(double side1, double side2, double side3)
    {
        double perimetr = Perimetr(side1, side2, side3);
        double halfPerimetr = perimetr / 2;
        return Math.Sqrt(halfPerimetr * (halfPerimetr - side1) * (halfPerimetr - side2) * (halfPerimetr - side3));
    }
}
}
