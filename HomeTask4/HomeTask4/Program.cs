using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Задание 1. Реализовать программу “Строительство дома”.
 Реализовать:
- классы 
•	House (Дом), Basement (Фундамент), Walls (Стены), Door (Дверь), Window (Окно), Roof (Крыша); 
•	Team (Бригада строителей), Worker (Строитель), TeamLeader (Бригадир), 
- интерфейсы 
•	IWorker, IPart.
Все части дома должны реализовать интерфейс IPart (Часть дома), для рабочих и бригадира предоставляется базовый интерфейс IWorker (Рабочий).
Бригада строителей (Team) строит дом (House). Дом состоит из фундамента (Basement), стен (Wall), окон (Window), дверей (Door), крыши (Part).
Согласно проекту, в доме должно быть 1 фундамент, 4 стены, 1 дверь, 4 окна и 1 крыша.
Бригада начинает работу, и строители последовательно “строят” дом, начиная с фундамента. 
Каждый строитель не знает заранее, на чём завершился предыдущий этап строительства, поэтому он “проверяет”, 
что уже построено и продолжает работу. Если в игру вступает бригадир (TeamLeader), он не строит, а формирует отчёт, 
что уже построено и какая часть работы выполнена.
В конечном итоге на консоль выводится сообщение, что строительство дома завершено и отображается “рисунок дома” 
(вариант отображения выбрать самостоятельно).*/

namespace HomeTask4
{
class Program
{
    static void Main(string[] args)
    {
        var parts = new IPart[5]
        {
            new Roof(),            
            new Window(),
            new Door(),
            new Walls(),
            new Basement()
        };
        var build = new House(parts, 5);

        var workers = new IWorker[3]
        {
            new Worker("Alex"),
            new Worker("Sergey"),
            new TeamLeader("Jon")
        };
        var construction = new Team(workers, 3);

        while (construction.IsWorkFinish(build) != true)
        {
            construction.HouseBuilding(build);
        }

        Console.WriteLine("\nOur house consists:");
        build.ShowHouse();
    }
}
}
