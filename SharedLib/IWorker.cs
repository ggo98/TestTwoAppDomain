﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    public interface IWorker
    {
        string DoWork(ISomeData sd);
    }
}
