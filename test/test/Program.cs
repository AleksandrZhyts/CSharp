using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using static System.Console;
namespace SimpleProject
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        // вызывается во время процесса сериализации
        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            Name = Name.ToUpper();
            DateBirth = DateBirth.ToUniversalTime();
        }
        // вызывается по завершении процесса десериализации
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Name = Name.ToLower();
            DateBirth = DateBirth.ToLocalTime();
        }
        public override string ToString()
        {
            return $"Name: {Name}, Date of Birth: { DateBirth}.";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person
            {
                Name = "Jack",
                DateBirth = new DateTime(1995, 11, 5)
            };
            SoapFormatter soapFormat = new SoapFormatter();
            try
            {
                using (Stream fStream =
                File.Create("test.soap"))
                {
                    soapFormat.Serialize(fStream, person);
                }
                WriteLine("SoapSerialize OK!\n");
                Person p = null;
                using (Stream fStream =
                File.OpenRead("test.soap"))
                {
                    p = (Person)soapFormat.
                    Deserialize(fStream);
                }
                WriteLine(p);
            }
            catch (Exception ex)
            {
                WriteLine(ex);
            }
        }
    }
}
