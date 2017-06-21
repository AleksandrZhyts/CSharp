using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
class Polygon : Figure
{
    const string NAME = "Polygon";
 
    Point[] _arrayPoints;
    int amountPoints;

    public Polygon()
    {
        Console.Write($"Enter the number > 2 of vertices of the polygon: ");
        do
        {
            var inputData = Console.ReadLine();
            if (!int.TryParse(inputData, out amountPoints) || amountPoints < 3)
            {
                Console.WriteLine("Invalid input. Please, repeat the input:");
            }
            else break;
        } while (true);
        _arrayPoints = new Point[amountPoints];
        Init();
    }

    public Polygon(Point[] arrayPoints)
    {
        if (arrayPoints.Length > 2)
        {
            _arrayPoints = arrayPoints;
            amountPoints = arrayPoints.Length;
        }
        else
        {
            amountPoints = 3;
            _arrayPoints = new Point[amountPoints];
            Init();
        }
    }

    public void Init()
    {
        Print();
        int tempCoordinate;
        for (int i = 0; i < amountPoints; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                if (j == 0) Console.Write($"Enter coordinate X{i + 1}: ");
                else Console.Write($"Enter coordinate Y{i + 1}: ");

                do
                {
                    var inputData = Console.ReadLine();
                    if (!int.TryParse(inputData, out tempCoordinate))
                    {
                        Console.WriteLine("Invalid input. Please, repeat the input:");
                    }
                    else break;
                } while (true);

                if (j == 0) _arrayPoints[i].x = tempCoordinate;
                else _arrayPoints[i].y = tempCoordinate;
            }
        }
    }

    public int MinCoordinateX()
    {
        int min = _arrayPoints[0].x;
        for (int i = 1; i < amountPoints; i++)
        {
            if (min > _arrayPoints[i].x) min = _arrayPoints[i].x;
        }
        return min;
    }

    public int MinCoordinateY()
    {
        int min = _arrayPoints[0].y;
        for (int i = 1; i < amountPoints; i++)
        {
            if (min > _arrayPoints[i].y) min = _arrayPoints[i].y;
        }
        return min;
    }

    public int MaxCoordinateX()
    {
        int max = _arrayPoints[0].x;
        for (int i = 1; i < amountPoints; i++)
        {
            if (max < _arrayPoints[i].x) max = _arrayPoints[i].x;
        }
        return max;
    }

    public int MaxCoordinateY()
    {
        int max = _arrayPoints[0].y;
        for (int i = 1; i < amountPoints; i++)
        {
            if (max < _arrayPoints[i].y) max = _arrayPoints[i].y;
        }
        return max;
    }

    public override void Draw(ConsoleColor color)
    {
        Console.Clear();
        int dx = (MinCoordinateX() < MinCoordinateY()) ? Math.Abs(MinCoordinateX()) : Math.Abs(MinCoordinateY()) + 1;
        for (int i = 0; i < amountPoints; i++)
        {
            Console.SetCursorPosition(_arrayPoints[i].x + dx, _arrayPoints[i].y + dx);
            Console.ForegroundColor = color;
            Console.Write('.');
        }
        Console.CursorTop = dx + Math.Abs(MaxCoordinateY()) + 1;
    }

    public override bool IsExist()
    {
        return true;
    }

    public override void Print()
    {
        Console.WriteLine($"\n{NAME}");
    }
}
}
