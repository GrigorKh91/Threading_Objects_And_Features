using System.Collections.Generic;

namespace _1_The_System.Threading.Timer_class
{
    class TimerState
    {
        public int Counter;
    }
    class Program
    {
        private static Timer timer;

        static void Main(string[] args)
        {
            var timerState = new TimerState { Counter = 0 };

            timer = new Timer(
                callback: new TimerCallback(TimerTask),
                state: timerState,
                dueTime: 1000,
                period: 2000);

            while (timerState.Counter <= 10)
            {
                Task.Delay(1000).Wait();
            }

            timer.Dispose();
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: done.");
        }

        private static void TimerTask(object timerState)
        {
            Console.WriteLine($"{DateTime.Now:HH:mm:ss.fff}: starting a new callback.");
            var state = timerState as TimerState;
            Interlocked.Increment(ref state.Counter);
        }
    }
}

// The System.Threading.Timer class enables you to continuously call a delegate
// at specified time intervals. You can also use this class to schedule a single call
// to a delegate in a specified time interval. The delegate is executed on a ThreadPool thread.


// The following example creates a timer that calls the provided delegate for the
// first time after one second (1000 milliseconds) and then calls it every two
// seconds. The state object in the example is used to count how many times the
// delegate is called.The timer is stopped when the delegate has been called at least 10 times.
