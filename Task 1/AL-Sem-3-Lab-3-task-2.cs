using System;

public struct Vector
{
    public double x;
    public double y;
    public double z;

    public Vector(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    // Метод для вычисления длины вектора
    public double Length()
    {
        return Math.Sqrt(x * x + y * y + z * z);
    }

    // Оператор сложения векторов
    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
    }

    // Оператор умножения векторов (скалярное произведение)
    public static double operator *(Vector v1, Vector v2)
    {
        return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
    }

    // Оператор умножения вектора на число
    public static Vector operator *(Vector v, double scalar)
    {
        return new Vector(v.x * scalar, v.y * scalar, v.z * scalar);
    }

    // Логический оператор сравнения (равенство)
    public static bool operator ==(Vector v1, Vector v2)
    {
        return v1.Length() == v2.Length();
    }

    public static bool operator !=(Vector v1, Vector v2)
    {
        return !(v1 == v2);
    }

    // Переопределяем методы Equals и GetHashCode
    public override bool Equals(object obj)
    {
        if (obj is Vector)
        {
            Vector v = (Vector)obj;
            return this == v;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return this.Length().GetHashCode();
    }

    // Переопределяем метод ToString для удобства работы с выводом
    public override string ToString()
    {
        return $"Vector({x}, {y}, {z})";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Vector v1 = new Vector(1, 2, 3);
        Vector v2 = new Vector(4, 5, 6);

        Vector sum = v1 + v2; // Сложение векторов
        double dotProduct = v1 * v2; // Умножение (скалярное произведение)
        Vector scaledVector = v1 * 2; // Умножение на число

        bool areEqual = v1 == v2; // Сравнение по длине

        Console.WriteLine($"Сумма векторов: {sum}");
        Console.WriteLine($"Скалярное произведение: {dotProduct}");
        Console.WriteLine($"Вектор v1, умноженный на 2: {scaledVector}");
        Console.WriteLine($"v1 и v2 равны по длине: {areEqual}");
    }
}