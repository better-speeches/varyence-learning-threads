using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Varyence.Learning.Threads.Common;
using Varyence.Learning.Threads.Jobs.Abstraction;

namespace Varyence.Learning.Threads.Jobs
{
    public class Calculation_AsyncJob : IJob
    {
        public string Title => nameof(Calculation_AsyncJob);

        private static readonly object Lock = new object();
        
        public void DoJob()
        {
            var dataArray = Enumerable.Range(1, 20).ToArray();
            var arrayCount = dataArray.Length;
            var sum = 0;
            var i = 0;
            var watch = new Stopwatch();

            watch.Start();

            foreach (var data in dataArray)
            {
                var thread = new Thread(() =>
                {
                    var result = TestParallel.TestOperation(data);
                    
                    lock (Lock)
                    {
                        sum += result;
                        i += 1;
                    }
                });

                thread.Start();
            }

            while (true)
                if (i >= arrayCount) 
                    break;
            
            watch.Stop();

            Console.WriteLine($"Sync operation: Result: {sum}, Time: {watch.ElapsedMilliseconds}.");
        }
    }
}