using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask1
{
class RunTask2
{
    public void RunChek()
    {
        var taskRun = new IsTicketHappy();
        if (taskRun.Check() == true)
        {
            Console.WriteLine("\nThe ticket is happy!");
        }
        else
        {
            Console.WriteLine("The ticket isn't happy!");
        }
     }
}
}
