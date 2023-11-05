namespace _1_VolatileSample
{
    class Program
    {
        static bool stop; // With JIT optimization.
        static void Main()
        {
            Console.WriteLine("Main: the thread starts for 2 seconds.");
            var thread = new Thread(Worker);
            thread.Start();

            Thread.Sleep(2000);

            stop = true;
            Console.WriteLine("Main: waiting for thread to complete");
            thread.Join();
            Console.ReadLine();
        }

        private static void Worker(Object o)
        {
            // ATTENTION! Optimization is not performed in debug mode (DEBUG).
            int x = 0;
            while (!stop)
            {
                //checked
                {
                    x++;
                }
            }

            // Code after JIT optimization, if stop is not voatile:
            // (If stop is volatile, then the compiler will not perform JIT optimization.)
            // int x = 0;         
            // if (stop != true)
            // {
            //     while (true)
            //     {
            //         x++;
            //     }
            // }            

            Console.WriteLine("Worker: stopped at x = {0}.", x);
        }
    }
}