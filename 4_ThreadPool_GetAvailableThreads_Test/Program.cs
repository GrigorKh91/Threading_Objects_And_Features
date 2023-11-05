namespace _4_ThreadPool_GetAvailableThreads_Test
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Getting started with the program");
            ShowThreadInfo();

            for (int i = 0; i < 76; i++)
            {
                ThreadPool.QueueUserWorkItem(ThreadProc);
            }

            Thread.Sleep(10000);
            ShowThreadInfo();
            Console.WriteLine("The main thread has finished.\n");
            Console.ReadKey();
        }
        static void ThreadProc(Object stateInfo)
        {
            Console.WriteLine($" Pool Thread: {Thread.CurrentThread.ManagedThreadId} Start");
            Thread.Sleep(10000);
            Console.WriteLine($" Pool Thread: {Thread.CurrentThread.ManagedThreadId} End");
        }
        static void ShowThreadInfo()
        {
            int availableWorkThreads, availableIOThreads, maxWorkThreads, maxIOThreads;
            ThreadPool.GetAvailableThreads(out availableWorkThreads, out availableIOThreads);
            ThreadPool.GetMaxThreads(out maxWorkThreads, out maxIOThreads);
            Console.WriteLine("-------------Available worker threads in the pool: {0} of {1}", availableWorkThreads, maxWorkThreads);
            Console.WriteLine("-------------Available I/O threads in the pool: {0} of {1}\n", availableIOThreads, maxIOThreads);
        }
    }
}