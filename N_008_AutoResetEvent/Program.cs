
// AutoResetEvent - Уведомляет ожидающий поток о том, что произошло событие.

class Program
{
    /// <summary>
    /// Аргумент:
    /// initialState = false - установка в несигнальное состояние.
    /// initialState = true - эквивалентно вызову _auto.Set();
    /// </summary>
    private static AutoResetEvent _auto = new AutoResetEvent(false);
    
    public static void Main()
    {
        Thread thread = new Thread(Function);
        thread.Start();
        Thread.Sleep(500); // Время для запуска вторичного потока

        Console.WriteLine("Нажмите на любую клавишу - AutoResetEvent в сигнальное состояние");
        Console.ReadKey();

        _auto.Set(); // Продолжить выполнять вторичный поток
        
        Console.WriteLine("Нажмите на любую клавишу - AutoResetEvent в сигнальное состояние");
        Console.ReadKey();

        _auto.Set(); // Продолжить выполнять вторичный поток
        
        Console.ReadKey();
    }

    private static void Function()
    {
        Console.WriteLine("Красный свет");
        _auto.WaitOne(); // Остановка выполнения вторичного потока.
        
        Console.WriteLine("Желтый");
        _auto.WaitOne(); // Остановка выполнения вторичного потока.
        
        Console.WriteLine("Зеленый");
    }
}

