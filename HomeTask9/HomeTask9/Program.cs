using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Loggin;

namespace HomeTask9
{
    class Program
    {
        interface IHuman
        {
            string getFName { get; }
            string getSName { get; }
        }

        public class TextTransformAttribute : Attribute
        {
            public bool isUpperCase;
        }

        class SimpleHuman : IHuman
        {
            string FName, SName;

            public SimpleHuman(string FNm, string SNm)
            {
                FName = FNm;
                SName = SNm;
            }
            public string getFName
            {
                get { return FName; }
            }
            public string getSName
            {
                get { return SName; }
            }
        }

        [TextTransform(isUpperCase = true)]
        class Student : IHuman
        {
            string FName, SName;

            public Student(string FNm, string SNm)
            {
                FName = FNm;
                SName = SNm;
            }
            public string getFName
            {
                get { return FName; }
            }
            public string getSName
            {
                get { return SName; }
            }
        }

        class HumanPrinter
        {
            public void Show(IHuman H)
            {
                string firstName = H.getFName;
                string surrName = H.getSName;

                Type T = H.GetType();
                TextTransformAttribute[] TTA = (TextTransformAttribute[])T.GetCustomAttributes(typeof(TextTransformAttribute), false);
                if (TTA.Length != 0)
                {
                    firstName = (TTA[0].isUpperCase) ? firstName.ToUpper() : firstName.ToLower();
                    surrName = (TTA[0].isUpperCase) ? surrName.ToUpper() : surrName.ToLower();
                }
                Console.WriteLine("---------------------");
                Console.WriteLine("Фамилия : {0}", surrName);
                Console.WriteLine("Имя : {0}", firstName);
            }
        }


        [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
        public class CoderAttribute : Attribute
        {
            string _name = "Yuriy";
            DateTime _date = DateTime.Now;
            public CoderAttribute() { }
            public CoderAttribute(string name, string date)
            {
                try
                {
                    _name = name;
                    _date = Convert.ToDateTime(date);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            public override string ToString()
            {
                return $"Coder: { _name}, Date: { _date}";
            }
        }

        [Coder]
        class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Salary { get; set; }

            [Coder("John", "2017-3-29")]
            public void IncreaseWages(double wage)
            {
                Salary += wage;
            }
        }

        public class RoleInfoAttribute : System.Attribute
        {
            public string Name { get; set; }
            public int Code { get; set; }

            public RoleInfoAttribute()
            { }

            public RoleInfoAttribute(string name, int code)
            {
                Name = name;
                Code = code;
            }
        }

        [RoleInfo(Name = "customer", Code = 220)]
        public class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public User(string n, int a)
            {
                Name = n;
                Age = a;
            }
            private int Payment(int hours, int perhour)
            {
                return hours * perhour;
            }
        }

        static void Main(string[] args)
        {
            //SimpleHuman Petr = new SimpleHuman("Пётр", "Иванов");
            //Student Ivan = new Student("Иван", "Немиров");
            //HumanPrinter HP = new HumanPrinter();
            //HP.Show(Petr);
            //HP.Show(Ivan);

            //Console.WriteLine("\tAttributes of class Employee:");
            //foreach (var attr in typeof(Employee).GetCustomAttributes())
            //{
            //    Console.WriteLine(attr);
            //}
            //Console.WriteLine("\n\tAttributes of members of class Employee :");
            //foreach (MemberInfo info in typeof(Employee).GetMembers())
            //{
            //    foreach (var attr in info.GetCustomAttributes(true))
            //    {
            //        Console.WriteLine(attr);
            //    }
            //}

            //Type t = typeof(User);
            //object[] attrs = t.GetCustomAttributes(false);
            //foreach (RoleInfoAttribute roleAttr in attrs)
            //{
            //    Console.WriteLine(roleAttr.Name);
            //    Console.WriteLine(roleAttr.Code);
            //}

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


