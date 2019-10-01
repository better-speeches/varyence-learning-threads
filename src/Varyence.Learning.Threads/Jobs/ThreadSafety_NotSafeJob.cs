using System;
using System.Threading;
using Varyence.Learning.Threads.Jobs.Abstraction;
// ReSharper disable InconsistentNaming

namespace Varyence.Learning.Threads.Jobs
{
    public class ThreadSafety_NotSafeJob : IJob
    {
        public string Title => nameof(ThreadSafety_NotSafeJob);

        public void DoJob()
        {
            TestUnsafeThread();
            TestUnsafeThread();
            TestUnsafeThread();
            TestUnsafeThread();
            TestUnsafeThread();
            TestUnsafeThread();
            TestUnsafeThread();
            TestUnsafeThread();
            TestUnsafeThread();
            TestUnsafeThread();
        }

        private static void TestUnsafeThread()
        {
            var sum = 0;

            for (var i = 1; i <= 100; i++)
            {
                var thread = new Thread(() =>
                {
                    var buffer = sum;
                    Thread.Sleep(1);
                    buffer++;
                    sum = buffer;
                });
                
                thread.Start();
            }
            
            Thread.Sleep(500);

            Console.WriteLine(sum);
        }
    }
}