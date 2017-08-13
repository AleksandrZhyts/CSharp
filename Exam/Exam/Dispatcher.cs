using System;

namespace Exam
{
class Dispatcher
{
    #region Fields
        public string Name;
        public int WeatherAdjustment;
        public int Penalty = 0;
        public bool isCrashed = false;
        public bool isStart = false;
        public bool isFinish = false;
        public bool isGood = false;
    #endregion

    public Dispatcher(string name, int weatherAdj)
    {
        Name = name;
        WeatherAdjustment = weatherAdj;
    }

    public void ShowFlightInformation(int speed, int height)
    {
        isGood = false;
        Console.WriteLine($"\n\tCurrent speed: {speed} \n\tcurrent height: {height} ");
        if (speed > 1000)
        {
            Penalty += 100;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\tDispatcher: {Name} - Attention! Current speed = {speed}, you must slow down! ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        else
        {
            if (speed > 50)  
            {
                int Hp = 7 * speed - WeatherAdjustment;
                Console.WriteLine($"\tDispatcher: {Name} - Recommended height: {Hp} ");
                if (Math.Abs(Hp - height) >= 300 && Math.Abs(Hp - height) < 600) Penalty += 25;
                if (Math.Abs(Hp - height) >= 600 && Math.Abs(Hp - height) < 1000) Penalty += 50;
                if (Math.Abs(Hp - height) < 300)
                {
                    isGood = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\tDispatcher {Name} - well done");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (Math.Abs(Hp - height) > 1000)
                {
                    isCrashed = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tThe plane crashed!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                if (Penalty >= 1000)
                {
                    isFinish = true;
                    Console.WriteLine($"\tDispatcher: {Name} - The pilot is not fit to fly!");
                }
            }
            else
                if (isStart == true && speed == 0)
                {
                    if (height != 0)
                    {
                        isCrashed = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tThe plane crashed!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else isFinish = true;             
                }
        }
        Console.Write("Press any key...");
        Console.ReadKey();
    }
}
}
