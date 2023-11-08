using System;
using System.Threading;
namespace _1_SpinLock
{
    // The SpinLock structure is a low-level, mutual-exclusion synchronization primitive that
    // spins while it waits to acquire a lock. On multicore computers, when wait times
    // are expected to be short and when contention is minimal, SpinLock can perform
    // better than other kinds of locks. However, we recommend that you use SpinLock
    // only when you determine by profiling that the System.Threading.Monitor method or
    // the Interlocked methods are significantly slowing the performance of your program.
    public class MyClass
    {
        // Demonstrates:
        //      Default SpinLock construction ()
        //      SpinLock.Enter(ref bool)
        //      SpinLock.Exit()
        SpinLock spLock = new SpinLock();
        public void Process()
        {
            bool lockTaken = false;
            try
            {
                spLock.Enter(ref lockTaken);
                Thread.Sleep(1000);
                Console.WriteLine("process method acquire the lock::");
            }
            finally
            {
                if (lockTaken) 
                    spLock.Exit();
                Console.WriteLine("process method Release the lock::");
            }
        }
        public static void Main()
        {
            MyClass ob = new MyClass();
            Thread th = new Thread(new ThreadStart(ob.Process));
            th.Start();
            Console.Read();
        }
    }
}
