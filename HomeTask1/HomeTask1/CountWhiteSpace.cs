using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask1
{
class CountWhiteSpace
{
    public uint WhiteSpace()
    {
        uint countWhiteSpace = 0;
        const char stopInput = '.';

        Console.WriteLine("Enter symbols:");
        char symbol = Console.ReadKey().KeyChar;

        while (!symbol.Equals(stopInput))
        {
            if (char.IsWhiteSpace(symbol)) ++countWhiteSpace;
            symbol = Console.ReadKey().KeyChar;
        }
        return countWhiteSpace;
    }
}
}
