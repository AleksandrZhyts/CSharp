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
        Car[] cars = new Car[4]{ new Bus("Bus: FiatDucato", "10", 200),
                                 new SportCar("Sport car: Ferrari", "315", 250),
                                 new Truck("Truck: Volvo", "27", 200),
                                 new LightCar("Light car: Honda", "49", 250)};
        var taskRace = new Race(cars);
        taskRace.CurrentStateRace();
    }
}
}
