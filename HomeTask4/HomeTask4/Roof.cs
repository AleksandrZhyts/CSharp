using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
class Roof : IPart
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
        Console.WriteLine("\tRoof built!");
        isBuild = true;
    }

    public string Show()
    {
        return "\tRoof";
    }
}
}
