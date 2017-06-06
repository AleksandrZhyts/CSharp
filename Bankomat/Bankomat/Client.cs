using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bankomat.Accounts;

namespace Bankomat.Clients
{
class Client
{       
    public string _name { get; set; }
    public string _phone { get; set; }
    public string _adress { get; set; }
    public Account _account;

    public Client(string name, string phone, string adress, int money)
    {
        _name = name;
        _phone = phone;
        _adress = adress;
        _account = new Account(money);
    }
}
}
