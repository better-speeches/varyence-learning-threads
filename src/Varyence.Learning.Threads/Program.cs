using System;
using System.Collections.Generic;
using Varyence.Learning.Threads.Jobs;
using Varyence.Learning.Threads.Jobs.Abstraction;

namespace Varyence.Learning.Threads
{
    public static class Program
    {
        private static readonly Dictionary<int, IJob> Jobs = new Dictionary<int, IJob>
        {
            // Introduction
            {0, new BasicExampleJob()},
            // Foreground & Background
            {1, new ForegroundJob()},
            {2, new BackgroundJob()},
            // Exception Handling
            {3, new ExceptionHandling_NotCatchedJob()},
            {4, new ExceptionHandling_CatchedJob()},
            // Thread Pool
            {5, new ThreadPool_NoPoolJob()},
            {6, new ThreadPool_UsePoolJob()},
            // Shared Resources
            {7, new SharedResourceJob()},
            // Thread Safety
            {8, new ThreadSafety_NotSafeJob()},
            {9, new ThreadSafety_SafeJob()},
            // More about locks
            {10, new Lock_BadLockerObjectJob()},
            {11, new Lock_BadLockerStringJob()},
            // Calculation            
            {12, new Calculation_SyncJob()},
            {13, new Calculation_AsyncJob()},
        };
        
        private static void Main() => 
            SelectJob().DoJob();

        private static IJob SelectJob()
        {
            Console.WriteLine("Select job:");
            
            foreach (var (key, job) in Jobs)
                Console.WriteLine($"[{key}] - {job.Title}");
            
            Console.Write("Job index: ");
            
            var selectedJob = Jobs[int.Parse(Console.ReadLine() ?? throw new ArgumentNullException())];

            Console.WriteLine();
            Console.WriteLine($"### - {selectedJob.Title} - ###");
            Console.WriteLine();

            return selectedJob;
        }
    }
}