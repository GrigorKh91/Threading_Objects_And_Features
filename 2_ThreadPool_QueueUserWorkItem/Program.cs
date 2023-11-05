using System.Threading;

namespace _2_ThreadPool_QueueUserWorkItem
{
    internal class Program
    {
        static void ThreadProc(Object stateInfo)
        {
            Console.WriteLine($" Pool Thread: {Thread.CurrentThread.ManagedThreadId} Start");
            Thread.Sleep(100000);
            Console.WriteLine($" Pool Thread: {Thread.CurrentThread.ManagedThreadId} End");

        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem(ThreadProc);
            }

            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
    }
}