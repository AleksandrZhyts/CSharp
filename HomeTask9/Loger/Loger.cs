using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggin
{



public class Loger : IDisposable
{
    #region Fields

    private Stream _resource;
    private bool _disposed;
    private List<string> configLogs = new List<string>(4){ "[date]", "[type]", "[usersname]", "[text]" }; //Default value
    private StreamWriter sw;

    #endregion

    public Loger(Stream stream, string IniFileName)
    {
        if (stream == null)
            throw new ArgumentNullException("Поток null.");
        if (!stream.CanWrite)
            throw new ArgumentException("Поток должен быть доступен для записи.");
        ReadConfigLogs(IniFileName);
        sw = new StreamWriter(stream);
        this._resource = stream;
        this._disposed = false;
    }

    private void ReadConfigLogs(string IniFileName)
    {
        using (StreamReader file = new StreamReader(IniFileName))
        {
            string line;
            configLogs.Clear();
            while ((line = file.ReadLine()) != null)
            {
                string[] arrayWords = line.Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (arrayWords[1].CompareTo("1") == 0) configLogs.Add(arrayWords[0]);
            }
            file.Close();
        }
    }

    public void Logs(string typeMsg, string Msg)
    {
        if (_disposed)
            throw new ObjectDisposedException("Ресурс был освобожден.");
        foreach (string section in configLogs)
        {
            if (section.CompareTo("[date]") == 0)
                sw.Write(DateTime.Now.ToLocalTime().ToString() + " ");
            if (section.CompareTo("[type]") == 0)
                sw.Write("[" + typeMsg + "] ");
            if (section.CompareTo("[usersname]") == 0)
                sw.Write(System.Security.Principal.WindowsIdentity.GetCurrent().Name + " ");
            if (section.CompareTo("[text]") == 0)
                sw.Write(" " + Msg);
        }
        sw.WriteLine();
        sw.Flush();
    }

    #region IDisposable Members

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this); // чтобы не выполнять финализацию после явного освобождения ресурсов
    }

    #endregion

    ~Loger()   
    {
        this.Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                if (_resource != null)
                {
                    sw.Dispose();
                    _resource.Dispose();
                }
                Console.WriteLine("Ресурс освобожден.");
            }
            sw = null;
            this._resource = null;
            this._disposed = true;
        }
    }
}
}
