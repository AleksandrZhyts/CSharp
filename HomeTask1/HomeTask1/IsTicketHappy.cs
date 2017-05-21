using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask1
{
class IsTicketHappy
{
    public bool Check()
    {
        var getNumber = new InputNumberTicket();
        int numberTicket = getNumber.InputData();
        int sumFirstDigits = (numberTicket / 1000) % 10 + (numberTicket / 10000) % 10 + (numberTicket / 100000) % 10;
        int sumLastDigits = (numberTicket % 10) + (numberTicket % 100) / 10 + (numberTicket % 1000) / 100;
        return (sumFirstDigits == sumLastDigits);
    }
}
}
