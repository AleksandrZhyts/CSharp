using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
class Triangle : Figure
{
    const string NAME = "Triangle";
    const int AMOUNTPOINTS = 3;

    Point[] _arrayPoints;
    
    public Triangle()
    {
        _arrayPoints = new Point[AMOUNTPOINTS];
        Init();
    }

    public Triangle(Point[] arrayPoints)
    {
        if (arrayPoints.Length == AMOUNTPOINTS)
        {
            _arrayPoints = arrayPoints;
        }
        else
        {
            _arrayPoints = new Point[AMOUNTPOINTS];
            Init();
        }
    }

    public void Init()
    {
        Print();
        int tempCoordinate;
        for (int i = 0; i < AMOUNTPOINTS; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (j == 0) Console.Write($"Enter coordinate X{i+1}: ");
                else Console.Write($"Enter coordinate Y{i+1}: ");

                do
                {
                    var inputData = Console.ReadLine();
                    if (!int.TryParse(inputData, out tempCoordinate))
                    {
                        Console.WriteLine("Invalid input. Please, repeat the input:");
                    }
                    else break;
                } while (true);

                if (j == 0) _arrayPoints[i]._x = tempCoordinate;
                else _arrayPoints[i]._y = tempCoordinate; 
            }
        }
    }

    public int MinCoordinateX()
    {
        int min = _arrayPoints[0]._x;
        for (int i = 1; i < AMOUNTPOINTS; i++)
        {
            if (min > _arrayPoints[i]._x) min = _arrayPoints[i]._x;
        }
        return min;
    }

    public int MinCoordinateY()
    {
        int min = _arrayPoints[0]._y;
        for (int i = 1; i < AMOUNTPOINTS; i++)
        {
            if (min > _arrayPoints[i]._y) min = _arrayPoints[i]._y;
        }
        return min;
    }

    public int MaxCoordinateX()
    {
        int max = _arrayPoints[0]._x;
        for (int i = 1; i < AMOUNTPOINTS; i++)
        {
            if (max < _arrayPoints[i]._x) max = _arrayPoints[i]._x;
        }
        return max;
    }

    public int MaxCoordinateY()
    {
        int max = _arrayPoints[0]._y;
        for (int i = 1; i < AMOUNTPOINTS; i++)
        {
            if (max < _arrayPoints[i]._y) max = _arrayPoints[i]._y;
        }
        return max;
    }

    public override void Draw(ConsoleColor color)
    {
        Console.Clear();
        int dx = (MinCoordinateX() < MinCoordinateY()) ? Math.Abs(MinCoordinateX()) : Math.Abs(MinCoordinateY()) + 1;
        for (int i = 0; i < AMOUNTPOINTS; i++)
        {
            Console.SetCursorPosition(_arrayPoints[i]._x + dx, _arrayPoints[i]._y + dx);
            Console.ForegroundColor = color;
            Console.Write('.');
        }
        Console.CursorTop = dx + Math.Abs(MaxCoordinateY()) + 1;
    }

    public override bool IsExist()
    {
        double sideA, 
               sideB,
               sideC;
        GetSides(out sideA, out sideB, out sideC);
        return ((sideA + sideB > sideC) && (sideB + sideC > sideA) && (sideA + sideC > sideB));
    }

    public void GetSides(out double sideA, out double sideB, out double sideC)
    {
        sideA = Math.Sqrt(Math.Pow((_arrayPoints[1]._x - _arrayPoints[0]._x), 2) + Math.Pow((_arrayPoints[1]._y - _arrayPoints[0]._y), 2));
        sideB = Math.Sqrt(Math.Pow((_arrayPoints[2]._x - _arrayPoints[1]._x), 2) + Math.Pow((_arrayPoints[2]._y - _arrayPoints[1]._y), 2));
        sideC = Math.Sqrt(Math.Pow((_arrayPoints[2]._x - _arrayPoints[0]._x), 2) + Math.Pow((_arrayPoints[2]._y - _arrayPoints[0]._y), 2));
    }

    public override void Print()
    {
        Console.WriteLine($"\n{NAME}");
    }
}
}
