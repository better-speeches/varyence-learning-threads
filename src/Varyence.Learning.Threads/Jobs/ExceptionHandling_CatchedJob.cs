using System;
using System.Threading;
using Varyence.Learning.Threads.Jobs.Abstraction;

namespace Varyence.Learning.Threads.Jobs
{
    public class ExceptionHandling_CatchedJob : IJob
    {
        public string Title => nameof(ExceptionHandling_CatchedJob);
        
        public void DoJob()
        {
            new Thread (Go).Start();
        }

        private static void Go()
        {
            try
            {
                throw new NullReferenceException("I got null!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception handled: {ex.Message}");
            }
        }
    }
}