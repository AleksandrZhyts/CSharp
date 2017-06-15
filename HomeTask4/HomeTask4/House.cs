using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
public class House
{
    IPart[] _part;
    int _countParts;

    public House(IPart[] part, int countParts)
    {
        _part = part;
        _countParts = countParts;
    }

    public int Length
    {
        get
        {
            return _countParts;
        }
    }

    public IPart this[int index]
    {
        get
        {
            return _part[index];
        }
        set
        {
            _part[index] = value;
        }
    }

    public void ShowHouse()
    {
        for (int i = 0; i < _countParts; i++)
        {
            Console.WriteLine(this[i].Show());
        }
    }
}
}
