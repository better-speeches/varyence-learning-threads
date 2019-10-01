using System.Threading;

namespace Varyence.Learning.Threads.Common
{
    public class TestParallel
    {
        public static int TestOperation(int data)
        {
            Thread.Sleep(200);
            return data;
        }
    }
}