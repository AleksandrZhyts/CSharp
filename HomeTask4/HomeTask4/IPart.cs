﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask4
{
public interface IPart
{
    bool IsBuild { get; }

    void BuildPart();

    string Show();
}
}
