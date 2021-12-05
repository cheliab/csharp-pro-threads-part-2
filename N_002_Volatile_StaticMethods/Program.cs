namespace N_002_Volatile_StaticMethods;

/// <summary>
/// Альтернативный способ работы с volatile
/// Статические методы VolatileWrite() и VolatileRead()
/// </summary>
public class Program 
{
    // теперь тут можно не использовать volatile
    static int stop;

    private static void Function()
    {
        int x = 0;

        while (Thread.VolatileRead(ref stop) != 1)
        {
            x++;
        }

        Console.WriteLine($"Function: поток остановлен при x = {x}");
    }

    public static void Main(string[] args) 
    {
        Console.WriteLine("Main: Start");
        Thread thread = new Thread(Function);
        thread.Start();

        Thread.Sleep(2000);

        Thread.VolatileWrite(ref stop, 1); // stop = 1;
        Console.WriteLine("Main: ожидание завершения вторичного потока.");

        thread.Join();

        Console.ReadKey();
    }
}

// Результат:

//Main: Start
//Main: ожидание завершения вторичного потока.
//Function: поток остановлен при x = 2126732830
