using System;
using System.Drawing;
using System.Runtime.Intrinsics.X86;
using System.Threading;
namespace _3_checking_SpinLock
{
    // However we can avoid System.Threading.LockRecursionException
    // by checking whether a lock is held by the same thread or not using the SpinLock.IsHeldByCurrentThread property
    public class MyClass
    {
        SpinLock spLock = new SpinLock();
        public void Process()
        {
            bool lockTaken = false;
            try
            {
                spLock.Enter(ref lockTaken);
                Thread.Sleep(1000);
                Process1();
                Console.WriteLine("process method acquire the lock::");
            }
            finally
            {
                if (lockTaken) spLock.Exit();
                Console.WriteLine("process method Release the lock::");
            }
        }
        public void Process1()
        {
            bool lockTaken = false;
            try
            {
                if (!spLock.IsHeldByCurrentThread)
                    spLock.Enter(ref lockTaken);
                Console.WriteLine("process1 method acquire the lock::");
            }
            finally
            {
                if (lockTaken)
                    spLock.Exit();
                Console.WriteLine("process1 method Release the lock::");
            }
        }
        public static void Main()
        {
            MyClass ob = new MyClass();
            Thread th = new Thread(new ThreadStart(ob.Process));
            th.Start();
            Console.Read();
        }
    }
}

//Remarks
//For an example of how to use a Spin Lock, see How to: Use SpinLock for Low-Level Synchronization.

//Spin locks can be used for leaf-level locks where the object allocation implied by using a Monitor,
//in size or due to garbage collection pressure, is overly expensive. A spin lock can be
//useful to avoid blocking; however, if you expect a significant amount of blocking,
//you should probably not use spin locks due to excessive spinning. Spinning
//can be beneficial when locks are fine-grained and large in number (for example, a
//lock per node in a linked list) and also when lock hold-times are always extremely short.
//In general, while holding a spin lock, one should avoid any of these actions:

// * blocking,
// * calling anything that itself may block,
// * holding more than one spin lock at once,
// * making dynamically dispatched calls (interface and virtuals),
// * making statically dispatched calls into any code one doesn't own, or
// * allocating memory.

// SpinLock should only be used after you have been determined that doing so will
// improve an application's performance. It is also important to note that SpinLock is a
// value type, for performance reasons. For this reason, you must be very careful not
// to accidentally copy a SpinLock instance, as the two instances (the original and the copy)
// would then be completely independent of one another,
// which would likely lead to erroneous behavior of the application.
// If a SpinLock instance must be passed around, it should be passed by reference rather than by value.

// Do not store SpinLock instances in readonly fields.

// https://learn.microsoft.com/en-us/dotnet/api/system.threading.spinlock?view=net-7.0