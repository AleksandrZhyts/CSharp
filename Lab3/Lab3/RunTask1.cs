using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
class RunTask1
{
    public void BodersOfArray()
    {
        var Array1 = new RangeOfArray(6, 10);
        var Array2 = new RangeOfArray(-9, 5);
        Array1.Init();   
        Array2.Init();
        try
        {
            Console.WriteLine($"Array1 range from {Array1.leftBoder} to {Array1.rightBoder}:\n");
            for (int i = Array1.leftBoder; i <= Array1.rightBoder; i++)
            {
                Console.WriteLine($"array[{i}] = {Array1[i]}");
            }

            Console.WriteLine($"\nArray2 range from {Array2.leftBoder} to {Array2.rightBoder}:\n");
            for (int i = Array2.leftBoder; i <= Array2.rightBoder + 1; i++)
            {
                Console.WriteLine($"array[{i}] = {Array2[i]}");
            }
        }
        catch(Exception ex)
        {
             Console.WriteLine(ex.Message);
        }
    }        
}
}
