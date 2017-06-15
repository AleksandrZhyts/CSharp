using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
class Basement : IPart
{
    bool isBuild = false;

    public bool IsBuild
    {
        get
        {
            return isBuild;
        }
    }

    public void BuildPart()
    {
        Console.WriteLine("\tBasement built!");
        isBuild = true;
    }

    public string Show()
    {
        return "\tBasement";
    }
}
}
