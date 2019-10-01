using System;
using System.Threading;
using Varyence.Learning.Threads.Jobs.Abstraction;

namespace Varyence.Learning.Threads.Jobs
{
    public class ExceptionHandling_NotCatchedJob : IJob
    {
        public string Title => nameof(ExceptionHandling_NotCatchedJob);
        
        public void DoJob()
        {
            try
            {
                new Thread (Go).Start();
            }
            catch (Exception)
            {
                // We'll never get here!
                Console.WriteLine ("Exception!");
            }
        }

        private static void Go()
        {
            throw new NullReferenceException();
        }   
    }
}