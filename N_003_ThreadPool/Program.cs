﻿namespace N_003_ThreadPool;

/// <summary>
/// Использование пула потоков
/// Вывод количества потоков
/// </summary>
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Main - Начало");
        Report();

        ThreadPool.QueueUserWorkItem(new WaitCallback(Task1));
        Report();

        ThreadPool.QueueUserWorkItem(Task2);
        Report();

        Thread.Sleep(3000);
        Console.WriteLine("Main - Конец");
        Report();

        Console.ReadKey();
    }

    public static void Task1(object? state)
    {
        Thread.CurrentThread.Name = "1";
        Console.WriteLine($"Запущен поток {Thread.CurrentThread.Name}");
        Thread.Sleep(2000);
        Console.WriteLine($"Поток {Thread.CurrentThread.Name} завершил работу");
        Console.Write(Environment.NewLine);
    }

    public static void Task2(object? state)
    {
        Thread.CurrentThread.Name = "2";
        Console.WriteLine($"Запущен поток {Thread.CurrentThread.Name}");
        Thread.Sleep(2000);
        Console.WriteLine($"Поток {Thread.CurrentThread.Name} завершил работу");
        Console.Write(Environment.NewLine);
    }

    /// <summary>
    /// Вывести данные о количестве потоков
    /// </summary>
    private static void Report()
    {
        Thread.Sleep(200);

        int availableWorkThreads, availableIOThreads, maxWorkThreads, maxIOThreads;
        
        ThreadPool.GetAvailableThreads(out availableWorkThreads, out availableIOThreads);
        ThreadPool.GetMaxThreads(out maxWorkThreads, out maxIOThreads);

        Console.WriteLine($"Доступно рабочих потоков в пуле     : {availableWorkThreads} из {maxWorkThreads}");
        Console.WriteLine($"Доступно потоков ввода-вывода в пуле: {availableIOThreads} из {maxIOThreads}");
        Console.Write(Environment.NewLine);
    }
}

//Результат:

//Main - Начало
//Доступно рабочих потоков в пуле     : 32766 из 32767
//Доступно потоков ввода-вывода в пуле: 1000 из 1000

//Запущен поток 1
//Доступно рабочих потоков в пуле     : 32765 из 32767
//Доступно потоков ввода-вывода в пуле: 1000 из 1000

//Запущен поток 2
//Доступно рабочих потоков в пуле     : 32764 из 32767
//Доступно потоков ввода-вывода в пуле: 1000 из 1000

//Поток 1 завершил работу

//Поток 2 завершил работу

//Main - Конец
//Доступно рабочих потоков в пуле     : 32766 из 32767
//Доступно потоков ввода-вывода в пуле: 1000 из 1000