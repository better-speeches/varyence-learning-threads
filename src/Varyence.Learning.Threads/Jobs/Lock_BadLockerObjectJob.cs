using System;
using System.Threading;
using Varyence.Learning.Threads.Jobs.Abstraction;

namespace Varyence.Learning.Threads.Jobs
{
    public class Lock_BadLockerObjectJob : IJob
    {
        public string Title => nameof(Lock_BadLockerObjectJob);

        public void DoJob()
        {
            var thread1 = new Thread(TestBadLock);
            var thread2 = new Thread(TestBadLock);

            thread1.Start();
            thread2.Start();
        }

        private static void TestBadLock()
        {
            var obj = new object();

            lock (obj)
            {
                var id = Thread.CurrentThread.ManagedThreadId;
                Console.WriteLine($"Thread: {id} started work.");
                Thread.Sleep(2000);
                Console.WriteLine($"Thread: {id} finished work.");
            }
        }            
    }
}