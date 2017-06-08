using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankomat.Clients;
using Bankomat.Banks;

namespace Bankomat
{
class RunBankomat
{
    public void OpenSession()
    {
        Client Customer1 = new Client("Alex Ivanov", "222-22-22", "Minsk, Tolstogo,10", 10000);
        Console.WriteLine($"Your pincode is {Customer1._account.GetPassword()}");
        Bank Bank1 = new Bank();
        Console.WriteLine($"Welcome to the \"{Bank._nameBank}\"");
        if (Bank1.IsAuthorization(Customer1))
        {
            Console.WriteLine($"Hello mr/ms {Customer1._name}");
            int choise;
            do
            {
                choise = Bank1.MenuSession();
                if (choise == 0) return;
                Bank1.RunOperation(Customer1, choise);
                Console.ReadKey();
                Console.Clear();
            } while (Bank1.IsContinue());
        }
        else Console.WriteLine("Unable to open session");     
    }
}
}
