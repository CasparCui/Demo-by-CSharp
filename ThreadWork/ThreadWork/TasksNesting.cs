
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadWork
{
    class TasksNesting
    {
        public TasksNesting()
        {
            Task fatherTask = new Task(FatherTask);
            fatherTask.Start();
            Console.WriteLine("Task Over!");
            Thread.Sleep(1500);
            Console.WriteLine( fatherTask.Status.ToString());
        }
        private void FatherTask()
        {
            Console.WriteLine("Father~");
            Task childTask = new Task(ChildTask);
            childTask.Start();
            Thread.Sleep(4500);
            Console.WriteLine("Father over!!");
        }
        private void ChildTask()
        {
            Thread.Sleep(3000);
            Console.WriteLine("child~");
            
        }
    }
}
