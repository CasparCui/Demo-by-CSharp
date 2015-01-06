using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadWork
{
    public class UseLock
    {
        private static Object lockObj = new object();
        private static int i = 0;
        private static void ThreadFunction(String s)
        {
            for (int j = 0; j < 5; j++)
            {

                    i++;
                    Thread.Sleep(2);
                    Console.WriteLine(s + "{0}", i);
                
            }
        }
        public UseLock()
        {
            Thread thread1 = new Thread(() =>
            {
                ThreadFunction("thr1 ");
            });
            Thread thread2 = new Thread(() =>
            {
                ThreadFunction("thr2 ");
            });
            Thread thread3 = new Thread(() =>
            {
                ThreadFunction("thr3 ");
            });
            Thread thread4 = new Thread(() =>
            {
                ThreadFunction("thr4 ");
            });
            Thread thread5 = new Thread(() =>
            {
                ThreadFunction("thr5 ");
            });
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            Thread.Sleep(200);
        }

    }
}
