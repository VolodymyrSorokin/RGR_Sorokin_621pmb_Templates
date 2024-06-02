using System;
using System.Collections.Generic;

// Абстрактний клас Flyweight, який визначає методи для об'єктів, що підтримують спільний стан
public abstract class Flyweight
{
    public abstract void Operation(string extrinsicState);
}

// Конкретний Flyweight, який реалізує спільний стан
public class ConcreteFlyweight : Flyweight
{
    private string intrinsicState;

    // Конструктор приймає внутрішній стан
    public ConcreteFlyweight(string intrinsicState)
    {
        this.intrinsicState = intrinsicState;
    }

    // Метод Operation виконує операцію з врахуванням зовнішнього стану
    public override void Operation(string extrinsicState)
    {
        Console.WriteLine($"Intrinsic State: {intrinsicState}, Extrinsic State: {extrinsicState}");
    }
}

// Фабрика Flyweight, яка забезпечує створення та управління примірниками
public class FlyweightFactory
{
    private Dictionary<string, Flyweight> flyweights = new Dictionary<string, Flyweight>();

    // Метод для отримання Flyweight за ключем
    public Flyweight GetFlyweight(string key)
    {
        // Якщо Flyweight з таким ключем ще не створено, створити новий і додати його до словника
        if (!flyweights.ContainsKey(key))
        {
            flyweights[key] = new ConcreteFlyweight(key);
        }
        return flyweights[key];
    }
}

// Клієнтський код
class Program
{
    static void Main(string[] args)
    {
        FlyweightFactory factory = new FlyweightFactory();

        // Отримуємо Flyweight з ключем "A" і виконуємо операцію
        Flyweight flyweight1 = factory.GetFlyweight("A");
        flyweight1.Operation("First Call");

        // Отримуємо Flyweight з ключем "A" ще раз і виконуємо операцію
        Flyweight flyweight2 = factory.GetFlyweight("A");
        flyweight2.Operation("Second Call");

        // Отримуємо Flyweight з ключем "B" і виконуємо операцію
        Flyweight flyweight3 = factory.GetFlyweight("B");
        flyweight3.Operation("Third Call");
    }
}
