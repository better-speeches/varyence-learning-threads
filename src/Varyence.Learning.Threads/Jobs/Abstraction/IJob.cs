namespace Varyence.Learning.Threads.Jobs.Abstraction
{
    public interface IJob
    {
        string Title { get; }
        void DoJob();
    }
}