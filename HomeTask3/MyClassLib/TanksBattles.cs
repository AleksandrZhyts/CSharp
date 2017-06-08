using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLib.WordOfTanks;

namespace MyClassLib
{
public class TanksBattles
{
    Tank[] TanksArr;
    int _countTanks;

    public TanksBattles(int countTanks)
    {
        TanksArr = new Tank[countTanks];
        _countTanks = countTanks;     
    }

    public void Tuning(string nameBrigade, Random rand)
    {
        for (int i = 0; i < _countTanks; i++)
        {
            TanksArr[i] = new Tank(nameBrigade + (i + 1).ToString(), rand);
        }
    }

    public int Length
    {
        get { return TanksArr.Length; }
    }

    public Tank this[int index]
    {
        get
        {
            if (index >= 0 && index < TanksArr.Length)
            {
                return TanksArr[index];
            }
            throw new IndexOutOfRangeException();
        }
        set
        {
            if (index >= 0 && index < TanksArr.Length)
            {
                TanksArr[index] = value;
            }
            else throw new IndexOutOfRangeException();
        }
    }

    public void Battle(TanksBattles brigade1, TanksBattles brigade2)
    {
        try
        {
            for (int i = 0; i < brigade1.Length; i++)
            {
                brigade1[i].ShowTank();
                Console.Write(" : ");
                brigade2[i].ShowTank();

                if (brigade1[i] ^ brigade2[i])
                {
                    Console.Write($" - win {brigade1[i].GetNameTank()}\n");
                }
                else
                    if (brigade2[i] ^ brigade1[i])
                {
                    Console.Write($" - win {brigade2[i].GetNameTank()}\n");
                }
                else Console.Write($" - the battle without winners\n");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void TankOffensive(string nameBrigade1, string nameBrigade2)
    {
            Random rand = new Random();
            TanksBattles brigade1 = new TanksBattles(_countTanks),
                         brigade2 = new TanksBattles(_countTanks);

            brigade1.Tuning(nameBrigade1, rand);
            brigade2.Tuning(nameBrigade2, rand);

            Battle(brigade1, brigade2);
    }
}
}
