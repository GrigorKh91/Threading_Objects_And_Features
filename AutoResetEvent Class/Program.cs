namespace _1_AutoResetEvent_Class
{
    class Program
    {
        // AutoResetEvent - Notifies a waiting thread that an event has occurred. 
        static readonly AutoResetEvent auto = new AutoResetEvent(false);

        static void Main()
        {
            Console.WriteLine("Press any key to set AutoResetEvent to alarm state.\n");

            var thread = new Thread(Function1);
            thread.Start();

            Console.ReadKey();
            auto.Set(); // Send a signal to the first thread

            Console.ReadKey();
            auto.Set(); // Send a signal to the second thread

            // Delay.
            Console.ReadKey();
        }

        static void Function1()
        {
            Console.WriteLine("Step One");
            auto.WaitOne(); // after WaitOne() completes, AutoResetEvent automatically goes into a non-signaled state.
            Console.WriteLine("Step Two");
            auto.WaitOne(); // after WaitOne() completes, AutoResetEvent automatically goes into a non-signaled state.
            Console.WriteLine("Step Three");
        }
    }

}