using System;

namespace _2_SpinLock
{
    // However one difference with Monitor is, this lock is non reentrant in nature.
    // In the following code the thread is trying to acquire the same SpinLock twice.
    //Output
    //The execution of the method Process1 will throw a  System.Threading.LockRecursionException:
    //'The calling thread already holds the lock.'

    public class MyClass
    {
        SpinLock spLock = new SpinLock();
        public void Process()
        {
            bool lockTaken = false;
            try
            {
                Monitor.Enter(spLock);
                spLock.Enter(ref lockTaken);
                Thread.Sleep(1000);
                Process1();
                Console.WriteLine("process method acquire the lock::");
            }
            finally
            {
                if (lockTaken)
                    spLock.Exit();
                Console.WriteLine("process method Release the lock::");
            }
        }
        public void Process1()
        {
            bool lockTaken = false;
            try
            {
                spLock.Enter(ref lockTaken);
                Console.WriteLine("process1 method acquire the lock::");
            }
            finally
            {
                if (lockTaken)
                    spLock.Exit();
                Console.WriteLine("process1 method Release the lock::");
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
