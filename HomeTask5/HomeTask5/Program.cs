using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
class Program
{
    static void Main(string[] args)
    {
        Car[] cars = new Car[4]{ new Bus("Bus: FiatDucato", "10", 150),
                                 new SportCar("Sport car: Ferrari", "315", 300),
                                 new Truck("Truck: Volvo", "27", 140),
                                 new LightCar("Light car: Honda", "49", 280)};
        var taskRace = new Race(cars, 4);
        taskRace.CurrentStateRace();
    }
}
}
