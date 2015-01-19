using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadWork
{
    class TaskResults
    {
        Tuple <int ,int > TaskResult(object obj)
        {
            var tuple = (Tuple<int,int>)obj;
            Console.WriteLine(tuple.ToString());
            return tuple;
        }
        public void TaskResultsssss()
        {
            var task = new Task<Tuple<int,int>>(TaskResult,Tuple.Create<int,int>(1,2));
            task.Start();
            Console.WriteLine(task.Result);
            task.Wait();
            Console.WriteLine("{0},{1}", task.Result.Item1, task.Result.Item2);
        }
    }
}
