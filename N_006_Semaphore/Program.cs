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

    /// <summary>
    /// Функция для потока
    /// </summary>
    private static void Function(object? number)
    {
        _pool.WaitOne(); // зайти в семафор

        Console.WriteLine($"Поток {number} занял слот семафора.");
        Thread.Sleep(2000);
        Console.WriteLine($"Поток {number} -----> освободил слот.");
        
        _pool.Release(); // выйти из семафора
    }
    
    public static void Main()
    {
        Console.WindowWidth = 40;
        
        /*
         * Аргументы конструктора:
         * initialCount - задает начальное количество потоков которое может входить в семафор
         * maximumCount - максимальное доступное количество потоков для семафора
         * name - название семафора в операционной системе (межпроцессное взаимодействие)
         */
        
        _pool = new Semaphore(5, 7, "MySemaphore");

        //_pool.Release(2); // Сбросить занятые слоты (2), всего свободно 4

        for (int i = 1; i <= 40; i++)
        {
            new Thread(Function).Start(i);
            
            Thread.Sleep(500); // Чтобо потоки разных процессов могли перемешаться
        }
        
        Console.ReadKey();
    }
}