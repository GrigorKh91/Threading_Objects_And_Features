using System.Diagnostics.Metrics;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

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
                // Queue the task.
                ThreadPool.QueueUserWorkItem(ThreadProc);
            }

            Console.WriteLine("Hello, World!");
            Console.ReadKey();
        }
        //  Note

        // The threads in the managed thread pool are background threads.That is, their
        // IsBackground properties are true. This means that a ThreadPool thread will not
        // keep an application running after all foreground threads have exited.

        // To request that a work item be handled by a thread in the thread pool,
        // call the QueueUserWorkItem method. This method takes as a parameter a
        // reference to the method or delegate that will be called by the thread selected
        // from the thread pool. There is no way to cancel a work item after it has been queued.
    }
}
//  https://learn.microsoft.com/en-us/dotnet/api/system.threading.threadpool?view=net-7.0