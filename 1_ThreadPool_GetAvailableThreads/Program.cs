using System;
using System.Threading;
namespace _1_ThreadPool_GetAvailableThreads
{
    public class Example
    {
        public static void Main()
        {
            int worker = 0;
            int io = 0;
            ThreadPool.GetMinThreads(out worker, out io);

            Console.WriteLine("Thread pool threads min at startup: ");
            Console.WriteLine(" Min  worker threads: {0:N0}", worker);
            Console.WriteLine(" Min  asynchronous I/O threads: {0:N0}", io);
            Console.WriteLine( );
            int worker_1 = 0;
            int io_1 = 0;
            ThreadPool.GetAvailableThreads(out worker_1, out io_1);

            Console.WriteLine("Thread pool threads available at startup: ");
            Console.WriteLine(" Available  worker threads: {0:N0}", worker_1);
            Console.WriteLine(" Available  asynchronous I/O threads: {0:N0}", io_1);



            Console.ReadKey(); 
        }
    }
    // The example displays output like the following:
    //    Thread pool threads available at startup:
    //       Worker threads: 32,767
    //       Asynchronous I/O threads: 1,000
}