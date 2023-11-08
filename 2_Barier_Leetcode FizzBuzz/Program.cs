namespace _2_Barier_Leetcode_FizzBuzz
{
    using System;
    using System.Threading;

    // "fizzbuzz" if i is divisible by 3 and 5,
    // "fizz" if i is divisible by 3 and not 5,
    // "buzz" if i is divisible by 5 and not 3, 
    // i if i is not divisible by 3 or 5.
    public class FizzBuzz
    {
        private int n;
        private int count;
        private Barrier barrier;
        public FizzBuzz(int n)
        {
            this.n = n;
            count = 1;
            barrier = new Barrier(4, (barrier) =>
            {
                Interlocked.Increment(ref count);
            });
        }
        public void Fizz(Action printFizz)
        {
            while (count <= n)
            {
                // System.Threading.Thread.Sleep(10);
                if (count % 3 == 0 && count % 5 != 0)
                {
                    printFizz.Invoke();
                }
                barrier.SignalAndWait();
            }
        }
        public void Buzz(Action printBuzz)
        {
            while (count <= n)
            {
                //Thread.Sleep(10);

                if (count % 3 != 0 && count % 5 == 0)
                {
                    printBuzz.Invoke();
                }
                barrier.SignalAndWait();
            }
        }
        public void Fizzbuzz(Action printFizzBuzz)
        {
            while (count <= n)
            {
                //Thread.Sleep(10);

                if (count % 5 == 0 && count % 3 == 0)
                {
                    printFizzBuzz();
                }
                barrier.SignalAndWait();
            }
        }
        public void Number(Action<int> printNumber)
        {
            while (count <= n)
            {
                if (count % 3 != 0 && count % 5 != 0)
                {
                    printNumber(count);
                }
                barrier.SignalAndWait();
            }
        }
    }
    // [1,2,"fizz",4,"buzz","fizz",7,8,"fizz","buzz",11,"fizz",13,14,"fizzbuzz"]

    public class Program
    {
        public static void Main()
        {
            var xk = Environment.ProcessorCount;

            FizzBuzz ob = new FizzBuzz(15);

            Action<int> number = (x) => Console.Write(x + " ");
            Action fizz = () => Console.Write(" fizz ");
            Action buzz = () => Console.Write(" buzz ");
            Action fizzbuzz = () => Console.Write(" fizzbuzz ");

            Thread A = new Thread(() =>
            {
                ob.Fizz(fizz);
            });
            Thread B = new Thread(() =>
            {
                ob.Buzz(buzz);
            });
            Thread C = new Thread(() =>
            {
                ob.Fizzbuzz(fizzbuzz);
            });
            Thread D = new Thread(() =>
            {
                ob.Number(number);
            });

            A.Start();
            B.Start();
            C.Start();
            D.Start();

            Console.ReadKey();

        }
    }
}