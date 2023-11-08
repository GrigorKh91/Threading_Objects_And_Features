namespace _0_EventWaitHandle
{
    // The EventWaitHandle class allows threads to communicate with each other by
    // signaling and by waiting for signals. Event wait handles (also referred to simply as events)
    // are wait handles that can be signaled in order to release one or more waiting threads.
    // After it is signaled, an event wait handle is reset either manually or automatically.
    // The EventWaitHandle class can represent either a local event wait handle (local event)
    // or a named system event wait handle (named event or system event, visible to all processes).
    class Program
    {
        static EventWaitHandle manual = null;

        static void Main()
        {
            // If a kernel object named GlobalEvent already exists, a reference to it will be obtained.
            // false - non-signaled state.
            // ManualReset - event type.
            // GlobalEvent - the name by which all applications will listen to the event.
            manual = new EventWaitHandle(false, EventResetMode.ManualReset, "GlobalEvent::GUID");

            Thread thread = new Thread(Function);
            thread.IsBackground = true;
            thread.Start();

            Console.WriteLine("Press any key to start the flow...");
            Console.ReadKey();

            // Transfer the event to the signal state.
            // All applications that use an event named GlobalEvent will be notified that it has entered the signaled state.
            manual.Set();

            // Delay.
            Console.ReadKey();
        }

        static void Function()
        {
            manual.WaitOne();

            while (true)
            {
                Console.WriteLine("Hello world!");
                Thread.Sleep(300);
            }
        }
    }
}