using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask6
{
class Player : EventArgs
{
    Queue<Karta> SetKarts;
    public string Name { get; set; } 
    public bool isLost { get; private set; }

    public Player(Queue<Karta> setKarts, string name)
    {
        this.SetKarts = setKarts;
        Name = name;
        isLost = false;
    }

    public void AddKart(Karta karta)
    {
        SetKarts.Enqueue(karta);
    }

    public Karta OpenKart()
    {
        return SetKarts.Peek();   
    }

    public void LostKart()
    {
        if (SetKarts.Count > 1) SetKarts.Dequeue();
        else isLost = true;
    }

    public void ShowKarts()
    {
        Console.WriteLine(Name);
        foreach(Karta karta in SetKarts)
        {
            Console.WriteLine($"{((Karta)karta).type} {((Karta)karta).suit}");
        }
    }
}
}
