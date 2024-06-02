using System;

// Абстрактний об'єкт, який визначає загальний інтерфейс для всіх об'єктів
public abstract class AbstractObject
{
    public abstract void Request();
}

// Реальний об'єкт, який виконує реальні дії
public class RealObject : AbstractObject
{
    // Метод Request виконує реальні дії
    public override void Request()
    {
        Console.WriteLine("RealObject Request");
    }
}

// Null-об'єкт, який не виконує жодних дій
public class NullObject : AbstractObject
{
    // Метод Request не виконує жодних дій
    public override void Request()
    {
        // Нічого не робить
    }
}

// НульКлієнтський клас, який використовує об'єкти AbstractObject без перевірок на null
class Client
{
    private AbstractObject obj;

    // Конструктор приймає об'єкт AbstractObject
    public Client(AbstractObject obj)
    {
        this.obj = obj;
    }

    // Метод Execute викликає метод Request об'єкта
    public void Execute()
    {
        obj.Request();
    }
}

// Приклад використання
class Program
{
    static void Main(string[] args)
    {
        // Створюємо реальний об'єкт
        AbstractObject realObject = new RealObject();
        // Створюємо null-об'єкт
        AbstractObject nullObject = new NullObject();

        // Створюємо клієнтів, які використовують ці об'єкти
        Client client1 = new Client(realObject);
        Client client2 = new Client(nullObject);

        // Виконуємо дії
        client1.Execute();
        client2.Execute();
    }
}
