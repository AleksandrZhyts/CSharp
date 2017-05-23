using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
class WorkWithString
{
    public bool IsPalindrom(string str)
    {
        string[] strArray = str.ToLower().Split(" ,.-!?:;\'\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        string tempStr = "";
            
        foreach (string element in strArray)
        {
            tempStr +=element;
        }

        for (int i = 0; i < tempStr.Length / 2; i++)
        {
            if (tempStr[i] != tempStr[tempStr.Length - i - 1])
                return false;
        }
        return true; 
    }

    public int CountWords(string str)
    {
        string[] strArray = str.Split(" ,.-!?:;\'\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        int countWords = 0;
        foreach (string element in strArray)
        {
            countWords++;
        }
        return countWords;
    }
}
}
