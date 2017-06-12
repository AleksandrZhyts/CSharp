using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
class BackupCopy
{
    Storage[] storages;
    int _size;

    public BackupCopy(Storage[] st, int size) 
    {
        storages = st;
        _size = size;
    }

    public double TotalMemory(double sizeFile)
    {
        double totalMemory = .0;
        for (int i = 0; i < _size; i++)
        {
            totalMemory += sizeFile * Convert.ToInt32(storages[i].GetFreeDiskSpace() / sizeFile);
        }
        return totalMemory;
    }

    public void CalculationNumberStorageToCopy(double totalSize, double sizeFile, out int countDvd, out int countFlash, out int countHdd)
    {
        totalSize *= 1024;  //convert to Mb
        int numberStorage = Convert.ToInt32(totalSize / TotalMemory(sizeFile));
        countDvd = countFlash = countHdd = numberStorage;
        totalSize -= (numberStorage * TotalMemory(sizeFile));
        for (int i = 0; i < _size; i++)
        {
            numberStorage = Convert.ToInt32(totalSize / (sizeFile * Convert.ToInt32(storages[i].GetFreeDiskSpace() / sizeFile)));
            totalSize -= (numberStorage * storages[i].GetFreeDiskSpace());
            if (storages[i] is Hdd)
            {
                countHdd += numberStorage;
                if ((numberStorage == 0) && (totalSize > 0) && (storages[1].GetFreeDiskSpace() + storages[2].GetFreeDiskSpace() < totalSize))
                {
                    totalSize -= storages[i].GetFreeDiskSpace();
                    countHdd++;
                }
            }
            if (storages[i] is Flash)
            {
                countFlash += numberStorage;
                if ((numberStorage == 0) && (totalSize > 0) && (storages[2].GetFreeDiskSpace() > totalSize))
                {
                    countFlash++;
                    totalSize -= storages[i].GetFreeDiskSpace();
                }
            }
            if (storages[i] is Dvd)
            {
                countDvd += numberStorage;
                if ((numberStorage == 0) && (totalSize > 0)) countDvd++;
            }
        }
    }
    
    public int CalculationTimeToCopy(int countDvd, int countFlash, int countHdd)
    {
        int timeToCopy = 0;
        foreach (Storage item in storages)
        {
            if (item is Hdd)
            {
                timeToCopy += (2 * countHdd * (int)item.GetFreeDiskSpace() / ((Hdd)item).speedWriteUsb2);
            }
            if (item is Flash)
            {
                timeToCopy += (countFlash * (int)item.GetFreeDiskSpace() / ((Flash)item).GetSpeedWrite() +         //time to write
                               countFlash * (int)item.GetFreeDiskSpace() / (((Flash)item).GetSpeedWrite() * 2));   //time to read (quickly)
            }
            if (item is Dvd)
            {
                timeToCopy += (countDvd * (int)item.GetFreeDiskSpace() / (((Dvd)item)._speedW * 1385) +    //time to write
                                countDvd * (int)item.GetFreeDiskSpace() / (((Dvd)item)._speedR * 1385));   //time to read 
            }
        }
        return timeToCopy;
    }

    public void ShowInfToCopy(double totalSize, double sizeFile, out int countDvd, out int countFlash, out int countHdd)
    {
        Console.WriteLine($"For copy {totalSize} Gb information, files in size {sizeFile} Mb, you need:\n");
        CalculationNumberStorageToCopy(totalSize, sizeFile, out countDvd, out countFlash, out countHdd);
        for (int i = 0; i < _size; i++)
        {
            storages[i].ShowInformation();
            if (storages[i] is Hdd) Console.WriteLine($" - {countHdd} items");
            if (storages[i] is Flash) Console.WriteLine($" - {countFlash} items");
            if (storages[i] is Dvd) Console.WriteLine($" - {countDvd} items");
        }
        int timeCopy = CalculationTimeToCopy(countDvd, countFlash, countHdd),
            hours = timeCopy / 3600,
            minutes = (timeCopy - hours * 3600) / 60,
            seconds = timeCopy - hours * 3600 - minutes * 60;
        Console.WriteLine($"\nTime to copy: {hours}h {minutes}m {seconds}s\n");
    }

    public void CopyData(double totalSize, double sizeFile)
    {
        int countDvd,
            countFlash,
            countHdd;
        ShowInfToCopy(totalSize, sizeFile, out countDvd, out countFlash, out countHdd);
        Console.WriteLine("Start copy...");       
        for (int  i = 0, numberCopy = 0; i < _size; i++)
        {
            if (storages[i] is Hdd) numberCopy = countHdd;
            if (storages[i] is Flash) numberCopy = countFlash;
            if (storages[i] is Dvd) numberCopy = countDvd;
            for (int j = 0; j < numberCopy; j++)
            {
                storages[i].CopyData(totalSize, sizeFile);
            }            
        }
        Console.WriteLine("End copy!");
    }
}
}
