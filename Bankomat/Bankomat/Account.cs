using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat.Accounts
{
class Account
{
    int _balance;
    int _account;
    int _password; 

    public Account (int money)
    {
        Random rand = new Random();
        _account = rand.Next();
        _balance = money;
        _password = rand.Next(1000, 9999);
    }

    public bool PutMoney(int money)
    {
        if (money > 0)
        {
            _balance += money;
            return true;
        }
        else return false;
    }
        
    public bool WithdrawMoney(int money)
    {
        if (money > 0 && _balance >= money)
        {
            _balance -= money;
            return true;
        }
        return false;
    }

    public int GetBalance()
    {
        return _balance;
    }

    public int GetAccount()
    {
        return _account;
    }

    public int GetPassword()
    {
        return _password;
    }

    public bool IsPassword(int password)
    {
        return (_password == password);
    }

    public bool SetPassword(int oldPassword, int newPassword)
    {
        if (IsPassword(oldPassword))
        {
            _password = newPassword;
            return true;
        }      
        return false;        
    }
}
}
