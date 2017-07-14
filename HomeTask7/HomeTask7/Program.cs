using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loggin;

namespace HomeTask7
{
class Program
{
    static void Main(string[] args)
    {
        try
        {
            string LogFileName = "MyLogFile.log";
            string IniFileName = "Log.ini";
            FileStream fs = new FileStream(LogFileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            using (Loger writeTo = new Loger(fs, IniFileName))
            {  
                writeTo.Logs("error", "handle out of range");
                writeTo.Logs("exception", "division by 0");
                writeTo.Logs("text message", "check reestr");
                writeTo.Logs("information", "result must be positive");
                writeTo.Logs("warning", "run as administrator");
            }
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
}
