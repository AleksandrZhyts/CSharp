using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HomeTask6.EnumCart;

namespace HomeTask6
{
class Game
{
    List<Karta> Coloda;
    public int NumberPlayers { get; private set; }
    List<Player> GameTable;
    bool isGameOver = false;

    public Game(int numberPlayers)
    {
        Coloda = new List<Karta>(36);
        InitColoda();
        NumberPlayers = (numberPlayers < 2) ? 2 : numberPlayers;
        GameTable = new List<Player>(NumberPlayers);
        InitGameTable();
    }

    private void InitColoda()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Coloda.Add(new Karta((KartSuit)i, (KartType)j));
            }
        }
    }

    private void ShuffleColoda()
    {
        Random rand = new Random(Guid.NewGuid().GetHashCode());
        int index,
            timesToShuffle = 2;
        for (int j = 0; j < timesToShuffle; j++)
        {
            for (int i = 0; i < 36; i++)
            {
                index = rand.Next(0, 36);
                Karta tempKarta = Coloda[i];
                Coloda[i] = Coloda[index];
                Coloda[index] = tempKarta;
            }
        }
    }

    private void InitGameTable()
    {
        ShuffleColoda();
        int amountKarts = Coloda.Count / NumberPlayers,
            indexKart = 0;
        for (int i = 0; i < NumberPlayers; i++)
        {
            Queue<Karta> set = new Queue<Karta>(amountKarts);
            for (int j = 0; j < amountKarts; j++)
            {
                set.Enqueue(Coloda[indexKart++]);
            }
            GameTable.Add(new Player(set, "number " + (i + 1).ToString()));
        }
    }

    private void FindStrongerKart(out int indexPlayer)
    {
        indexPlayer = 0;
        for (int i = 0; i < GameTable.Count; i++)
        {
            if (GameTable[indexPlayer].OpenKart().Comparer(GameTable[i].OpenKart()) == -1)
            {
                indexPlayer = i;
            }
        }
    }

    private void WhoLost()
    {
        for (int i = 0; i < GameTable.Count; i++)
        {
            if (GameTable[i].isLost == true)
            {
                Console.WriteLine($"{GameTable[i].Name} is lost");
                GameTable.RemoveAt(i--);
            }
        }
        isGameOver = (GameTable.Count == 1);
    }

    public void StartGame()
    {
        int indexPlayer;
        while (!isGameOver)
        {
            FindStrongerKart(out indexPlayer);
            for (int i = 0; i < GameTable.Count; i++)
            {
                GameTable[indexPlayer].AddKart(GameTable[i].OpenKart());
                GameTable[i].LostKart();
            }
            WhoLost();
        }
        Rewarding();
    }

    private void Rewarding()
    {
        Console.WriteLine($"Player {GameTable[0].Name} is winer!");
    }
}
}
