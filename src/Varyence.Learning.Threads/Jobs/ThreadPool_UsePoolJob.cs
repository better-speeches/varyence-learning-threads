using System;
using System.Threading;
using Varyence.Learning.Threads.Jobs.Abstraction;

namespace Varyence.Learning.Threads.Jobs
{
    public class ThreadPool_UsePoolJob : IJob
    {
        public string Title => nameof(ThreadPool_UsePoolJob);
        
        public void DoJob()
        {
            for (var i = 1; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Go, i);
                
                Thread.Sleep(200);
            }
        }

        private static void Go(object number) => 
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId}, Param: {number}");
    }
}