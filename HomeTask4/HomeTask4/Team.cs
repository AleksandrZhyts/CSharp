using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
public class Team
{
    IWorker[] _workers;
    int _countWorkers;

    public Team(IWorker[] workers, int countWorkers)
    {
        _workers = workers;
        _countWorkers = countWorkers;
    }

    public IWorker this[int index]
    {
        get
        {
            return _workers[index];
        }
        set
        {
            _workers[index] = value;
        }
    }

    public void HouseBuilding(House house)
    {
        for (int i = 0; i < _countWorkers; i++)
        {
            if (this[i] is Worker)
            {
                this[i].Work(house);
            }
        }
    }
     
    public bool IsWorkFinish(House house)
    {
        for (int i = 0; i < _countWorkers; i++)
        {
            if (this[i] is TeamLeader)
            {
                this[i].Work(house);
                return this[i].IsWorkFinish;  
            }
        }
        return false;
    }
}
}
