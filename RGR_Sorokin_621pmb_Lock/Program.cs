using System;
using System.Threading;

// Клас Lock, який забезпечує механізм блокування та розблокування доступу до ресурсу
public class Lock
{
    private readonly object _lockObject = new object();

    // Метод для отримання замка
    public void Acquire()
    {
        Monitor.Enter(_lockObject);
    }

    // Метод для звільнення замка
    public void Release()
    {
        Monitor.Exit(_lockObject);
    }
}

// Клієнтський клас, який використовує замок для доступу до ресурсу
public class Client
{
    private Lock _lock;
    private string _name;

    // Конструктор приймає замок і ім'я клієнта
    public Client(Lock lockObject, string name)
    {
        _lock = lockObject;
        _name = name;
    }

    // Метод для доступу до ресурсу
    public void AccessResource()
    {
        Console.WriteLine($"{_name} is trying to acquire the lock.");
        _lock.Acquire();
        try
        {
            Console.WriteLine($"{_name} has acquired the lock.");
            // Критична секція
            Console.WriteLine($"{_name} is accessing the resource.");
            Thread.Sleep(1000); // Симуляція роботи з ресурсом
            Console.WriteLine($"{_name} is releasing the lock.");
        }
        finally
        {
            _lock.Release();
        }
    }
}

// Приклад використання
class Program
{
    static void Main(string[] args)
    {
        Lock lockObject = new Lock();

        // Створюємо клієнтів, які використовують замок
        Client client1 = new Client(lockObject, "Client 1");
        Client client2 = new Client(lockObject, "Client 2");

        // Створюємо потоки для доступу до ресурсу
        Thread thread1 = new Thread(new ThreadStart(client1.AccessResource));
        Thread thread2 = new Thread(new ThreadStart(client2.AccessResource));

        // Запускаємо потоки
        thread1.Start();
        thread2.Start();

        // Чекаємо завершення потоків
        thread1.Join();
        thread2.Join();
    }
}
