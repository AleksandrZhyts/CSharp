using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4 
{
class Dvd : Storage
{
    double _capacity;   //Gb
    double _freeSpace;  //Mb
    public int _speedW { get; set; }
    public int _speedR { get; set; }

    public Dvd(string model, string type, int speedW, int speedR) : base(type, model)
    {
        _speedW = speedW;
        _speedR = speedR;
        _capacity = (string.Compare("one side", type) == 0) ? 4.7 : 9;
        _freeSpace = _capacity * 1024;
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
        Console.Write($"speed read/write: {_speedR}x /{_speedW}x, {_capacity} Gb");
    }
}
}
