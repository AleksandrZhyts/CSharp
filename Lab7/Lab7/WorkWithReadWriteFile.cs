using System;
using System.IO;

namespace Lab7
{
class WorkWithReadWriteFile
{
    public void StartWork()
    {
        while (true)
        {
            Console.WriteLine("\t1 - Записать файл\n\t2 - Прочитать файл\n\tq - Выход");
            int choise;
            var answer = Console.ReadLine();
            if (!int.TryParse(answer, out choise))            
                break;          
            switch (choise)
            {
                case 1:
                    try
                    {
                        try
                        {
                            string filePath = @"d:\Day17.txt";  //Console.ReadLine();
                            FileStream fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write, FileShare.Write);
                            using (ReadWriteFile runTask = new ReadWriteFile(fs, false))
                            {
                                runTask.WriteToFile();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Файл уже существует!");
                        }
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;

                case 2:
                    try
                    {
                        try
                        {
                            string filePath = @"d:\Day17.txt";  //Console.ReadLine();
                            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                            using (ReadWriteFile runTask = new ReadWriteFile(fs, true))
                            {
                                runTask.ReadFromFile();
                                
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Файл не был записан!");
                        }
                    }
                    catch (FileNotFoundException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                    default:
                        return;
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
}
