using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Threading;

namespace loadXml
{
    class Program
    {
        private static void a()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("i = " + i);

            }
            Console.WriteLine(Thread.CurrentThread.Name+ " has finished");
        }
        static void Main(string[] args)
        {
            FileInfo file = new FileInfo(@"C:\logFile.txt");
            String s = Path.GetExtension(file.FullName);

        }
    }
}
