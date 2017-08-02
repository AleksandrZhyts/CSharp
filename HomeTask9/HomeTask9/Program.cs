using System;
using System.IO;
using System.Reflection;
using System.Text;
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

    [AttributeUsage(AttributeTargets.Property)]
    public class IniFileAttribute : Attribute
    {
        public string FileName;       
    }
 
    class Student : IHuman
    {
        [IniFile(FileName = "ValuesForFName.ini")]
        public string FName { get; set; }

        [IniFile(FileName = "ValuesForSName.ini")]
        public string SName { get; set; }

        [IniFile(FileName = "ValuesForGroupNumber.ini")]
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
            IniFileAttribute FN = (IniFileAttribute)((Attribute[])typeof(Student).GetProperties()[0].GetCustomAttributes())[0];
            IniFileAttribute SN = (IniFileAttribute)((Attribute[])typeof(Student).GetProperties()[1].GetCustomAttributes())[0];
            IniFileAttribute Gr = (IniFileAttribute)((Attribute[])typeof(Student).GetProperties()[2].GetCustomAttributes())[0];
            try
            {
            FileStream fs = new FileStream("LogFile.log", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            using (Loger writeTo = new Loger(fs, "Log.ini"))
            {
                try
                {                       
                    H.FName = ReadValueFromFile(FN.FileName); 
                    H.SName = ReadValueFromFile(SN.FileName);
                    if (H is Student)
                        (H as Student).Group = Convert.ToInt32(ReadValueFromFile(Gr.FileName)); 
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


