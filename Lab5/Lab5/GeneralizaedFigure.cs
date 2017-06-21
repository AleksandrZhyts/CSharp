using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
class GeneralizaedFigure
{
    Figure[] _arrayFigures;
    int _sizeArray;

    List<int> NumbersFiguresList, 
                NumbersColorsList;

    public GeneralizaedFigure()
    {
        NumbersFiguresList = new List<int>();
        NumbersColorsList = new List<int>();
        MenuFigure();
        MenuColor();
        _sizeArray = (int)NumbersFiguresList.LongCount();
        _arrayFigures = new Figure[_sizeArray];
        Init();
    }

    private void Init()
    {
        EnumFiguresColors.ListFigures figures;
        for (int i = 0; i < NumbersFiguresList.LongCount(); i++)
        {
            int x = NumbersFiguresList[i];
            figures = (EnumFiguresColors.ListFigures)Enum.GetValues(typeof(EnumFiguresColors.ListFigures)).GetValue(NumbersFiguresList[i]);  
            switch (figures)
            {
                case EnumFiguresColors.ListFigures.triangle:
                    Point[] arrTrg = new Point[3] {new Point( 0, 0 ), new Point( 2, 3 ), new Point( 3, -4 )};
                    _arrayFigures[i] = new Triangle(arrTrg);
                    break;
                case EnumFiguresColors.ListFigures.parallelogram:
                    Point[] arrPar = new Point[4] {new Point( 0, 0 ), new Point( 3, 2 ), new Point( 6, 2 ), new Point( 3, 0 )};
                    _arrayFigures[i] = new Parallelogram(arrPar);
                    break;
                case EnumFiguresColors.ListFigures.trapezium:
                    Point[] arrTrz = new Point[4] {new Point( 0, 0 ), new Point( 3, 2 ), new Point( 6, 2 ), new Point( 7, 0 )};
                    _arrayFigures[i] = new Trapezium(arrTrz);
                    break;
                case EnumFiguresColors.ListFigures.rhombus:
                    Point[] arrRmb = new Point[4] {new Point( -3, 0 ), new Point( 0, 3 ), new Point( 3, 0 ), new Point( 0, -3 )};
                    _arrayFigures[i] = new Rhombus(arrRmb);
                    break;
                case EnumFiguresColors.ListFigures.polygon:
                    _arrayFigures[i] = new Polygon();
                    break;
            }
        }
    }

    public void Draw()
    {
        EnumFiguresColors.Color color;
        for (int i = 0; i < _sizeArray; i++)
        {
            if (i < NumbersColorsList.LongCount())
            {
                color = (EnumFiguresColors.Color)Enum.GetValues(typeof(EnumFiguresColors.Color)).GetValue(NumbersColorsList[i]);                  
            }
            else
            {
                color = (EnumFiguresColors.Color)Enum.GetValues(typeof(EnumFiguresColors.Color)).GetValue(NumbersColorsList[0]);
            }
            if (_arrayFigures[i].IsExist()) _arrayFigures[i].Draw((ConsoleColor)color);
            _arrayFigures[i].Print();
            Console.ReadKey();
        }
    }

    private void MenuFigure()
    {
        Console.WriteLine("Draw:\n\t0 - triangle\n\t1 - parallelogram\n\t2 - trapezium\n\t3 - rhombus\n\t4 - polygon");
        Console.Write("Make a selection separated by a comma: ");
        string[] arrayChars = Console.ReadLine().Split(",. ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        foreach (string choiseChar in arrayChars)
        {
            int choiseInt;
            if (!int.TryParse(choiseChar, out choiseInt))
                throw new ArgumentException("Argument invalid!");
            else
                if ((choiseInt >= 0) && (choiseInt < 5)) NumbersFiguresList.Add(choiseInt);
                else NumbersFiguresList.Add(1);
        }
    }

    private void MenuColor()
    {
        Console.WriteLine("Colors:\n\t0 - gray\n\t1 - blue\n\t2 - green\n\t3 - red\n\t4 - yellow\n\t5 - white");
        Console.Write("Make a selection separated by a comma: ");
        string[] arrayChars = Console.ReadLine().Split(",. ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        foreach (string choiseChar in arrayChars)
        {
            int choiseInt;
            if (!int.TryParse(choiseChar, out choiseInt))
                throw new ArgumentException("Argument invalid!");
            else
                if ((choiseInt >= 0) && (choiseInt < 6)) NumbersColorsList.Add(choiseInt);
            else NumbersColorsList.Add(1);
        }
    }
}
}
