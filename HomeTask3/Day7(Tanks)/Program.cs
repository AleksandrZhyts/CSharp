using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLib;

namespace Day7_Tanks_
{
class Program
{
    static void Main(string[] args)
    {
        var runTask = new TanksBattles(5);
        runTask.TankOffensive("T-34 ", "Pantera ");
    }
}
}
