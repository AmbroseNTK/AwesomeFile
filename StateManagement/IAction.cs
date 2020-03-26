﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateManagement
{
    public interface IAction
    {
        string GetName();
        object[] GetPayload();
    }
}
