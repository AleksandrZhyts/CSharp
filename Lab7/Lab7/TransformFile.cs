using System;
using System.IO;

namespace Lab7
{
class TransformFile
{
    public void ReadFromFileToTransform(string filePath, out string textForOldFile, out string textForNewFile)
    {
        using (StreamReader file = new StreamReader(filePath))
        {
            string line;
            textForOldFile = textForNewFile = "";
            while ((line = file.ReadLine()) != null)
            {
                string[] arrayWords = line.Split(" \t".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                string temp = "";
                foreach (string word in arrayWords)
                {
                    if (word.CompareTo("public") == 0)
                    {
                        textForOldFile += "private ";
                        temp  += "private ";
                    }
                    else
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
                }    
                char[] charArray = temp.ToCharArray();
                Array.Reverse(charArray);
                textForNewFile += new string(charArray) + "\n";
                textForOldFile += "\n";
            }
            file.Close();
        }
    }

    public void WriteToFileAfterTransform(string filePath, string text)
    {
        using (StreamWriter file = new StreamWriter(filePath))
        {
            file.Write(text);
            file.Flush();
            file.Close();
        }
    }
}
}
