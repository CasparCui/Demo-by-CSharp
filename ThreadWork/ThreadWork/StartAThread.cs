using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadWork
{
    class StartAThread
    {
        public void MulityThreads(String s)
        {
            Console.WriteLine("Thread" + s);
            Thread.Sleep(1);
        }
        public void MulityThreads()
        {
            Console.WriteLine("Thread1");
            Thread.Sleep(1);
        }
        public StartAThread()
        {
            Thread thread2 = new Thread(() =>
            {
                MulityThreads("2");
            }
            );
            Thread thread = new Thread(new ThreadStart(MulityThreads));
            thread.Start();
            thread2.Start();
            Console.WriteLine("Main");
            thread.Abort();
            Thread.Sleep(10);
        }
    }
}
