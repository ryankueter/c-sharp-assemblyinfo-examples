/*
 * Author: Ryan Kueter
 * Copyright 2019 Ryan Kueter.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace AssemblyInformation
{
    class LoadAssemblies
    {
        void Run()
        {
            Assembly bankTypes = Assembly.Load("BankTypes.dll");
        }
    }
}
