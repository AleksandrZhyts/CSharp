using System;
using System.Collections.Generic;

namespace Exam
{
class Aircraft
{
    #region Fields
        protected int Speed;
        protected int Height;
        protected int Penalty;
        protected List<Dispatcher> DispList = new List<Dispatcher>();
        protected bool isStart = false;
        protected bool isFinish = false;
        protected bool isMaxSpeed = false;
        protected bool isCrashed = false;
        protected bool isCall = true;
    #endregion

    #region Delegates
        protected delegate int SpeedDelegate();
        protected delegate int HeightDelegate();
    #endregion

    public Aircraft()
    {
        Console.Write("Enter the number of dispatchers: ");
        int maxDisp = InputData();
        int countDisp = (maxDisp < 2) ? 2 : maxDisp;
        for (int i = 0; i < countDisp; i++)
             AddDispatcher();
    }

    protected int InputData()
    {
        int data;
        while (true) 
        {
            var inputData = Console.ReadLine();
            if (!int.TryParse(inputData, out data))
                Console.Write("Invalid input. Please, repeat the input: ");
            else break;
        } 
        return data;
    }

    protected void AddDispatcher()
    {
        isCall = false;
        Console.Write($"\nEnter the name of the dispatcher: ");
        string name = Console.ReadLine();
        Random rand = new Random(Guid.NewGuid().GetHashCode());
        int weatherAdj = rand.Next(-200, 200);
        DispList.Add(new Dispatcher(name, weatherAdj));   
    }

    protected void DelDispatcher()
    {
        isCall = false;
        if (DispList.Count > 2)
        {
            Console.WriteLine("\nEnter the name dispatcher to delete:");
            string name = Console.ReadLine();
            for (int i = 0; i < DispList.Count; i++)
            {
                if (string.Compare(name, DispList[i].Name) == 0)
                {
                    Penalty += DispList[i].Penalty;
                    DispList.RemoveAt(i);
                    break;
                }
            }
        }
     }

    protected void FlightInformation()
    {
        SpeedDelegate speed = () => { return Speed; };
        HeightDelegate height = () => { return Height; };
        foreach (Dispatcher item in DispList)
        {
            item.ShowFlightInformation(speed(), height());
            if (!item.isGood || item.isCrashed || item.isFinish)
            {
                isCrashed = item.isCrashed;
                isFinish = item.isFinish;
                return;
            }
        }
    }

    public void StartFlight()
    {
        Speed = Height = Penalty = 0;
        foreach (Dispatcher item in DispList)
            item.isStart = true;   
    }

    protected void ShowMenu()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\tPress <Shift> + <RightArrow> => Speed + 150 km/h" + 
                          "\n\tPress <Shift> + <LeftArrow>  => Speed - 150 km/h" + 
                          "\n\tPress <RightArrow>           => Speed + 50 km/h" +
                          "\n\tPress <LeftArrow>            => Speed - 50 km/h" +
                          "\n\tPress <Shift> + <UpArrow>    => Height + 500 m" +
                          "\n\tPress <Shift> + <DownArrow>  => Height - 500 m" +
                          "\n\tPress <UpArrow>              => Height + 250 m" +
                          "\n\tPress <DownArrow>            => Height - 250 m" +
                          "\n\tPress <+>                    => Add dispatcher" +
                          "\n\tPress <->                    => Delete dispatcher" +
                          "\n\tPress <Escape> or <Q>        => Interrupted exam");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("Make your choise: ");
    }

    public void FlightControl()
    {
        ConsoleKeyInfo key;
        while (!isFinish)
        {
            isCall = true;
            ShowMenu();
            key = Console.ReadKey(true);
            if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.RightArrow) Speed += 150;
            else
                if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.LeftArrow) Speed -= 150;
                else
                    if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.UpArrow) Height += 500;
                    else
                        if (key.Modifiers == ConsoleModifiers.Shift && key.Key == ConsoleKey.DownArrow) Height -= 500;
                        else           
                            switch (key.Key)
                            {
                                case ConsoleKey.LeftArrow: Speed -= 50;
                                    break;
                                case ConsoleKey.UpArrow: Height += 250;
                                    break;
                                case ConsoleKey.DownArrow: Height -= 250;
                                    break;
                                case ConsoleKey.RightArrow: Speed += 50;
                                    break;
                                case ConsoleKey.Add: AddDispatcher();
                                    break;
                                case ConsoleKey.Subtract: DelDispatcher();
                                    break;
                                case ConsoleKey.Escape:
                                case ConsoleKey.Q:
                                    return;
                            }
            if (Speed == 1000) isMaxSpeed = true;    
            if (isCall) FlightInformation();
            if (isCrashed) return;
        }
    }

    public void CheckResult()
    {
        if (isFinish && isMaxSpeed)
        {
            foreach (Dispatcher item in DispList)
            {
                Penalty +=item.Penalty;
            }
            if (Penalty >= 1000) Console.WriteLine($"\nThe exam is fail, penalties: {Penalty}");
            else Console.WriteLine($"\nExam passed with {Penalty} penalties");
        }
        else Console.WriteLine("\nThe exam is fail");
    }
}
}
