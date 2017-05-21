using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask1
{
class RunTask3
{
    public void ConvertSymbols()
    {
        Console.WriteLine("Enter string to convert symbols:");
        var startString = Console.ReadLine();
        string convertString = "";
        for (int i = 0; i < startString.Length; i++)
        {
            if (char.IsUpper(startString.ElementAt<char>(i)))
            {
                var codeSymbol = Convert.ToInt16(startString.ElementAt<char>(i)) + 32;
                convertString += Convert.ToChar(codeSymbol);
            }
            else if (char.IsLower(startString.ElementAt<char>(i)))
            {
                var codeSymbol = Convert.ToInt16(startString.ElementAt<char>(i)) - 32;
                convertString += Convert.ToChar(codeSymbol);
            }
            else convertString += startString.ElementAt<char>(i);
        }
        Console.WriteLine(convertString);
    }
}
}
