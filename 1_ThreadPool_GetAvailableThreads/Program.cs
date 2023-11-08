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

// The System.Threading.ThreadPool class provides your application with a pool of worker threads
// that are managed by the system, allowing you to concentrate on application tasks rather
// than thread management. If you have short tasks that require background processing, the
// managed thread pool is an easy way to take advantage of multiple threads. 

// Thread pool threads are background threads. Each thread uses the default stack size,
// runs at the default priority, and is in the multithreaded apartment.
// Once a thread in the thread pool completes its task, it's returned to a
// queue of waiting threads. From this moment it can be reused. This reuse enables applications
// to avoid the cost of creating a new thread for each task.

// The number of operations that can be queued to the thread pool is limited only
// by available memory. However, the thread pool limits the number of threads that
// can be active in the process simultaneously. If all thread pool threads are busy,
// additional work items are queued until threads to execute them become available.
// The default size of the thread pool for a process depends on several factors, such as
// the size of the virtual address space. A process can call the ThreadPool.GetMaxThreads
// method to determine the number of threads.

// When not to use thread pool threads

// There are several scenarios in which it's appropriate to create and manage your own threads instead of using thread pool threads:
// * You require a foreground thread.
// * You require a thread to have a particular priority.
// * You have tasks that cause the thread to block for long periods of time. The thread pool has a maximum number of threads, so a large number of blocked thread pool threads might prevent tasks from starting.
// * You need to place threads into a single-threaded apartment. All ThreadPool threads are in the multithreaded apartment.
// * You need to have a stable identity associated with the thread, or to dedicate a thread to a task.

// https://learn.microsoft.com/en-us/dotnet/standard/threading/the-managed-thread-pool