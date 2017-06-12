using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
class Program
{
    static void Main(string[] args)
    {
        var storages = new Storage[3] { new Hdd("Seagate HDD", "STDR1000200 - 500", 3, 165, 95),
                                        new Flash("Corsair Flash Survivor", "CMFSV3-32GB", "USB 3.0", 32),
                                        new Dvd("DVD RW", "double side", 8, 16)
                                       };
        var runCopy = new BackupCopy(storages, 3);
        runCopy.CopyData(565, 780);
    }
}
}
