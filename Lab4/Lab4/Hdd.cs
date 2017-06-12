using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
class Hdd : Storage
{
    int _numberPartitions;
    double _volumePartitions;
    double _capacity;   //Gb
    double _freeSpace;  //Mb
    public int speedWriteUsb2 { get; set; }

    public Hdd(string model, string type, int numberPartitions, double volumePartitions, int speedW) : base(type, model)
    {
        _numberPartitions = numberPartitions;
        _volumePartitions = volumePartitions;
        _capacity = _numberPartitions * _volumePartitions;
        _freeSpace = _capacity * 1024;
        speedWriteUsb2 = speedW;
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
        Console.Write($"speed: {speedWriteUsb2} Mb/s, {_numberPartitions} x {_volumePartitions} Gb");
    }
}
}
