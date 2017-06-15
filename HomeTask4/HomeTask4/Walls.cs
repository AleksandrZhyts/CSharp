using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
class Walls : IPart
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
        Console.WriteLine("\t4 walls built!");
        isBuild = true;
    }

    public string Show()
    {
        return "\tfirst wall; second wall; third wall; forth wall";
    }
}
}
