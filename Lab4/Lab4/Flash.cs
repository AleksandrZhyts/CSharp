using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
class Flash : Storage
{
    string _speed;
    double _capacity;  //Gb
    double _freeSpace; //Mb
    public int speedWriteUsb3 { get; set; } = 100;
    public int speedWriteUsb2 { get; set; } = 50;

    public Flash(string model, string type, string speed, double capacity) : base(type, model)
    {
        _speed = speed;
        _capacity = capacity;
        _freeSpace = _capacity * 1024;
    }

    public int GetSpeedWrite()
    {
        return (string.Compare(_speed, "USB 3.0") == 0) ? speedWriteUsb3 : speedWriteUsb2;
    }

    public override void CopyData(double totalSize, double sizeFile)
    {
        int countFilesTo = Convert.ToInt32(_freeSpace / sizeFile),
            countFilesFrom = Convert.ToInt32(_freeSpace / sizeFile);
        _freeSpace -= (countFilesFrom >= countFilesTo) ? countFilesTo * sizeFile : countFilesFrom * sizeFile;
        Console.WriteLine($"Copy data use {Model}");
    }

    public override double GetFreeDiskSpace()
    {
        return _freeSpace;
    }

    public override double GetMemory()
    {
        return _capacity;
    }

    public override void ShowInformation()
    {
        base.print();
        Console.Write($"speed: {_speed}, {_capacity} Gb");
    }
}
}
