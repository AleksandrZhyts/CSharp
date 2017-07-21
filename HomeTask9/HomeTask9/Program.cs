using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Loggin;

/*Задание 1. Программа «Атрибут [ParamsAttribute]»
Создать атрибут, который должен быть применен только  к свойствам класса. 
Данный атрибут должен предписывать свойству класса брать значение из указанного ini-файла. 
Имя ini-файла, из которого требуется брать значение для свойства, указывается  через параметр атрибута. 
Требование. Для работы программы создать 3-4 ini-файла, в которых должны храниться значения для свойств.
 
Задание 2. Программа «Пользовательский атрибут»
Придумать пользовательский атрибут (самостоятельно). Данный атрибут должен выполнять прикладную задачу (а не демонстрационную). 
Проверить его функциональность.*/

namespace HomeTask9
{
class Program
{
    interface IHuman
    {
        string FName { get; set; }
        string SName { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]  
    public class IniFileFNameAttribute : Attribute
    {
        public string IniFile;
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class IniFileSNameAttribute : Attribute
    {
        public string IniFile;
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class IniFileGroupAttribute : Attribute
    {
        public string IniFile;
    }

    [IniFileFName(IniFile = "ValuesForFName.ini")]
    [IniFileSName(IniFile = "ValuesForSName.ini")]
    [IniFileGroup(IniFile = "ValuesForGroupNumber.ini")]
    class Student : IHuman
    {
        public string FName { get; set; }
        public string SName { get; set; }
        public int Group { get; set; }

        public Student()
        {
            FName = SName = "undefined";
            Group = 0;
        }

        public Student(string FNm, string SNm, int Grp)
        {
            FName = FNm;
            SName = SNm;
            Group = Grp;
        }

        public override string ToString()
        {
            return $"Student: {SName} {FName}\nGroup: {Group}";
        }
    }

    public static string ReadValueFromFile(string fileName)
    {
        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                byte[] readBytes = new byte[(int)fs.Length];
                fs.Read(readBytes, 0, readBytes.Length);
                string text = Encoding.Default.GetString(readBytes);
                return text;
            }
        }
        catch
        {
            throw new Exception(fileName + " not found.");
        }
    }

    class HumanPrinter
    {
        public void Show(IHuman H)
        {
            Type T = H.GetType();
            IniFileFNameAttribute FN = (IniFileFNameAttribute)T.GetCustomAttribute(typeof(IniFileFNameAttribute), false);
            IniFileSNameAttribute SN = (IniFileSNameAttribute)T.GetCustomAttribute(typeof(IniFileSNameAttribute), false);
            IniFileGroupAttribute Gr = (IniFileGroupAttribute)T.GetCustomAttribute(typeof(IniFileGroupAttribute), false);
            try
            {
                FileStream fs = new FileStream("LogFile.log", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                using (Loger writeTo = new Loger(fs, "Log.ini"))
                {
                    try
                    {                       
                        H.FName = ReadValueFromFile(FN.IniFile); 
                        H.SName = ReadValueFromFile(SN.IniFile); 
                        if (H is Student)
                            (H as Student).Group = Convert.ToInt32(ReadValueFromFile(Gr.IniFile)); 
                    }
                    catch (Exception ex)
                    {
                        writeTo.Logs("error", ex.Message);
                    }
                }
                Console.WriteLine(H);
            }
            catch 
            {
                throw;
            }
        }
    }

    static void Main(string[] args)
    {
        Student ItStudent1 = new Student();
        HumanPrinter h = new HumanPrinter();
        try
        {
            h.Show(ItStudent1);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }   
    }
}
}


