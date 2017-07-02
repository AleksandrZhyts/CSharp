using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
