using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
class Program
{
    static void Main(string[] args)
    {
        var task = new RunBankomat();
        task.OpenSession();
    }
}
}
