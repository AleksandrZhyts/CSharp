using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
class TwoArray
{
    double[] singleArray;
    double[,] multyArray; 

    public double[] GetSingleArray()
    {
        return singleArray;
    }

    int _size;
    public int SizeArray
    {
        get { return _size; }
        set { _size = value <= 0 ? 1 : value; }
    }

    int _countLine;
    public int countLine
    {
        get { return _countLine; }
        set { _countLine = value <= 0 ? 1 : value; }
    }

    int _countRow;
    public int countRow
    {
        get { return _countRow; }
        set { _countRow = value <= 0 ? 1 : value; }
    }

    public void InitSingleArray()
    {
        var taskInput = new Lab1.InputDoubleData();
        singleArray = new double[_size];
        Console.WriteLine("Enter double elements of the array:");
        for (int i = 0; i < singleArray.Length; i++)
        {
            singleArray[i] = taskInput.InputData();
        }
    }

    public int leftBoderToRand { get; set; } = -200;
    public int rightBoderToRand { get; set; } = 200;
    public double fraction { get; set; } = 0.51;

    public void InitMultyArray()
    {
        Random rand = new Random();
        multyArray = new double[_countLine, _countRow];
        for (int i = 0; i < multyArray.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < multyArray.GetUpperBound(1) + 1; j++)
            {
                multyArray[i, j] = fraction * rand.Next(leftBoderToRand, rightBoderToRand);
            }
        }
    }

    public void Print(double[] arr)
    {
        foreach (double element in arr)
        {
            Console.Write($"{element:F2}  ");
        }
        Console.WriteLine();
    }

    public void Print()
    {
        foreach (double element in singleArray)
        {
            Console.Write($"{element:F2}  ");
        }
        Console.WriteLine();
    }

    public void PrintMultyArray()
    {
        for (int i = 0; i < multyArray.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < multyArray.GetUpperBound(1) + 1; j++)
            {
                Console.Write($"{multyArray[i, j]:F2}\t");
            }
            Console.WriteLine();
        }
    }
         
    public bool IsCommonMaxElement(out double max)
    {
        bool flag = false;
        max = 0;      
        foreach (double element in multyArray)
        {           
            if (singleArray.Contains<double>(element))
            {
                if (flag == false)
                {
                    max = element;
                    flag = true;
                }
                else
                {
                    if (element > max) max = element;
                }                   
            }  
        }
        return flag;
    }

    public bool IsCommonMinElement(out double min)
    {
        bool flag = false;
        min = 0;
        foreach (double element in multyArray)
        {
            if (singleArray.Contains<double>(element))
            {
                if (flag == false)
                {
                    min = element;
                    flag = true;
                }
                else
                {
                    if (element < min) min = element;
                }
            }
        }
        return flag;
    }

    public double SumElemSingleArray()
    {
        return singleArray.Sum();
    }

    public double SumElemMultyArray()
    {
        double[] tempArray;
        tempArray = multyArray.Cast<double>().ToArray();
        return tempArray.Sum();
    }

    public double MultElemSingleArray()
    {
        double result = 1;
        foreach (double element in singleArray)
        {
            result *= element;
        }
        return result;
    }

    public double MultElemMultyArray()
    {
        double[] tempArray;
        tempArray = multyArray.Cast<double>().ToArray();
        double result = 1;
        foreach (double element in tempArray)
        {
            result *= element;
        }
        return result;
    }

    public double SumEvenElemSingleArray()
    {
        double sum = 0;
        for (int i = 0; i < singleArray.Length; i++) 
        {
            if (i % 2 == 0)
            {
                sum += singleArray[i];
            }        
        }
        return sum;
    }

    public double SumOddRowMultyArray()
    {
        double sum = 0;
        for (int i = 0; i < multyArray.GetUpperBound(0) + 1; i++)
        {
            for (int j = 1; j < multyArray.GetUpperBound(1) + 1; j += 2) 
            {
                sum += multyArray[i,j];
            }
        }
        return sum;
    }

    public double[] CreateIntersecArray(double[] arr1, double[] arr2)
    {
        var across = arr1.Intersect(arr2);
        double[] temp = across.Cast<double>().ToArray();
        return temp;
    }

    public double SumBetweenMinMax()
    {
        double[] tempArray;
        tempArray = multyArray.Cast<double>().ToArray();
        int indexMinElement = Array.IndexOf(tempArray, tempArray.Min()),
            indexMaxElement = Array.LastIndexOf(tempArray, tempArray.Max());
        double sum = 0;
        if (indexMinElement > indexMaxElement)
        {
            indexMinElement ^= indexMaxElement;
            indexMaxElement ^= indexMinElement;
            indexMinElement ^= indexMaxElement;
        }
        for (int i = indexMinElement; i <= indexMaxElement; i++)
        {
            sum += tempArray[i];
        }
        return sum;
    }
}
}
