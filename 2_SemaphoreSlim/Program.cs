namespace _2_SemaphoreSlim
{
    class Program
    {
        // SemaphoreSlim  - A lightweight semaphore class that does not use kernel synchronization objects.
        static readonly SemaphoreSlim slim = new SemaphoreSlim(1, 4);

        static void Main()
        {

            for (int i = 0; i < 10; i++)
            {
                Thread thread = new Thread(Function);
                thread.Name = i.ToString();
                thread.Start();
            }

            // Delay.
            Console.ReadKey();
        }

        static void Function()
        {
            slim.Wait();

            Console.WriteLine("Thread {0} started working.", Thread.CurrentThread.Name);
            Thread.Sleep(1000);
            Console.WriteLine("Thread {0} has finished running.\n", Thread.CurrentThread.Name);

            slim.Release();
        }
    }
}
// https://learn.microsoft.com/en-us/dotnet/api/system.threading.semaphoreslim?view=net-7.0