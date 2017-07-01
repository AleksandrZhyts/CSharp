using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
class Program
{
    static void Main(string[] args)
    {
        var runTask1 = new DemoWorkWithNotebook();
        runTask1.StartWork();

        var runTask2 = new Statistics();
        runTask2.InitDictionary("   Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане\n" +
                                "хранится В доме, Который построил Джек. А это веселая птица-синица, Которая\n" +
                                "часто ворует пшеницу, Которая в темном чулане хранится В доме, Который\n" +
                                "построил Джек.");
        runTask2.ShowDictionary();
    }
}
}
