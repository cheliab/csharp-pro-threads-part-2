namespace N_011_ManualResetSlim;

public static class Program
{
    /// <summary>
    /// initialState = false - не сигнальное состояние
    /// </summary>
    private static ManualResetEventSlim _eventSlim = new ManualResetEventSlim(false);
    
    public static void Main()
    {
        new Thread(Function1).Start();
        new Thread(Function2).Start();
        
        Thread.Sleep(500);

        Console.WriteLine("Нажмите клавишу, чтобы разблокировали потоки");
        Console.ReadKey();
        _eventSlim.Set();
        
        Console.ReadKey();
    }

    private static void Function1()
    {
        Console.WriteLine("Поток 1 запущен и ожидает сигнала.");
        _eventSlim.Wait();
        Console.WriteLine("Поток 1 завершается.");
    }

    private static void Function2()
    {
        Console.WriteLine("Поток 2 запущен и ожидает сигнала.");
        _eventSlim.Wait();
        Console.WriteLine("Поток 2 завершается.");
    }
}