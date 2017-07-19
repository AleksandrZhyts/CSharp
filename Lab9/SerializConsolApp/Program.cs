using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using ClassLib;

/*Задание 1. Программа «Передача объектов»
1.	Создать библиотеку классов с именем «ClassLib». 
2.	В библиотеке «ClassLib» создать класс с именем «РС», описывающий компьютер. Данный класс должен включать: 
•	3-4 поля (марка, серийный номер и  т.д.),  
•	свойства (к каждому полю), 
•	конструкторы (по умолчанию, с параметрами), 
•	методы, моделирующие функционирование ПЭВМ (включение/выключение, перегрузку). 
3.	Создать новый проект (тип – консольное приложение) с именем «SerializConsolApp».  Добавить ссылку на библиотеку «ClassLib».
4.	В функции Main() данного проекта создать коллекцию (на базе обобщенного класса List<T> ) 
    и добавить в коллекцию 4-5 объектов класса «РС».  
5.	Произвести сериализацию коллекции в бинарный файл  с именем «listSerial.txt»в каталоге на диске D.  
    В случае наличия аналогичного файла в каталоге старый файл перезаписать новым файлом и вывести об этом уведомление. 
6.	Создать новый проект (тип – консольное приложение) с именем «DeserializConsolApp».  Добавить ссылку на библиотеку «ClassLib».
7.	В функции Main() произвести десериализацию коллекции, созданной в проекте с именем «SerializConsolApp» и вывести на экран.
Дополнительно: 
8.	В проекте «SerializConsolApp» реализовать  функцию сохранения каждого объекта коллекции  в отдельном  каталоге с именами 
(«объект1.txt», «объект2. txt», «объект3. txt» …). 
    В проекте «DeserializConsolApp»  функцию чтения объектов из файлов и вывода на экран значений полей объектов.*/

namespace SerializConsolApp
{
class Program
{
    static void SerializedObject(Object obj, string filePath, string dirPath)
    {
        DirectoryInfo dir = new DirectoryInfo(dirPath);
        if (!dir.Exists)
        {
            dir.Create();
        }
        FileInfo fInfo = new FileInfo(dir + filePath);
        bool isWrite = true;
        if (fInfo.Exists)
        {
            Console.WriteLine("File exists, do you want to overwrite? y(es) / n(o)");
            string answ = Console.ReadLine();
            if (String.IsNullOrEmpty(answ) || answ.ToLower().StartsWith("n")) isWrite = false;
        }
        if (isWrite)
        {
            try
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                using (FileStream fs = fInfo.Open(FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fs, obj);
                    Console.WriteLine("BinarySerialize OK!\n");
                }
            }
            catch 
            {
               throw;
            }
        }
    }

    static void Main(string[] args)
    {
        PC pc1 = new PC("Home PC", "DELL123-454ItX", 4, 1000),
           pc2 = new PC("Office PC", "AMD354-454IX", 2, 500),
           pc3 = new PC("Server PC", "Intel25-454Itm", 16, 2000),
           pc4 = new PC("Home PC", "HP-454ItX", 8, 1000);

        List<PC> listPC = new List<PC>(4) { pc1, pc2, pc3, pc4};
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
            SerializedObject(listPC, filePath, dirPath);
            SerializedObject(pc1, filePath1, dirPath1);
            SerializedObject(pc2, filePath2, dirPath2);
            SerializedObject(pc3, filePath3, dirPath3);
            SerializedObject(pc4, filePath4, dirPath4);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }          
   }         
}
}
