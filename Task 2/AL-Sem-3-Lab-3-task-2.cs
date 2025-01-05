using System;
using System.Collections.Generic;

public class Car : IEquatable<Car>
{
    public string Name { get; set; }
    public string Engine { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, string engine, int maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car other)
    {
        if (other == null) return false;
        return Name == other.Name && Engine == other.Engine && MaxSpeed == other.MaxSpeed;
    }

    public override bool Equals(object obj)
    {
        if (obj is Car car)
        {
            return Equals(car);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Engine, MaxSpeed);
    }
}

public class CarsCatalog
{
    private List<Car> cars = new List<Car>();

    // Индексатор
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= cars.Count)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона.");
            }

            Car car = cars[index];
            return $"{car.Name}, {car.Engine}";
        }
    }

    // Метод для добавления машины
    public void AddCar(Car car)
    {
        cars.Add(car);
    }

    // Метод для вывода всех машин
    public void PrintCars()
    {
        foreach (Car car in cars)
        {
            Console.WriteLine(car);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        CarsCatalog catalog = new CarsCatalog();

        catalog.AddCar(new Car("Toyota Camry", "Petrol", 220));
        catalog.AddCar(new Car("Tesla Model S", "Electro", 250));
        catalog.AddCar(new Car("Ford Mustang", "Petrol", 240));

        // Выводим все машины
        Console.WriteLine("Список автомобилей:");
        catalog.PrintCars();

        // Используем индексатор
        Console.WriteLine("\nИспользование индексатора:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(catalog[i]);
        }
    }
}