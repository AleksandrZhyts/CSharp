using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
class RangeOfArray
{
    int[] _array;
    public int leftBoder { get; private set; }
    public int rightBoder { get; private set; }

    public RangeOfArray(int left, int right)
    {
        if (left > right)
        {
            left ^= right;
            right ^= left;
            left ^= right;
        }
        leftBoder = left;
        rightBoder = right;
        _array = new int[rightBoder - leftBoder + 1];
    }

    public int Length
    {
        get { return _array.Length; }
    }

    public void Init()
    {
        Random rand = new Random();
        for (int i = 0; i < Length; i++)
        {
             _array[i] = rand.Next() / 1000000; 
        }
    }

    public int this[int index]
    {
        get
        {
            if (index >= leftBoder && index <= rightBoder)
            {
                return _array[index - leftBoder];
            }           
            throw new IndexOutOfRangeException();
        }
        set
        {
            if (index >= leftBoder && index <= rightBoder)
            {
                _array[index - leftBoder] = value;
            }
            else throw new IndexOutOfRangeException();
        }
    }
}
}
