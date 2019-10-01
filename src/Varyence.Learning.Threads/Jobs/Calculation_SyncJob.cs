using System;
using System.Diagnostics;
using System.Linq;
using Varyence.Learning.Threads.Common;
using Varyence.Learning.Threads.Jobs.Abstraction;

namespace Varyence.Learning.Threads.Jobs
{
    public class Calculation_SyncJob : IJob
    {
        public string Title => nameof(Calculation_SyncJob);

        public void DoJob()
        {
            var dataArray = Enumerable.Range(1, 20).ToArray();
            var sum = 0;
            var watch = new Stopwatch();

            watch.Start();

            foreach (var data in dataArray)
            {
                sum += TestParallel.TestOperation(data);
            }

            watch.Stop();

            Console.WriteLine($"Sync operation: Result: {sum}, Time: {watch.ElapsedMilliseconds}.");
        }
    }
}