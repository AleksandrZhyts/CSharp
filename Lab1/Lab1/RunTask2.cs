using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
class RunTask2
{
    public void RunCalculate()
    {
        var taskRun = new Triangle();
        taskRun.InitTriangle();

        double side1 = taskRun.GetSideA();
        double side2 = taskRun.GetSideB();
        double side3 = taskRun.GetSideC();

        if (taskRun.IsTriangle(side1, side2, side3))
        {
            double perimetr = taskRun.Perimetr(side1, side2, side3);
            Console.WriteLine(string.Format("\nP = {0:F2}", perimetr));
            Console.WriteLine(string.Format("S = {0:F2}", taskRun.Area(side1, side2, side3)));
        }
        else
        {
            Console.WriteLine("\nThere is no triangle with such sides");
        }
    }
}
}
