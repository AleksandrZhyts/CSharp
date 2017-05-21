using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask1
{
class InverseNumber
{
    public int Inverse(int number)
    {
        int result = 0;
        while (number != 0)
        {
            result = result*10 + number % 10;
            number /= 10;
        }
        return result;
    }
}
}
