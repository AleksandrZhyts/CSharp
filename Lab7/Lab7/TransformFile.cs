using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab7
{
class TransformFile : IDisposable
{
    #region Fields

    private StreamReader _resource;
    private bool _disposed;

    #endregion

    public TransformFile(StreamReader stream)
    {
        if (stream == null)
            throw new ArgumentNullException("Поток null.");
        this._resource = stream;
        this._disposed = false;
    }

    public void ReadFromFileToTransform(out string textForOldFile, out string textForNewFile)
    {
        string line;
        textForOldFile = textForNewFile = "";
        while ((line = _resource.ReadLine()) != null)
        {
            string pattern = @"public*";
            Regex regex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.Compiled | RegexOptions.ExplicitCapture);
            MatchCollection matchCollection = regex.Matches(line);
            if (matchCollection.Count > 0) line = regex.Replace(line, "private");
            string[] arrayWords = line.Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            string temp = "";
            foreach (string word in arrayWords)
            {
                if (word.Length > 2)
                {
                    textForOldFile += word.ToLower() + " ";
                    temp += word.ToLower() + " ";
                }
                else
                {
                    textForOldFile += word + " ";
                    temp += word + " ";
                }
            }    
            char[] charArray = temp.ToCharArray();
            Array.Reverse(charArray);
            textForNewFile += new string(charArray) + "\n";
            textForOldFile += "\n";
        }
        _resource.Close();
   }

    public void WriteToFileAfterTransform(string filePath, string text)
    {
        using (StreamWriter file = new StreamWriter(filePath))
        {
            file.Write(text);
            file.Flush();
        }
    }

    #region IDisposable Members

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this); // чтобы не выполнять финализацию после явного освобождения ресурсов
    }

    #endregion

    ~TransformFile()   // Финализатор
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
            this._resource = null;
            this._disposed = true;
        }
    }
}
}
