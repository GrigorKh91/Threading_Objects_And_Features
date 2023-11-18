namespace _0_SpinLock
{
    internal class Program
    {
        class MyClass
        {

            SpinLock spLock = new SpinLock();
            public void Process()
            {
                bool lockTaken = false;

                spLock.Enter(ref lockTaken);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}  start");
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}  end");
                spLock.Exit();

            }
        }
        public static void Main()
        {
            MyClass ob = new MyClass();
            Thread th = new Thread(new ThreadStart(ob.Process));
            Thread th1 = new Thread(new ThreadStart(ob.Process));
            Thread th2 = new Thread(new ThreadStart(ob.Process));
            Thread th3 = new Thread(new ThreadStart(ob.Process));
            th.Start();
            th1.Start();
            th3.Start();
            th2.Start();
            Console.Read();
        }
    }
}
