// Рекурсивное запирание
// (не очень понял в чем прикол, так как если удалить из 2 метода использование мьютекса результат не изменится)

namespace N_005_Mutex_Recursion;

class Program
{
    private static Mutex mutex = new Mutex(); 
    
    public static void Main()
    {
        Thread thread = new Thread(Method1);
        thread.Start();
        thread.Join();
        
        Console.ReadKey();
    }

    private static void Method1()
    {
        mutex.WaitOne();
        Console.WriteLine($"Method1 Start {Thread.CurrentThread.ManagedThreadId}");
        Method2(); // вызывается метод в котором так же есть блокировка мъютексом
        mutex.ReleaseMutex();
        Console.WriteLine($"Method1 Finish {Thread.CurrentThread.ManagedThreadId}");
    }

    private static void Method2()
    {
        mutex.WaitOne(); // ставит на паузу первый метод
        Console.WriteLine($"Method2 Start {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000); // выполняет работу
        mutex.ReleaseMutex(); // позволяет первому методу продолжить работу
        Console.WriteLine($"Method2 Finish {Thread.CurrentThread.ManagedThreadId}");
    }
}

// Результат:

// Method1 Start 7
// Method2 Start 7
// Method2 Finish 7
// Method1 Finish 7