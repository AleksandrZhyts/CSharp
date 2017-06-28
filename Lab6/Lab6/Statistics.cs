using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Задание 2. Программа «Статистика»
Подсчитать, сколько раз каждое слово встречается  в  заданном  тексте.  
Результат  записать  в  коллекцию  Dictionary<TKey, TValue>. 
Текс использовать из приложения 1. Вывести статистику по тексту в виде таблицы (рисунок 1). 
Приложение 1.
    Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится В доме, 
Который построил Джек. А это веселая птица-синица, Которая часто ворует пшеницу, 
Которая в темном чулане хранится В доме, Который построил Джек.*/

namespace Lab6
{
class Statistics
{
    Dictionary<string, int> dictionary;
    int TotalWords;

    public Statistics()
    {
        dictionary = new Dictionary<string, int>();
        TotalWords = 0;
    }

    public void InitDictionary(string text)
    {
        string[] arrayWords = text.Split(",. \t\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        TotalWords = arrayWords.Length;
        foreach (string word in arrayWords)
        {
            if (dictionary.ContainsKey(word)) dictionary[word]++;
            else dictionary[word] = 1;
        }
    }

    public void ShowDictionary()
    {
        int i = 0;
        Console.WriteLine($"{"Слово:",29}{"Количество:",23}");
        foreach (KeyValuePair<string, int> pair in dictionary)
        {
            Console.WriteLine($"{++i,2}.{pair.Key,20}{pair.Value,20}");
        }
        Console.WriteLine($"Всего слов:{TotalWords} из них уникальных:{dictionary.Count}\n");
    }
}
}
