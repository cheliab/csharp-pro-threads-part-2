namespace N_006_Semaphore;

/// <summary>
/// Семаформы
///
/// Класс Semaphore - используется для управления доступом к пулу ресурсов.
/// Потоки занимают слот семафора, вызывая метод WaitOne()
/// и освобождают занятый слот вызовом метода Release().
/// </summary>
public class Program
{
    private static Semaphore _pool;

    private static void Function(object? number)
    {
        _pool.WaitOne();

        Console.WriteLine($"Поток {number} занял слот семафора.");
        Thread.Sleep(2000);
        Console.WriteLine($"Поток {number} -----> освободил слот.");
        
        _pool.Release();
    }
    
    public static void Main()
    {
        _pool = new Semaphore(2, 4, "MySemaphore");

        // _pool.Release(); // Сбросить занятые слоты (2), всего свободно 4

        for (int i = 1; i <= 8; i++)
        {
            new Thread(Function).Start(i);
            
            Thread.Sleep(500); // Чтобо потоки разных процессов могли перемешаться
        }
        
        Console.ReadKey();
    }
}