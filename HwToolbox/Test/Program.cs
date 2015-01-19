using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HwLogger;
using System.Reflection;

namespace Test
{
    class Program:IDisposable
    {
        static void Main(string[] args)
        {
            
           var ass =  Assembly.LoadFile(@"C:\Users\hwcui\Documents\Visual Studio 2013\Projects\HwToolbox\HwLogger\obj\Debug\HwLogger.dll");
        }
    }
}
