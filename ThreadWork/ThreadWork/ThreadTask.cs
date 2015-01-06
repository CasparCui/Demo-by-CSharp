using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadWork
{
    class ThreadTask
    {
        public ThreadTask()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<String> task = new Task<string>(
                () => CancelTask(cts.Token), cts.Token
                );
            task.Start();
            task.ContinueWith(SendTaskMessage);
            Console.ReadKey();
            cts.Cancel();
            Console.ReadKey();
            
        }
        private void SendTaskMessage(Task<String> task)
        {
            Console.WriteLine("任务完成，完成时候的状态为：");
            Console.WriteLine("IsCanceled={0}\tIsCompleted={1}\tIsFaulted={2}",
                task.IsCanceled, task.IsCompleted, task.IsFaulted);
            try
            {
                Console.WriteLine("返回值为{0}", task.Result);
            }
            catch (AggregateException e)
            {
                e.Handle((err) => err is OperationCanceledException);
            }
        }
        
        private String CancelTask(CancellationToken  ct)
        {
            Console.WriteLine("任务开始");
            while (true)
            {
                ct.ThrowIfCancellationRequested();
            }
            return "hehehehehe";
        }
    }
}
