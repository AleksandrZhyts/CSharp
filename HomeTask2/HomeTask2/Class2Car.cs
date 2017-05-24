using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask2
{
partial class Car
{
    public void Discont(ref int numberTrips, out int disc)
    {
        if ((numberTrips != 0) && (numberTrips % 10 == 0))
        {
            numberTrips = 10;
        }
        else numberTrips %= 10;

        switch (numberTrips)
        {
            case 3:
            case 4:
                disc = 5;
                break;
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
                disc = 10;
                break;
            case 10:
                disc = 100;
                numberTrips = 0;
                break;
            
            default:
                disc = 0;
                break;
        }
    }
}
}
