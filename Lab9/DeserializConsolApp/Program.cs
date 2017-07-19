using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLib;

namespace DeserializConsolApp
{
class Program
{
    static void DeSerializedListPC( string filePath, string dirPath)
    {
        DirectoryInfo dir = new DirectoryInfo(dirPath);
        FileInfo fInfo = new FileInfo(dir + filePath);
        try
        {
            if (!dir.Exists || !fInfo.Exists)
            {
                throw new Exception("Error! Directory or file not exists");
            }
       
            BinaryFormatter binFormat = new BinaryFormatter();
            List<PC> p = null;

            using (Stream fStream = File.OpenRead(dir + filePath))
            {
                p = (List<PC>)binFormat.Deserialize(fStream);
            }
            foreach (PC pc in p)
            {
                Console.WriteLine(pc);
            }
        }
        catch
        {
            throw;
        }
    }

    static void DeSerializedPC(string filePath, string dirPath)
    {
        DirectoryInfo dir = new DirectoryInfo(dirPath);
        FileInfo fInfo = new FileInfo(dir + filePath);
        try
        {
            if (!dir.Exists || !fInfo.Exists)
            {
                throw new Exception("Error! Directory or file not exists");
            }
        
            BinaryFormatter binFormat = new BinaryFormatter();
            PC p = null;

            using (Stream fStream = File.OpenRead(dir + filePath))
            {
                p = (PC)binFormat.Deserialize(fStream);
                Console.WriteLine(p);
            }
        }
        catch
        {
            throw;
        }
    }

    static void Main(string[] args)
    {
        string filePath = @"\listSerial.txt",
                dirPath = @"D:\example",
                filePath1 = @"\object1.txt",
                dirPath1 = @"D:\example1",
                filePath2 = @"\object2.txt",
                dirPath2 = @"D:\example2",
                filePath3 = @"\object3.txt",
                dirPath3 = @"D:\example3",
                filePath4 = @"\object4.txt",
                dirPath4 = @"D:\example4";
        try
        {
            DeSerializedListPC(filePath, dirPath);
            DeSerializedPC(filePath1, dirPath1);
            DeSerializedPC(filePath2, dirPath2);
            DeSerializedPC(filePath3, dirPath3);
            DeSerializedPC(filePath4, dirPath4);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
}
