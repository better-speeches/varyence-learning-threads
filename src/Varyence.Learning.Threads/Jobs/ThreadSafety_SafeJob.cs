using System;
using System.Threading;
using Varyence.Learning.Threads.Jobs.Abstraction;
// ReSharper disable InconsistentNaming

namespace Varyence.Learning.Threads.Jobs
{
    public class ThreadSafety_SafeJob : IJob
    {
        public string Title => nameof(ThreadSafety_SafeJob);
        
        public void DoJob()
        {
            TestLock();
            TestLock();
            TestLock();
            TestLock();
            TestLock();
            TestLock();
            TestLock();
            TestLock();
            TestLock();
            TestLock();
        }

        private static readonly object Lock = new object();
            
        private static void TestLock()
        {
            var sum = 0;

            for (var i = 1; i <= 100; i++)
            {
                var thread = new Thread(() =>
                {
                    lock (Lock)
                    {
                        var buffer = sum;
                        Thread.Sleep(1);
                        buffer++;
                        sum = buffer;                        
                    }
                });
                
                thread.Start();
            }
            
            Thread.Sleep(500);

            Console.WriteLine(sum);
        }
    }
}