using HomeTask5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
class Race
{
    Car[] _cars;
    int _numberCars;
    bool isFinish = false;

    public delegate Boolean Comparer(Object elem1, Object elem2);
    public delegate void GetStart();
    public GetStart getStart;
    public GetStart startRace;
 
    public Race(Car[] cars, int numberCars)
    {
        _numberCars = numberCars;
        _cars = new Car[_numberCars];
        _cars = cars;
        GetOffToStart();
        StartRace();
    }

    private void GetOffToStart()
    {
        Console.WriteLine("Participants of the race:");
        if (_cars[0] is Bus) getStart = new GetStart((_cars[0] as Bus).GetOffToStart);
        if (_cars[0] is SportCar) getStart = new GetStart((_cars[0] as SportCar).GetOffToStart);
        if (_cars[0] is Truck) getStart = new GetStart((_cars[0] as Truck).GetOffToStart);
        if (_cars[0] is LightCar) getStart = new GetStart((_cars[0] as LightCar).GetOffToStart);
        for (int i = 1; i < _numberCars; i++)
        {
            if (_cars[i] is Bus) getStart += (_cars[i] as Bus).GetOffToStart;
            if (_cars[i] is SportCar) getStart += (_cars[i] as SportCar).GetOffToStart;
            if (_cars[i] is Truck) getStart += (_cars[i] as Truck).GetOffToStart;
            if (_cars[i] is LightCar) getStart += (_cars[i] as LightCar).GetOffToStart;
        }
    }

    private void StartRace()
    {
        if (_cars[0] is Bus) startRace = new GetStart((_cars[0] as Bus).StartRace);
        if (_cars[0] is SportCar) startRace = new GetStart((_cars[0] as SportCar).StartRace);
        if (_cars[0] is Truck) startRace = new GetStart((_cars[0] as Truck).StartRace);
        if (_cars[0] is LightCar) startRace = new GetStart((_cars[0] as LightCar).StartRace);
        for (int i = 1; i < _numberCars; i++)
        {
            if (_cars[i] is Bus) startRace += (_cars[i] as Bus).StartRace;
            if (_cars[i] is SportCar) startRace += (_cars[i] as SportCar).StartRace;
            if (_cars[i] is Truck) startRace += (_cars[i] as Truck).StartRace;
            if (_cars[i] is LightCar) startRace += (_cars[i] as LightCar).StartRace;
        }
    }

    private void CurrentInformationRace()
    {
        BubbleSorter.Sort(_cars, new Comparer(CarsDistanceComparer));
        for (int i = _numberCars - 1; i >= 0; i--)
        {
             _cars[i].ShowCar();
            if (_cars[i] is Bus)
                Console.WriteLine($" - current position: {_numberCars - i}\nDistance traveled: {(_cars[i] as Bus).GetDistanceCurrent:F2}");
            if (_cars[i] is SportCar)
                Console.WriteLine($" - current position: {_numberCars - i}\nDistance traveled: {(_cars[i] as SportCar).GetDistanceCurrent:F2}");
            if (_cars[i] is LightCar)
                Console.WriteLine($" - current position: {_numberCars - i}\nDistance traveled: {(_cars[i] as LightCar).GetDistanceCurrent:F2}");
            if (_cars[i] is Truck)
                Console.WriteLine($" - current position: {_numberCars - i}\nDistance traveled: {(_cars[i] as Truck).GetDistanceCurrent:F2}");
        }
        Console.WriteLine("\nPlease, press any key to continue...\n");
        Console.ReadKey();
        Console.Clear();
    }

    private void CheckResult()
    {
        foreach (Car car in _cars)
        {
            if (car is Bus)
            {
                (car as Bus).Finish += delegate (object sender, EventArgs e) 
                { isFinish = true; };
                (car as Bus).RaceFinish();
            }

            if (car is SportCar)
            {
                (car as SportCar).Finish += delegate (object sender, EventArgs e) 
                { isFinish = true; };
                (car as SportCar).RaceFinish();
            }
            if (car is LightCar)
            {
                (car as LightCar).Finish += delegate (object sender, EventArgs e) 
                { isFinish = true; };
                (car as LightCar).RaceFinish();
            }
            if (car is Truck)
            {
                (car as Truck).Finish += delegate (object sender, EventArgs e) 
                { isFinish = true; };
                (car as Truck).RaceFinish();
            }
        }
    }

    public void CurrentStateRace()
    {
        getStart();
        startRace();
        int step = 0;
        Console.WriteLine("\n\nRace is start:");
        while (!isFinish)
        {
            if ((++step) % 5 == 0) CurrentInformationRace();           
            foreach (Car car in _cars)
            {
                car.Move();
            }
            CheckResult();
        }
        Rewording();
    }

    private void Rewording()
    {
        BubbleSorter.Sort(_cars, new Comparer(CarsDistanceComparer));
        Console.Clear();
        Console.WriteLine("\tThe race is over!");
        for (int i = _numberCars - 1; i >= 0; i--)
        {
            Console.Write($"\n{_numberCars - i} place: ");
            _cars[i].ShowCar();
        }
        Console.WriteLine();
    }

    static class BubbleSorter
    {
        static public void Sort(Object[] array, Comparer comparer)
        {
            for (Int32 i = 0; i < array.Length; i++)
                for (Int32 j = i + 1; j < array.Length; j++)
                    if (comparer(array[j], array[i]))
                    {
                        Object buffer = array[i];
                        array[i] = array[j];
                        array[j] = buffer;
                    }
        }
    }

    static public Boolean CarsDistanceComparer(Object car1, Object car2)
    {
        double distance1 = 0,
               distance2 = 0;
        if (car1 is Bus) distance1 = (car1 as Bus).GetDistanceCurrent;
        if (car1 is SportCar) distance1 = (car1 as SportCar).GetDistanceCurrent;
        if (car1 is LightCar) distance1 = (car1 as LightCar).GetDistanceCurrent;
        if (car1 is Truck) distance1 = (car1 as Truck).GetDistanceCurrent;
        if (car2 is Bus) distance2 = (car2 as Bus).GetDistanceCurrent;
        if (car2 is SportCar) distance2 = (car2 as SportCar).GetDistanceCurrent;
        if (car2 is LightCar) distance2 = (car2 as LightCar).GetDistanceCurrent;
        if (car2 is Truck) distance2 = (car2 as Truck).GetDistanceCurrent;
        return distance1 < distance2;
    }
}
}
