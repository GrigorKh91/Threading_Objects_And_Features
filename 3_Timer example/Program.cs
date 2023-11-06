namespace _3_Timer_example
{
    class Program
    {
        static void Main()
        {
            AutoResetEvent auto = new AutoResetEvent(false);
            StatusChecker checker = new StatusChecker(15);

            TimerCallback checkStatus = new TimerCallback(checker.CheckStatus);

            Console.WriteLine("Create Timer.\n");

            var timer = new Timer(checkStatus, auto, 1000, 250);

            auto.WaitOne();

            Console.WriteLine("\nChange Timer interval.\n");

            timer.Change(0, 500);

            auto.WaitOne();

            Console.WriteLine("\nDispose Timer.");
            timer.Dispose();

            Console.ReadKey();
        }
    }

    class StatusChecker
    {
        private int maxCount;
        private int invokeCount;

        public StatusChecker(int maxCount)
        {
            this.maxCount = maxCount;
        }

        public void CheckStatus(Object stateInfo)
        {
           // Thread.Sleep(10000);
            Console.WriteLine("Check Status {0}.", ++invokeCount);

            if (invokeCount == maxCount)
            {
                invokeCount = 0;                   
                ((AutoResetEvent)stateInfo).Set(); 
            }
        }
    }

}