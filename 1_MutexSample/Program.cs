namespace _1_MutexSample
{
    class Program
    {
        // Mutex - A synchronization primitive that can also be used in inter-processor synchronization.
        // functions similarly to AutoResetEvent but with additional logic:
        // 1. Remembers which thread owns it. ReleaseMutex cannot call a thread that does not own the mutex.
        // 2. Manages a recursive counter indicating how many times the owner thread has already owned the object.

        private static readonly Mutex mutex = new Mutex(false, "MutexSample:AAED7056-380D-412E-9608-763495211EA8");
        static void Main()
        {
            var threads = new Thread[10];

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(new ThreadStart(Function))
                {
                    Name = i.ToString()
                };
                threads[i].Start();
            }

            // Delay.
            Console.ReadKey();
        }

        static void Function()
        {
            bool myMutex = mutex.WaitOne();

            Console.WriteLine("Thread {0} has entered a protected area.", Thread.CurrentThread.Name);
            Thread.Sleep(2000);
            Console.WriteLine("Thread {0} has left the protected area.\n", Thread.CurrentThread.Name);
            mutex.ReleaseMutex();
        }
    }

}