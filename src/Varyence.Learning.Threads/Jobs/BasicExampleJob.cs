using System;
using System.Threading;
using Varyence.Learning.Threads.Jobs.Abstraction;

namespace Varyence.Learning.Threads.Jobs
{
    public class BasicExampleJob : IJob
    {
        public string Title => nameof(BasicExampleJob);
        
        public void DoJob()
        {
            var thread = new Thread(WriteY);
            thread.Start();
 
            WriteX();
        }

        private static void WriteX()
        {
            for (var i = 0; i < 1000; i++)
                Console.Write("x");
        }

        private static void WriteY()
        {
            for (var i = 0; i < 1000; i++) 
                Console.Write ("y");
        }
    }
}
