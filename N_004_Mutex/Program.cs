/// <summary>
/// Использование Mutex для синхронизации доступа к защищенным ресурсам
///
/// Mutex - Примитив синхронизации, который также может использоваться
/// в межпроцессной и междоменной синхронизации.
///
/// MutEx - Mutual Exclusion (Взаимное исключение)
/// </summary>
class Program
{
    // Mutex - Примитив синхронизации, который также может использоваться в межпроцессной синхронизации
    // функционирует аналогично AutoResetEvent, но снабжен дополнительной логикой:
    // 1. Запоминает какой поток им владеет. ReleaseMutex не может вызвать поток, который не владеет им
    // 2. Управляет рекурсиным счетчиком, указывающим, сколько раз поток-владелец уже владел объектом
    
    // private static Mutex mutex = new Mutex(); // Без названия нет межпроцессной синхронизации
    private static Mutex mutex = new Mutex(false, "MyMutex");
    
    static void Main()
    {
        Console.WindowWidth = 40;
        Console.WindowHeight = 20;
        
        Thread[] threads = new Thread[5];

        for (int i = 0; i < 5; i++)
        {
            threads[i] = new Thread(Function);
            threads[i].Name = i.ToString();
            Thread.Sleep(1000); // Задержка чтобы перемешать потоки в запущенных приложениях
            threads[i].Start();
        }
        
        Console.ReadKey();
    }

    /// <summary>
    /// Метод имитирующий работу с разделяемым ресурсом
    /// </summary>
    private static void Function()
    {
        mutex.WaitOne(); // занять ресурс
        
        Console.WriteLine($"Поток {Thread.CurrentThread.Name} зашел в защищенную область");
        Thread.Sleep(2000);
        Console.WriteLine($"Поток {Thread.CurrentThread.Name} покинул защищенную области");
        Console.Write(Environment.NewLine);
        
        mutex.ReleaseMutex(); // освободить ресурс
    }
}