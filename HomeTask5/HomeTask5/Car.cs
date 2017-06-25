using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
abstract class Car
{
    public int _speed { get; set; }
    public string _type { get; set; }

    public Car(string type, int speed)
    {
        _type = type;
        _speed = speed;
    }

    public abstract void Move();

    public virtual void ShowCar()
    {
        Console.Write($"\n{_type}");
    }
}
}
