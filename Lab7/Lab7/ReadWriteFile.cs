using System;
using System.IO;

namespace Lab7
{
class ReadWriteFile : IDisposable
{
    #region Fields

    private Stream _resource;
    private bool _disposed;
    public string FIO { get; set; } = "Иванов Иван Иванович";
    public DateTime BirthDay { get; set; } = new DateTime(1995, 10, 15);

    #endregion

    public ReadWriteFile(Stream stream)
    {
        if (stream == null)
            throw new ArgumentNullException("Поток null.");
        if (!stream.CanRead && !stream.CanWrite)
            throw new ArgumentException("Поток должен быть доступен для данной операции.");
        this._resource = stream;
        this._disposed = false;
    }

    public void WriteToFile()
    {
        if (_disposed)
            throw new ObjectDisposedException("Ресурс был освобожден.");
        using (StreamWriter sw = new StreamWriter(_resource))
        {
            sw.WriteLine(FIO + " " + BirthDay.ToShortDateString());
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int col = rand.Next(1, 10),
                row = rand.Next(1, 10);
            sw.WriteLine(col.ToString() + " " + row.ToString());

            for (int i = 0; i < col * row; i++)
            {
                sw.WriteLine(rand.Next(0, 200) * 0.35);
            }
            col = rand.Next(1, 10);
            row = rand.Next(1, 10);
            sw.WriteLine(col.ToString() + " " + row.ToString());
            string elemArrayInt = "";
            for (int i = 0; i < col * row; i++)
            {
                elemArrayInt += (rand.Next(0, 200).ToString() + " ");
            }
            sw.WriteLine(elemArrayInt);
            sw.WriteLine(DateTime.Now.ToShortDateString());
            sw.Flush();
        }
    }

    public void ReadFromFile()
    {
        if (_disposed)
            throw new ObjectDisposedException("Ресурс был освобожден.");
        _resource.Seek(0, SeekOrigin.Begin);
        using (StreamReader sr = new StreamReader(_resource))
        {
            string[] arrayWords = sr.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"FIO: {arrayWords[0] + " " + arrayWords[1] + " " + arrayWords[2]}" + $"\nBirthDay: {arrayWords[3]}");
            arrayWords = sr.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int col = Convert.ToInt32(arrayWords[0]),
                row = Convert.ToInt32(arrayWords[1]);
            Console.WriteLine($"Column double array: {col}" + $"\nRow double array: {row}" + "\nDouble elements:");
            for (int i = 0; i < col * row; i++)
            {
                Console.WriteLine(Convert.ToDouble(sr.ReadLine()));
            }
            arrayWords = sr.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Column integer array: {arrayWords[0]}" +
                                $"\nRow integer array: {arrayWords[1]}" +
                                "\nInteger elements:\n" +
                                sr.ReadLine() +
                                $"\nCurrent date: {sr.ReadLine()}");
        }
    }

    #region IDisposable Members

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this); // чтобы не выполнять финализацию после явного освобождения ресурсов
    }

    #endregion
    
    ~ReadWriteFile()   // Финализатор
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
                    _resource.Dispose();
                Console.WriteLine("Ресурс освобожден.");
            }
            // Индикация, что ресурс уже был освобожден
            this._resource = null;
            this._disposed = true;
        }
    }
}
}
