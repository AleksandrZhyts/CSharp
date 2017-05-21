using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class OutputUnits
{
    public void StartWrite(int digit)
    {
            switch (digit)
            {
                case 1:
                    Console.WriteLine("один ");
                    break;
                case 2:
                    Console.WriteLine("два ");
                    break;
                case 3:
                    Console.WriteLine("три ");
                    break;
                case 4:
                    Console.WriteLine("четыре ");
                    break;
                case 5:
                    Console.WriteLine("пять ");
                    break;
                case 6:
                    Console.WriteLine("шесть ");
                    break;
                case 7:
                    Console.WriteLine("семь ");
                    break;
                case 8:
                    Console.WriteLine("восемь ");
                    break;
                case 9:
                    Console.WriteLine("девять ");
                    break;
            }
        }
    }
}
