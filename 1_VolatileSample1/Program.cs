﻿namespace _1_VolatileSample1
{
    class Program
    {
        static volatile int stop = 0;
        static void Main()
        {
            Console.WriteLine("Main: the thread starts for 2 seconds.");
            var t = new Thread(Worker);
            t.Start();

            Thread.Sleep(2000);

            Thread.VolatileWrite(ref stop, 1);

            Console.WriteLine("Main: waiting for thread to complete");
        }

        private static void Worker(Object o)
        {
            int x = 0;

            while (Thread.VolatileRead(ref stop) != 1)
            {
                x++;
            }

            Console.WriteLine("Worker: stopped at x = {0}.", x);
        }
    }
}