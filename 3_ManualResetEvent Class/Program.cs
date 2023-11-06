namespace _3_ManualResetEvent_Class
{
    /*
	ManualResetEvent
	
	ManualResetEvent allows threads to communicate with each other by passing signals.
    Typically this interaction concerns a task that one thread must complete before the other can continue.
    When a thread begins work that must be completed before other threads can continue,
    it calls the Reset method to put the ManualResetEvent in an unsignaled state.
    This thread can be understood as controlling the ManualResetEvent.
    Threads that call the WaitOne method on ManualResetEvent will be blocked while waiting for the signal.
    When the monitoring thread has finished running, it will call the Set method to indicate that the waiting threads can continue running.
    All waiting threads are released..
*/
    class Program
    {
        // ManualResetEvent - Notifies one or more waiting threads that an event has occurred.
        private static ManualResetEvent manual = new ManualResetEvent(false);

        static void Main()
        {
            Console.WriteLine("Press any key to put ManualResetEvent into signal state.\n");

            Thread[] threads = { new Thread(Function1), new Thread(Function2) };

            foreach (Thread thread in threads)
                thread.Start();

            Console.ReadKey();
            manual.Set(); // Sends a signal to all threads..

            // Delay.
            Console.ReadKey();
        }

        static void Function1()
        {
            Console.WriteLine("Thread 1 is running and waiting for a signal");
            manual.WaitOne(); // after WaitOne() completes, ManualResetEvent remains in the signaled state.
            Console.WriteLine("Thread 1 terminated.");

        }

        static void Function2()
        {
            Console.WriteLine("Thread 2 is running and waiting for a signal");
            manual.WaitOne(); //after WaitOne() completes, ManualResetEvent remains in the signaled state.
            Console.WriteLine("Thread 2 terminated");
        }
    }
}