using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{

public delegate void FlightDelegate();

class Trainer
{
    public static void FlightTrainer()
    {
        var aircraft = new Aircraft();
        FlightDelegate flight = aircraft.StartFlight;
        flight += aircraft.FlightControl;
        flight += aircraft.CheckResult;
        flight();
    }
}
}
