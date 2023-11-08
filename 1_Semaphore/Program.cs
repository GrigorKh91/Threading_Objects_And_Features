namespace _1_Semaphore
{
    internal class Program
    {
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
