using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
class CarPark
{
    public void Taxi()
    {
        Car[] garage = new Car[] { new Car("mersedec 200","black"),
                                   new Car("mersedec 500", "silver metalic"),
                                   new Car("audi TT", "white"),
                                   new Car("mersedec sprinter", "black"),
                                   new Car("bmw 730", "black")};

        garage[0].Init(200, TransportType.Wagon, new DateTime(2015, 10, 15), "diesel", 5);
        garage[1].Init(250, TransportType.Sedan, new DateTime(2016, 3, 11), "petrol", 4);
        garage[2].Init(260, TransportType.Convertible, new DateTime(2014, 5, 25), "petrol", 2);
        garage[3].Init(140, TransportType.Minibus, new DateTime(2017, 1, 25), "diesel", 4);
        garage[4].Init(220, TransportType.Sedan, new DateTime(2014, 7, 19), "diesel", 4);

        Car.ShowOwner();

        int price;
        foreach (Car mashine in garage)
        {
            mashine.Print();
            mashine.Price(mashine.TypeCar, out price);
            Console.WriteLine($"The price is {price} rub per kilometr");
            Console.WriteLine("-----------------------------------------------------------------------------");
        }

        int discont;
        Console.WriteLine("Enter the trip number:");
        int numberTrip = int.Parse(Console.ReadLine());

        garage[0].Discont(ref numberTrip, out discont);
        Console.WriteLine($"Your discont for the trip is {discont} %");
    }
}
}
