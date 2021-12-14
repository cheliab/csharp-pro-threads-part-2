
/// <summary>
/// ManualResetEvent - уведомляет один и более одидающих потоков о том, что произошло событие.
/// </summary>
class Program
{
    /// <summary>
    /// initalState = false - установка в несигнальное состояние
    /// </summary>
    private static ManualResetEvent _manual = new ManualResetEvent(false);
    
    public static void Main()
    {
        new Thread(Function1).Start();
        new Thread(Function2).Start();
        
        Thread.Sleep(500); // время на запуск потоков
        
        Console.WriteLine("Нажмите на любую клавишу - ManualResetEvent в сигнальное состояние");
        Console.ReadKey();

        _manual.Set(); // Отправляет сигнал всем потокам, что они могут продолжить работу
        
        Console.ReadKey();
    }

    private static void Function1()
    {
        Console.WriteLine("Поток 1 запущен и ожидает сигнала.");
        _manual.WaitOne();
        Console.WriteLine("Поток 1 завершается.");
    }

    private static void Function2()
    {
        Console.WriteLine("Поток 2 запущен и ожидает сигнала.");
        _manual.WaitOne();
        Console.WriteLine("Поток 2 завершается.");
    }
}