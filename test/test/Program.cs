using System;
using System.Text.RegularExpressions;

namespace RegexConsoleExample
{
    class Program
    {


        static void Main(string[] args)
        {
            
            
            
            
            
            //while (true)
            //{
            //    Console.WriteLine("Введите анализируемый текст:");
            //    string inputText = Console.ReadLine();
            //    //Console.WriteLine("Введите регулярное выражение для поиска:");
            //    string pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";//Console.ReadLine();
            //    //Создаем объект регулярного выражения
            //    Regex regex = new Regex(pattern, RegexOptions.Multiline | RegexOptions.Compiled | RegexOptions.ExplicitCapture);
            //    //Получаем коллекцию совпадений
            //    MatchCollection matchCollection = regex.Matches(inputText);
            //    //Формируем сообщение о найденных совпадениях
            //    Console.WriteLine("Найдено совпадений: {0}", matchCollection.Count);
            //    //Выводим информацию о каждом найденном совпадении
            //    for (int i = 0; i < matchCollection.Count; i++)
            //    {
            //        Console.WriteLine("{0}:\t{1}", i + 1, matchCollection[i].Value);
            //    }
            //    //Произведем замену всех найденных совпадений
            //    Console.WriteLine("Вы хотите заменить найденные совпадения новым текстом? y(es) / n(o)");
            //    string answ = Console.ReadLine();
            //    if (!String.IsNullOrEmpty(answ) && answ.ToLower().StartsWith("y"))
            //    {
            //        //Заменяем все найденные совпадения в тексте
            //        Console.WriteLine("Введите текст для замены:");
            //        string replacementText = Console.ReadLine();
            //        Console.WriteLine("Результат обработки:");
            //        Console.WriteLine(regex.Replace(inputText, replacementText));
            //    }
            //    Console.WriteLine("Продолжить? y(es) / n(o)");
            //    answ = Console.ReadLine();
            //    if (String.IsNullOrEmpty(answ) || answ.ToLower().StartsWith("n"))
            //        break;
            //}
        }
    }
}
