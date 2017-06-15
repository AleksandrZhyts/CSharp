using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
class Program
{
    static void Main(string[] args)
    {
        var parts = new IPart[5]
        {
            new Roof(),            
            new Window(),
            new Door(),
            new Walls(),
            new Basement()
        };
        var build = new House(parts, 5);

        var workers = new IWorker[3]
        {
            new Worker("Alex"),
            new Worker("Sergey"),
            new TeamLeader("Jon")
        };
        var construction = new Team(workers, 3);

        while (construction.IsWorkFinish(build) != true)
        {
            construction.HouseBuilding(build);
        }

        Console.WriteLine("\nOur house consists:");
        build.ShowHouse();
    }
}
}
