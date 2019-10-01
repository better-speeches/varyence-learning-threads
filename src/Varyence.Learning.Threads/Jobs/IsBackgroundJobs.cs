using System;
using System.Threading;
using Varyence.Learning.Threads.Jobs.Abstraction;

namespace Varyence.Learning.Threads.Jobs
{
    public class ForegroundJob : IJob
    {
        public string Title => nameof(ForegroundJob);

        public void DoJob()
        {
            var thread = new Thread(ReadLine);
            // IsBackground false by default
            // thread.IsBackground = false;
            thread.Start();
        }

        private static void ReadLine() => 
            Console.ReadLine();
    }
    
    public class BackgroundJob : IJob
    {
        public string Title => nameof(BackgroundJob);

        public void DoJob()
        {
            var thread = new Thread(ReadLine) {IsBackground = true};
            thread.Start();
        }
        
        private static void ReadLine() => 
            Console.ReadLine();
    }
}