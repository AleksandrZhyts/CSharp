using System;
using WhetherViewer;

namespace Lab8
{
class UsingWeatherViewer
{
    public void Menu()
    {
        try
        {
            Viewer wViewer = new Viewer("GisMeteo.ini");
            while (true)
            {
                Console.WriteLine("\t1 - List of cities\n\t2 - Weather in the selected city\n\t3 - Warmest weather in these cities\n\tq - Exit");
                int choise;
                var answer = Console.ReadLine();
                if (!int.TryParse(answer, out choise))
                    break;
                switch (choise)
                {
                    case 1:
                        wViewer.ShowListCity();
                        break;
                    case 2:
                        wViewer.ShowListCity();
                        Console.Write("Enter code city: ");
                        string codeCity = Console.ReadLine();
                        wViewer.ShowWeather(codeCity);
                        break;
                    case 3:
                        int tempr;
                        string City;
                        Console.WriteLine("Wait...");
                        wViewer.FindWamerstWeather(out City, out tempr);
                        Console.WriteLine($"\nWarmest weather in {City}: {tempr} degrees");
                        break;
                    default:
                        return;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        catch
        {
            Console.WriteLine("Error! Not found ini-file");
        }
    }   
}
}
