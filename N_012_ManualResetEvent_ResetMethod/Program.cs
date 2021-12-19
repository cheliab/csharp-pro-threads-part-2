namespace N_012_ManualResetEvent_ResetMethod;

class Program
{
    /// <summary>
    /// initialState = false - установка в несигнальное состояние
    /// </summary>
    private static ManualResetEvent _manualResetEvent = new ManualResetEvent(false);

    private static void Function()
    {
        Console.WriteLine("Запущен поток {0}", Thread.CurrentThread.Name);

        for (int i = 0; i < 80; i++)
        {
            Console.Write(".");
            Thread.Sleep(20);
        }
        
        Console.WriteLine("Завершен поток {0}", Thread.CurrentThread.Name);

        _manualResetEvent.Set(); // Сигнал для разблокировки первичного потока
    }
    
    public static void Main()
    {
        Thread thread = new Thread(Function) // 1-й поток
        {
            Name = "1"    
        };
        thread.Start();

        Console.WriteLine("Приостановка выполнения первичного потока.");
        _manualResetEvent.WaitOne();
        
        Console.WriteLine("Первичный поток возобновил работу.");

        // _manualResetEvent.Reset(); // ручная установка в несигнальное состояние (AutoResetEvent - делает это автоматически)

        thread = new Thread(Function) // 2-й поток
        {
            Name = "2"
        };
        thread.Start();
        
        Console.WriteLine("Приостановка выполнения первичного потока.");
        _manualResetEvent.WaitOne();
        
        Console.WriteLine("Первичный поток возобновил и завершил работу.");

        Console.ReadKey();
    }
}