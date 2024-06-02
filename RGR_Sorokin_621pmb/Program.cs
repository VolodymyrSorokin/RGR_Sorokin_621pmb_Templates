using System;

// Абстрактний продукт, який визначає загальний інтерфейс для продуктів
public abstract class Product
{
    // Абстрактний метод, який реалізують конкретні продукти
    public abstract void Operation();
}

// Конкретний продукт A, який реалізує інтерфейс Product
public class ConcreteProductA : Product
{
    // Метод Operation виконує конкретну операцію для продукту A
    public override void Operation()
    {
        Console.WriteLine("ConcreteProductA Operation");
    }
}

// Конкретний продукт B, який реалізує інтерфейс Product
public class ConcreteProductB : Product
{
    // Метод Operation виконує конкретну операцію для продукту B
    public override void Operation()
    {
        Console.WriteLine("ConcreteProductB Operation");
    }
}

// Абстрактний творець, який оголошує фабричний метод
public abstract class Creator
{
    // Абстрактний фабричний метод, який повертає об'єкт типу Product
    public abstract Product FactoryMethod();

    // Метод, який використовує об'єкт, створений фабричним методом
    public void AnOperation()
    {
        var product = FactoryMethod();
        product.Operation();
    }
}

// Конкретний творець A, який реалізує фабричний метод для створення продукту A
public class ConcreteCreatorA : Creator
{
    // Метод FactoryMethod створює та повертає новий екземпляр ConcreteProductA
    public override Product FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

// Конкретний творець B, який реалізує фабричний метод для створення продукту B
public class ConcreteCreatorB : Creator
{
    // Метод FactoryMethod створює та повертає новий екземпляр ConcreteProductB
    public override Product FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створюємо конкретного творця A
        Creator creatorA = new ConcreteCreatorA();
        // Виконуємо операцію, використовуючи продукт, створений творцем A
        creatorA.AnOperation();

        // Створюємо конкретного творця B
        Creator creatorB = new ConcreteCreatorB();
        // Виконуємо операцію, використовуючи продукт, створений творцем B
        creatorB.AnOperation();
    }
}
