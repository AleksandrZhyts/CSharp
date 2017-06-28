using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Задание 1. Программа «Записная книжка»
Описать класс «записная книжка».
Предусмотреть возможность работы с произвольным числом  записей, 
реализовать поиск необходимой информации по какому-либо признаку 
                        (по фамилии, имени, дате рождения, e-mail, номеру телефона),
а также по нескольким признакам  одновременно, 
реализовать добавление и удаление записей, 
сортировку по фамилии, 
доступ к записи по номеру. 
Написать программу, демонстрирующую все разработанные элементы класса.
*/

namespace Lab6
{
public struct Note
{
    public string LastName;
    public string Name;
    public DateTime Birthday;
    public string Email;
    public string Phone;

    public Note(string lastName, string name, DateTime date, string email, string phone)
    {
        LastName  = lastName;
        Name  = name;
        Birthday = date;
        Email = email;
        Phone = phone;
    }
}

class Notebook : IEnumerable
{
    ArrayList book; 

    public Notebook()
    {
        book = new ArrayList();
    }

    public Notebook(int size)
    {
        book = new ArrayList(size);
    }
   
    public int Size
    {
        get
        {
            return book.Count;
        }
    }

    public Note this[int index]
    {
        get
        {
            if (book.Count != 0 && index >= 0 && index < book.Count)
            {
                return (Note)book[index];
            }
            else throw new IndexOutOfRangeException();
        }
        set
        {
            if (index >= 0 && index <= book.Count)
            {
                book.Insert(index, value);
            }
            else throw new IndexOutOfRangeException();
        }
    }

    public void AddNote(Note note)
    {
        book.Add(note);
    }

    public void DeleteNote(int index)
    {
        if (index >= 0 && index < book.Count)
        {
            book.RemoveAt(index);
        }
        else throw new IndexOutOfRangeException();
    }

    public void DeleteNote(Note note)
    {     
        book.Remove(note);  
    }

    public Dictionary<int,string> KeysSearchList = new Dictionary<int, string>();
    public List<int> ListIndexResult = new List<int>();

    private void MenuSearch()
    {
        Console.Write("Search using:\n\t1 - Last Name\n\t2 - Name\n\t3 - Birthday\n\t4 - Email\n\t5 - Phone\n\t0 - Exit\n" +
                        "Make a selection separated by a comma: ");
        string[] arrayChars = Console.ReadLine().Split(",. ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        foreach (string choiseChar in arrayChars)
        {
            int choiseInt;
            if (!int.TryParse(choiseChar, out choiseInt))
                throw new ArgumentException("Argument invalid!");
            else
                switch(choiseInt)
                {
                    case 1:
                        Console.Write("Enter Last Name to search: ");
                        KeysSearchList.Add(choiseInt, Console.ReadLine());
                        break;
                    case 2:
                        Console.Write("Enter Name to search: ");
                         KeysSearchList.Add(choiseInt, Console.ReadLine());
                        break;
                    case 3:
                        Console.Write("Enter birthday to search: ");
                        KeysSearchList.Add(choiseInt, Console.ReadLine());
                        break;
                    case 4:
                        Console.Write("Enter email to search: ");
                        KeysSearchList.Add(choiseInt, Console.ReadLine());
                        break;
                    case 5:
                        Console.Write("Enter phone to search: ");
                        KeysSearchList.Add(choiseInt, Console.ReadLine());
                        break;
                    default: return;
                }
        }
    }

    public bool Search()
    {
        MenuSearch();
        if (KeysSearchList.Count == 0) return false;       
        foreach (KeyValuePair<int, string> p in KeysSearchList)
        {
            int index = 0;
            while (index < book.Count)
            {
                switch (p.Key)
                {
                    case 1:
                        if (string.Compare(((Note)book[index]).LastName, p.Value) == 0 && ListIndexResult.BinarySearch(index) < 0)
                            ListIndexResult.Add(index);
                        break;
                    case 2:
                        if (string.Compare(((Note)book[index]).Name, p.Value) == 0 && ListIndexResult.BinarySearch(index) < 0)
                             ListIndexResult.Add(index);
                        break;
                    case 3:
                        if (string.Compare(((Note)book[index]).Birthday.ToShortDateString(), p.Value) == 0 && ListIndexResult.BinarySearch(index) < 0)
                            ListIndexResult.Add(index);
                        break;
                    case 4:
                        if (string.Compare(((Note)book[index]).Email, p.Value) == 0 && ListIndexResult.BinarySearch(index) < 0)
                            ListIndexResult.Add(index);
                        break;
                    case 5:
                        if (string.Compare(((Note)book[index]).Phone, p.Value) == 0 && ListIndexResult.BinarySearch(index) < 0)
                             ListIndexResult.Add(index);
                        break;
                }
                index++;
            }
        }
        return (ListIndexResult.Count != 0); 
    }

    public void ShowNode(int index)
    {
        Note note = (Note)book[index];
        Console.WriteLine($"Запись № {index + 1}:");
        Console.WriteLine($"\t{note.LastName}");
        Console.WriteLine($"\t{note.Name}");
        Console.WriteLine($"\t{note.Birthday.ToShortDateString()}");
        Console.WriteLine($"\t{note.Email}");
        Console.WriteLine($"\t{note.Phone}");
    }

    public void Sort()
    {
        book.Sort(new NotesComparer());  //chek without class
    }

    public IEnumerator GetEnumerator()
    {
        return book.GetEnumerator();
    }

    class NotesComparer : IComparer
    {
        public int Compare(object note1, object note2)
        {
            return string.Compare(((Note)note1).LastName, ((Note)note2).LastName);
        }
    }
}    
}
