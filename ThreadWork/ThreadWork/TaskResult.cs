using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadWork
{
    class TaskResult
    {

        private Tuple<int, int> tuple = new Tuple<int, int>(3, 4);

        private Tuple<String, List<int>> tuple2 = Tuple.Create("hehe", new List<int>());

        

        public void UseTuple()
        {
            Console.WriteLine(tuple.Item1 + "\t" + tuple.Item2);//Item1 = 3,Item2 = 4.
            Console.WriteLine(tuple2.Item1);
            tuple2.Item2.Add(tuple.Item1);
            var tuple3 = Tuple.Create(1, 2, 3, 4, 5, 6, 7, 8);
        }
    }
}
