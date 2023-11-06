namespace _4_Timer_example1
{
    internal class Program
    {
        static int second;
        static void Main(string[] args)
        {
            AutoResetEvent autoResetEvent = new AutoResetEvent(false);

            new Thread(() => OneSecond(autoResetEvent)).Start();

            while (true)
            {
                autoResetEvent.Set();
            }
        }

        static void OneSecond(Object stateInfo)
        {
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine(++second);
                ((AutoResetEvent)stateInfo).WaitOne();
            }

        }
    }
}