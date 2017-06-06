using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankomat.Clients;

namespace Bankomat.Banks
{
class Bank
{
    public static string _nameBank;
    public const string SUCCESS = "Operation completed successfully";

    static Bank()
    {
        _nameBank = "Bank of your dream";
    }

    public bool IsAuthorization(Client Customers)
    {
        int TryAutoriz = 3;
        Console.Write("\nEnter pincode: ");
        int pinCode = Convert.ToInt32(Console.ReadLine());
        while (TryAutoriz > 0)
        {
            if (Customers._account.IsPassword(pinCode))
            {
                return true;
            }
            if (--TryAutoriz > 0)
            {
                Console.WriteLine("Error. Invalid pincode!");
                Console.Write($"\n{TryAutoriz} attempts left. Enter pincode: ");
                pinCode = Convert.ToInt32(Console.ReadLine());
            }
        }
        return false;
    }

    public bool IsContinue()
    {
        Console.Write("Do you want to continue? (1-yes/0 - no): ");
        int choise = Convert.ToInt32(Console.ReadLine());
        return (choise == 1) ? true : false;
    }

    public int MenuSession()
    {
        Console.WriteLine("\t1 - Show balance");
        Console.WriteLine("\t2 - Put money into an account");
        Console.WriteLine("\t3 - Withdraw money");
        Console.WriteLine("\t0 - End session");
        Console.Write("Make a choise: ");
        int choise = Convert.ToInt16(Console.ReadLine());
        return ((choise >= 0) && (choise <= 3)) ? choise : 0;
    }

    public void RunOperation(Client Customers, int choise)
    {
        int AmountMoney;
        EnumOperation.TypeSession Operation =
                                    (EnumOperation.TypeSession)Enum.GetValues(typeof(EnumOperation.TypeSession)).GetValue(choise);
        switch (Operation)
        {
            case EnumOperation.TypeSession.ShowBalance:
                Console.WriteLine($"Balance: {Customers._account.GetBalance()}");
                break;
            case EnumOperation.TypeSession.DepositFunds:
                Console.WriteLine("Enter amount:");
                AmountMoney = Convert.ToInt32(Console.ReadLine());
                if (Customers._account.PutMoney(AmountMoney))
                {
                    Console.WriteLine(SUCCESS);
                }
                break;
            case EnumOperation.TypeSession.WithdrawFunds:
                Console.WriteLine("Enter the withdrawal amount:");
                AmountMoney = Convert.ToInt32(Console.ReadLine());
                if (Customers._account.WithdrawMoney(AmountMoney))
                {
                    Console.WriteLine(SUCCESS);
                }
                else
                {
                    Console.WriteLine("Error. Insufficient funds on the account");
                }
                break;
            default:
                break;
        }
    }
}
}
