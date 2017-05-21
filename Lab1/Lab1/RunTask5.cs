using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class RunTask5
    {
        public void RunCalculateDeposit()
        {
            double deposit = 1000,
                   limit = 1100;

            var taskInput = new InputInteres();
            double percentDeposit = taskInput.InputData();

            int countMonth = 0;
            while (deposit <= limit)
            {
                deposit += deposit * percentDeposit / 100;
                ++countMonth;
            }
            Console.WriteLine($"After {countMonth} months, the deposit amount will be {deposit}");
        }
    }
}
