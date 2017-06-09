using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLib.WordOfTanks
{
public class Tank
{
    string _nameTank;
    int _levelAmmunition;
    int _levelArmor;
    int _levelManeuverability;

    public Tank(string name, Random rand)
    {
        _nameTank = name;
        Tuning(rand);
    }

    public void Tuning(Random rand)
    {
        _levelAmmunition = rand.Next(0, 100);
        _levelArmor = rand.Next(0, 100);
        _levelManeuverability = rand.Next(0, 100);
    }

    public string GetAmmunition()
    {
        return _levelAmmunition.ToString();
    }

    public string GetArmor()
    {
        return _levelArmor.ToString();
    }

    public string GetManeuverability()
    {
        return _levelManeuverability.ToString();
    }

    public string GetNameTank()
    {
        return _nameTank;
    }

    public override string ToString()
    {
        return $"{_nameTank} {{{GetAmmunition()}%,{GetArmor()}%,{GetManeuverability()}%}}";
    }

        public static bool operator ^(Tank tank1, Tank tank2)
    {
        return (tank1._levelAmmunition > tank2._levelAmmunition && tank1._levelArmor > tank2._levelArmor ||
                tank1._levelAmmunition > tank2._levelAmmunition && tank1._levelManeuverability > tank2._levelManeuverability ||
                tank1._levelManeuverability > tank2._levelManeuverability && tank1._levelArmor > tank2._levelArmor);
    }
} 
}
