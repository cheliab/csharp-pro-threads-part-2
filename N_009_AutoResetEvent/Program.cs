
namespace N_009_AutoResetEvent;

static class Program
{
    /// <summary>
    /// initialState = false - установка в несигнальное состояние
    /// </summary>
    private static AutoResetEvent _auto = new AutoResetEvent(false);
    
    public static void Main()
    {
        new Thread(Function1).Start();
        new Thread(Function2).Start();

        Thread.Sleep(500); // Время для запуска потоков

        Console.WriteLine("Нажмите на любую клавишу - AutoResetEvent в сигнальное состояние");
        Console.ReadKey();

        _auto.Set(); // Посылает сигнал одному потоку
        _auto.Set(); // Посылает сигнал другому потоку

        Console.ReadKey();
    }

    private static void Function1()
    {
        Console.WriteLine("Поток 1 запущен и ожидает сигнала.");
        _auto.WaitOne(); // Остановка потока
        Console.WriteLine("Поток 1 завершается.");
    }

    private static void Function2()
    {
        Console.WriteLine("Поток 2 запущен и ожидает сигнала.");
        _auto.WaitOne(); // Остановка потока
        Console.WriteLine("Поток 2 завершается.");
    }
}