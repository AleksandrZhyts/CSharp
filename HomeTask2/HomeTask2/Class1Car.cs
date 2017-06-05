using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{

enum TransportType
{
    Hatchback, Sedan, Wagon, Convertible, Minibus
}

partial class Car
{
    private static string _owner;
    private static string _company;

    private string _model;
    private string _color;

    public string TypeFuel { get; set; } = "petrol";
    public DateTime YearOfManufacture { get; set; } = new DateTime(2017, 01, 15);

    byte _countDoors;
    public void CountDoors(byte countDoors)
    {
        _countDoors = (countDoors < 0 || countDoors > 5) ? (byte)4 : countDoors;
    }
    public byte CountDoors()
    {
        return _countDoors;
    }

    short _maxSpeed;
    public void MaxSpeed(short maxSpeed)
    {
        _maxSpeed = (maxSpeed < 0) ? (short)0 : maxSpeed;
    }

    public short MaxSpeed()
    {
        return _maxSpeed;
    }

    public TransportType TypeCar { get; set; } = TransportType.Sedan;

    public Car() : this("Undefined brand", "Undefined color") {}
    public Car(string brand) : this(brand, "Undefined color") {}
    public Car(string brand, string color)
    {
        _model = brand;
        _color = color;
    }

    static Car()
    {
        _owner = "Alex";
        _company = "Taxi777";
    }

    public static void ShowOwner()
    {
        Console.WriteLine($"Company: {_company}\tOwner: {_owner}\n");
    }

    public void Init(short speed, TransportType trType, DateTime date, string typeFuel, byte numDoors )
    {
        MaxSpeed(speed);
        TypeCar = trType;
        YearOfManufacture = date;
        TypeFuel = typeFuel;
        CountDoors(numDoors);
    }

    public void Print()
    {
        Console.Write($"Car: {_model}  {TypeCar}  {_color} ");
        Console.Write($"{YearOfManufacture.ToShortDateString()} "); 
         Console.Write($"{TypeFuel} speed: {_maxSpeed}\n");
    }

    public void Price(TransportType typeCar, out int price)
    {
        switch (typeCar)
        {
            case TransportType.Convertible:
                price = 20;
                break;
            case TransportType.Hatchback:
                price = 5;
                break;
            case TransportType.Minibus:
                price = 15;
                break;
            case TransportType.Sedan:
                price = 5;
                break;
            case TransportType.Wagon:
                price = 10;
                break;
            default:
                price = 0;
                break;
        }
    }
}
}
