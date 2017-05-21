using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class OutputHudreds
{
    public void StartWrite(int digit)
    {
        switch (digit)
        {
            case 1:
                Console.Write("Сто ");
                break;
            case 2:
                Console.Write("Двести ");
                break;
            case 3:
                Console.Write("Триста ");
                break;
            case 4:
                Console.Write("Четыреста ");
                break;
            case 5:
                Console.Write("Пятьсот ");
                break;
            case 6:
                Console.Write("Шестьсот ");
                break;
            case 7:
                Console.Write("Семьсот ");
                break;
            case 8:
                Console.Write("Восемьсот ");
                break;
            case 9:
                Console.Write("Девятьсот ");
                break;
        }
    }
}
}
