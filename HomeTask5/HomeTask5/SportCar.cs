using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
class SportCar : Car
{
    public event EventHandler Finish;

    public void RaceFinish()
    {
        if ((isFinish == true) && Finish != null)
            Finish(this, EventArgs.Empty);
    }

    public string _number { get; set; }

    double distanceCurrent;
    public double GetDistanceCurrent
    {
        get
        {
            return distanceCurrent;
        }
    }

    int speedCurrent { get; set; }
    bool isFinish = false;
 
    public SportCar(string type, string number, int speed) : base(type, speed)
    {
        _number = number;
    }

    public override void GetOffToStart()
    {
        ShowCar();
    }

    public void StartRace()
    {
        distanceCurrent = 0;
        speedCurrent = 0;
    }

    public override void Move()
    {
        speedCurrent = rand.Next(0, _speed);
        distanceCurrent += speedCurrent * ConstValues.TimeInterval;
        if (distanceCurrent >= ConstValues.Distance) isFinish = true;
    }

    public override void ShowCar()
    {
        base.ShowCar();
        Console.Write($" number: {_number}");
    }
}
}
