using System;
using System.Threading;
using Varyence.Learning.Threads.Jobs.Abstraction;

namespace Varyence.Learning.Threads.Jobs
{
    public class Lock_BadLockerStringJob : IJob
    {
        public string Title => nameof(Lock_BadLockerStringJob);
        
        public void DoJob()
        {
            var farFarAwayGalaxy = new FarFarAwayGalaxy();
            var chillinGalaxy = new ChillinGalaxy();

            var thread1 = new Thread(farFarAwayGalaxy.LockAllLock);
            var thread2 = new Thread(chillinGalaxy.LockAllLock);

            thread1.Start();
            thread2.Start();
        }
    }
    
    public class FarFarAwayGalaxy
    {
        public void LockAllLock()
        {
            lock ("lock")
            {
                Console.WriteLine($"Attack!");
                Thread.Sleep(2000);
                Console.WriteLine($"Victory!");
            }
        }
    }
    
    public class ChillinGalaxy
    {
        public void LockAllLock()
        {
            lock ("lock")
            {
                Console.WriteLine("Smoke some w###!");
                Thread.Sleep(2000);
                Console.WriteLine("Chill...!");
            }
        }
    }
}