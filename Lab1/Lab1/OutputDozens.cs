using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class OutputDozens
{
    public void StartWrite(int digit, int units)
    {
        switch (digit)
        {
            case 2:
                Console.Write("двадцать ");
                break;
            case 3:
                Console.Write("тридцать ");
                break;
            case 4:
                Console.Write("сорок ");
                break;
            case 5:
                Console.Write("пятьдесят ");
                break;
            case 6:
                Console.Write("шестьдесят ");
                break;
            case 7:
                Console.Write("семьдесят ");
                break;
            case 8:
                Console.Write("восемьдесят ");
                break;
            case 9:
                Console.Write("девяноста ");
                break;
            case 1:
                switch (units)
                {
                    case 0:
                        Console.WriteLine("десять ");
                        break;
                    case 1:
                        Console.WriteLine("одинадцать ");
                        break;
                    case 2:
                        Console.WriteLine("двенадцать ");
                        break;
                    case 3:
                        Console.WriteLine("тринадцать ");
                        break;
                    case 4:
                        Console.WriteLine("четырнадцать ");
                        break;
                    case 5:
                        Console.WriteLine("пятнадцать ");
                        break;
                    case 6:
                        Console.WriteLine("шестнадцать ");
                        break;
                    case 7:
                        Console.WriteLine("семнадцать ");
                        break;
                    case 8:
                        Console.WriteLine("восемнадцать ");
                        break;
                    case 9:
                        Console.WriteLine("девятнадцать ");
                        break;
                }
                break;
        }
    }
}
} //namespace Lab1
