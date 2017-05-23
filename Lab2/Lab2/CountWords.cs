using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
class CountWords
{
    public int RunCount(string str)
    {
        string[] strArray = str.Split(" ,.-!?:;\'\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        int countWords = 0;
        foreach(string element in strArray)
        {
            countWords++;
        }
        return countWords;
    }
}
}
