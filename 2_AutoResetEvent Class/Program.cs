namespace _2_AutoResetEvent_Class
{
    internal class Program
    {
        static readonly AutoResetEvent auto = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            new Thread(Function1).Start();
            new Thread(Function2).Start();
            new Thread(Function3).Start();

            Thread.Sleep(1000);
            Console.WriteLine( "Press Enter to make a event" );
            Console.ReadKey();  
            auto.Set();
            auto.Set();
            auto.Set();


            Console.WriteLine("Hello, World!");
        }
        static void Function1()
        {
            Console.WriteLine("Function1 start and wait");
            auto.WaitOne();
            Console.WriteLine("Function1 finish");
        }
        static void Function2()
        {
            Console.WriteLine("Function2 start and wait");
            auto.WaitOne();
            Console.WriteLine("Function2 finish");
        }
        static void Function3()
        {
            Console.WriteLine("Function3 start and wait");
            auto.WaitOne();
            Console.WriteLine("Function3 finish");
        }
    }
}