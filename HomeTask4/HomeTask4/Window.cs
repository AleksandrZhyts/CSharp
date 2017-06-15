using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
class Window : IPart
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
        Console.WriteLine("\t4 windows installed!");
        isBuild = true;
    }

    public string Show()
    {
        return "\tfirst window; second window; third window; forth window";
    }
}
}
