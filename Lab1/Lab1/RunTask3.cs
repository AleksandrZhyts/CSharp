using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class RunTask3
{
    public void RunWriteNumber()
    {
        int hundreds,
            dozens,
            units;

        var taskInput = new InputSpecialNum();
        int num = taskInput.InputData();

        hundreds = num / 100;
        dozens = num / 10 % 10;
        units = num % 10;

        var taskWriteH = new OutputHudreds();
        taskWriteH.StartWrite(hundreds);

        var taskWriteD = new OutputDozens();
        taskWriteD.StartWrite(dozens, units);

        if (dozens != 1)
        {
            var taskWriteU = new OutputUnits();
            taskWriteU.StartWrite(units);
        }
        Console.WriteLine("");
    }
}
}
