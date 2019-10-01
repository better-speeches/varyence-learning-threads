using System;
using System.Threading;
using Varyence.Learning.Threads.Jobs.Abstraction;

namespace Varyence.Learning.Threads.Jobs
{
    public class SharedResourceJob : IJob
    {
        public string Title => nameof(SharedResourceJob);

        private static bool _done;

        public void DoJob()
        {
            new Thread (Go).Start();
            Go();
        }

        private static void Go()
        {
            if (_done) return;
            _done = true;
            
            Console.WriteLine ("Done");
        }
    }
}