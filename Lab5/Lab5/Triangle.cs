﻿using System;
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

                if (j == 0) _arrayPoints[i].x = tempCoordinate;
                else _arrayPoints[i].y = tempCoordinate; 
            }
        }
    }

    public int MinCoordinateX()
    {
        int min = _arrayPoints[0].x;
        for (int i = 1; i < AMOUNTPOINTS; i++)
        {
            if (min > _arrayPoints[i].x) min = _arrayPoints[i].x;
        }
        return min;
    }

    public int MinCoordinateY()
    {
        int min = _arrayPoints[0].y;
        for (int i = 1; i < AMOUNTPOINTS; i++)
        {
            if (min > _arrayPoints[i].y) min = _arrayPoints[i].y;
        }
        return min;
    }

    public int MaxCoordinateX()
    {
        int max = _arrayPoints[0].x;
        for (int i = 1; i < AMOUNTPOINTS; i++)
        {
            if (max < _arrayPoints[i].x) max = _arrayPoints[i].x;
        }
        return max;
    }

    public int MaxCoordinateY()
    {
        int max = _arrayPoints[0].y;
        for (int i = 1; i < AMOUNTPOINTS; i++)
        {
            if (max < _arrayPoints[i].y) max = _arrayPoints[i].y;
        }
        return max;
    }

    public override void Draw(ConsoleColor color)
    {
        Console.Clear();
        int dx = (MinCoordinateX() < MinCoordinateY()) ? Math.Abs(MinCoordinateX()) : Math.Abs(MinCoordinateY()) + 1;
        for (int i = 0; i < AMOUNTPOINTS; i++)
        {
            Console.SetCursorPosition(_arrayPoints[i].x + dx, _arrayPoints[i].y + dx);
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
        sideA = Math.Sqrt(Math.Pow((_arrayPoints[1].x - _arrayPoints[0].x), 2) + Math.Pow((_arrayPoints[1].y - _arrayPoints[0].y), 2));
        sideB = Math.Sqrt(Math.Pow((_arrayPoints[2].x - _arrayPoints[1].x), 2) + Math.Pow((_arrayPoints[2].y - _arrayPoints[1].y), 2));
        sideC = Math.Sqrt(Math.Pow((_arrayPoints[2].x - _arrayPoints[0].x), 2) + Math.Pow((_arrayPoints[2].y - _arrayPoints[0].y), 2));
    }

    public override void Print()
    {
        Console.WriteLine($"\n{NAME}");
    }
}
}
