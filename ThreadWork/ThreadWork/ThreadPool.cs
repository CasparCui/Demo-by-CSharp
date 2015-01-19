using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadWork
{
    class ThreadPools
    {
        public ThreadPools()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.work1),"hehehehe");
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.work2));
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.work3));
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.work4));
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.work5));
        }

        private void work1(object state)
        {
            if (state is String)
            {
                {
                    Console.WriteLine("work1"+state);
                }
            }
        }
        private void work2(object state)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("work2");
            }
        }
        private void work3(object state)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("work3");
            }
        }
        private void work4(object state)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("work4");
            }
        }
        private void work5(object state)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("work5");
            }
        }

    }
}
