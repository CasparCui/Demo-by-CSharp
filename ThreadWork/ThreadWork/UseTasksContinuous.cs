using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadWork
{
    class UseTasksContinuous
    {
        public UseTasksContinuous()
        {
            Task task1 = new Task(DoFirst);
            task1.Start();
            Task task2 = task1.ContinueWith(DoSecond);
            Task task3 = task2.ContinueWith(DoTrird);
            Task task4 = task2.ContinueWith(DoTrird);
            task1 = task4.ContinueWith(DoTrird);
        }
        private void DoFirst()
        {
            Console.WriteLine("Task ID:{0}", Task.CurrentId);
        }
        private void DoSecond(Task task)
        {
            Console.WriteLine("Task id {0} is over!", task.Id);
            Thread.Sleep(5000);
            Console.WriteLine("Task id {0} is started!!", Task.CurrentId);

        }
        private void DoTrird(Task task)
        {
            Console.WriteLine("Task id {0} is over!", task.Id);
            Thread.Sleep(1000);
            Console.WriteLine("Task id {0} is started!!", Task.CurrentId);
        }

    }
}
