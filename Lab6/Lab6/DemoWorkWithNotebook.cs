using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
class DemoWorkWithNotebook
{
    public void StartWork()
    {
        Note note1 = new Note("Сидоров", "Александр", new DateTime(1993, 8, 14), "sidorov@mail.ru", "252-44-68");
        Note note2 = new Note("Петров", "Сергей", new DateTime(1985, 1, 25), "petrov@bk.ru", "222-25-34");
        Note note3 = new Note("Иванов", "Иван", new DateTime(2001, 10, 15), "ivanov@mail.ru", "242-25-68");

        Notebook book = new Notebook();

        book.AddNote(note1);
        book.AddNote(note2);
        book.AddNote(note3);

        Console.WriteLine("Before sort:");
        for (int i = 0; i < book.Size; i++)
        {
            book.ShowNode(i);
        }

        book.Sort();
        Console.WriteLine("\nAfter sort:");
        for (int i = 0; i < book.Size; i++)
        {
            book.ShowNode(i);
        }

        Console.WriteLine("Please, press any key");
        Console.ReadKey();
        Console.Clear();

        if (book.Search())
        {
            Console.WriteLine("Search results:");
            foreach (int index in book.ListIndexResult)
            {
                book.ShowNode(index);
            }
            book.ListIndexResult.Clear();
            book.KeysSearchList.Clear();
        }
        else Console.WriteLine("Entries with such fields are not in the address book");

        Console.WriteLine("Please, press any key");
        Console.ReadKey();
        Console.Clear();

        Note note4 = book[2];
        book.DeleteNote(2);
        Console.WriteLine("Delete one note:");
        for (int i = 0; i < book.Size; i++)
        {
            book.ShowNode(i);
        }
        Console.WriteLine("Please, press any key");
        Console.ReadKey();
        Console.Clear();
        book[2] = note4;
        Console.WriteLine("Add note:");

        for (int i = 0; i < book.Size; i++)
        {
            book.ShowNode(i);
        }
        Console.WriteLine("Please, press any key");
        Console.ReadKey();
        Console.Clear();
    }
}
}
