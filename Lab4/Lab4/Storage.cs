using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
public abstract class Storage
{
    private string _model;
    private string _typeStorage;

    public Storage(string model, string type)
    {
        _model = model;
        _typeStorage = type;
    }

    public string TypeStorage
    {
        get
        {
            return _typeStorage;
        }
    }

    public string Model
    {
        get
        {
            return _model;
        }
    }   
         
    public virtual void print()
    {
         Console.Write($"{_typeStorage}, model: {_model} ");
    }

    public abstract double GetMemory();
    public abstract void CopyData(double totalSize, double sizeFile);
    public abstract double GetFreeDiskSpace();
    public abstract void ShowInformation();
}
}
