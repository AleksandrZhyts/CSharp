using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
class Program
{
    static void Main(string[] args)
    {
        Note note1 = new Note("Сидоров", "Александр", new DateTime(1993, 8, 14), "sidorov@mail.ru", "252-44-68");   
        Note note2 = new Note("Петров", "Сергей", new DateTime(1985, 1, 25), "petrov@bk.ru", "222-25-34");
        Note note3 = new Note("Иванов", "Иван", new DateTime(2001, 10, 15), "ivanov@mail.ru", "242-25-68");

        Notebook book = new Notebook();

        book.AddNote(note1);
        book.AddNote(note2);
        book.AddNote(note3);

        for (int i = 0; i < book.Size; i++)
        {
            book.ShowNode(i);
        }

        book.Sort();

        for (int i = 0; i < book.Size; i++)
        {
            book.ShowNode(i);
        }

        book.ResultSearch();
        Console.ReadKey();
        Console.Clear();

        Note note4 = book[2];
        book.DeleteNote(2);

        for (int i = 0; i < book.Size; i++)
        {
            book.ShowNode(i);
        }

        Console.ReadKey();
        Console.Clear();
        book[2] = note4;

        for (int i = 0; i < book.Size; i++)
        {
            book.ShowNode(i);
        }
    }
}
}
