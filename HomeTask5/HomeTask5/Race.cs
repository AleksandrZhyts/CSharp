using HomeTask5;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask5
{
class Race : IEnumerable, ICloneable
{
    Car[] _cars;
    bool isFinish = false;

    public delegate void GetStart();
    public GetStart getStart;
    public GetStart startRace;
 
    public Race(Car[] cars)
    {
       _cars = (Car[])cars.Clone();
        GetOffToStart();
        StartRace();
    }

    private void GetOffToStart()
    {
        Console.WriteLine("Participants of the race:");
        foreach (Car car in _cars)
        {
            getStart += car.GetOffToStart;
        }
    }

    private void StartRace()
    {
        for (int i = 0; i < _cars.Length; i++)
        {
            if (_cars[i] is Bus) startRace += ((Bus)_cars[i]).StartRace;
            if (_cars[i] is SportCar) startRace += ((SportCar)_cars[i]).StartRace;
            if (_cars[i] is Truck) startRace += ((Truck)_cars[i]).StartRace;
            if (_cars[i] is LightCar) startRace += ((LightCar)_cars[i]).StartRace;
        }
    }

    private void CurrentInformationRace()
    {
        Array.Sort(_cars, new CarsComparer());
        for (int i = _cars.Length - 1; i >= 0; i--)
        {
             _cars[i].ShowCar();
            if (_cars[i] is Bus)
                Console.WriteLine($" - current position: {_cars.Length - i}\nDistance traveled: {((Bus)_cars[i]).GetDistanceCurrent:F2}");
            if (_cars[i] is SportCar)
                Console.WriteLine($" - current position: {_cars.Length - i}\nDistance traveled: {((SportCar)_cars[i]).GetDistanceCurrent:F2}");
            if (_cars[i] is LightCar)
                Console.WriteLine($" - current position: {_cars.Length - i}\nDistance traveled: {((LightCar)_cars[i]).GetDistanceCurrent:F2}");
            if (_cars[i] is Truck)
                Console.WriteLine($" - current position: {_cars.Length - i}\nDistance traveled: {((Truck)_cars[i]).GetDistanceCurrent:F2}");
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
                ((Bus)car).Finish += delegate (object sender, EventArgs e) 
                { isFinish = true; };
                ((Bus)car).RaceFinish();
            }

            if (car is SportCar)
            {
                ((SportCar)car).Finish += delegate (object sender, EventArgs e) 
                { isFinish = true; };
                ((SportCar)car).RaceFinish();
            }
            if (car is LightCar)
            {
                ((LightCar)car).Finish += delegate (object sender, EventArgs e) 
                { isFinish = true; };
                ((LightCar)car).RaceFinish();
            }
            if (car is Truck)
            {
                ((Truck)car).Finish += delegate (object sender, EventArgs e) 
                { isFinish = true; };
                ((Truck)car).RaceFinish();
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
        Array.Sort(_cars, new CarsComparer());
        Console.Clear();
        Console.WriteLine("\tThe race is over!");
        for (int i = _cars.Length - 1; i >= 0; i--)
        {
            Console.Write($"\n{_cars.Length - i} place: ");
            _cars[i].ShowCar();
        }
        Console.WriteLine();
    }

    class CarsComparer : IComparer
    {
        public int Compare(Object car1, Object car2)
        {
            double distance1 = 0,
                   distance2 = 0;
            if (car1 is Bus) distance1 = ((Bus)car1).GetDistanceCurrent;
            if (car1 is SportCar) distance1 = ((SportCar)car1).GetDistanceCurrent;
            if (car1 is LightCar) distance1 = ((LightCar)car1).GetDistanceCurrent;
            if (car1 is Truck) distance1 = ((Truck)car1).GetDistanceCurrent;
            if (car2 is Bus) distance2 = ((Bus)car2).GetDistanceCurrent;
            if (car2 is SportCar) distance2 = ((SportCar)car2).GetDistanceCurrent;
            if (car2 is LightCar) distance2 = ((LightCar)car2).GetDistanceCurrent;
            if (car2 is Truck) distance2 = ((Truck)car2).GetDistanceCurrent;
            return (distance1 < distance2) ? -1 : ((distance1 > distance2) ? 1 : 0);
        }
    }

    public IEnumerator GetEnumerator()
    {
        return _cars.GetEnumerator();
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}
}
