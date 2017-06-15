using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
class Worker : IWorker
{
    public string _name { get; set; }

    public Worker(string name)
    {
        _name = name;
    }

    bool isWorkFinish = false;

    public bool IsWorkFinish
    {
        get
        {
            return isWorkFinish;
        }
    }

    public void Work(House house)
    {
        int i = house.Length;
        while (--i >= 0 && house[i].IsBuild == true) ;
        if (i < 0) isWorkFinish = true;
        else
        {
            Console.WriteLine($"Working {_name}");
            house[i].BuildPart();
        }
    }
}
}
