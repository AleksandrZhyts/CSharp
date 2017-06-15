using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
class TeamLeader : IWorker
{

    public string _name { get; set; }

    public TeamLeader(string name)
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
        Console.WriteLine($"\n{_name} report is start.");
        Console.WriteLine($"Built:");
        while (--i >= 0 && house[i].IsBuild == true)
        {
            Console.WriteLine($"{house[i].Show()}");
        }
        if (i < 0)
        {
            isWorkFinish = true;
            Console.WriteLine("The house is fully built");
        }
        if (i == house.Length - 1) Console.WriteLine("\tThe construction has just started");
        Console.WriteLine("The report is over.\n");
    }
}
}
