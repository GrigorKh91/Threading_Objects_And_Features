namespace _1_Semaphore
{
    internal class Program
    {
        // Semaphore class - used to control access to the resource pool.
        // Threads occupy a semaphore slot by calling the WaitOne() method, and release the occupied slot by calling the Release() method.
        private static Semaphore pool;
        private static void Work(object number)
        {
            pool.WaitOne();

            Console.WriteLine("Thread {0} has taken the semaphore.", number);
            Thread.Sleep(1000);
            Console.WriteLine("Thread {0} -----> freed slot.", number);

            pool.Release();
        }

        public static void Main()
        {
            // First argument: Set the number of slots to use at the moment (no more than the maximum number).
            // Second argument: Set the maximum number of slots for this semaphore.
            pool = new Semaphore(2, 4, "MySemafore65487563487");

            for (int i = 1; i <= 8; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(Work));
                thread.Start(i);
            }
            Thread.Sleep(2000);
            Console.ReadKey();
        }
    }
}
// https://learn.microsoft.com/en-us/dotnet/api/system.threading.semaphore?view=net-7.0
