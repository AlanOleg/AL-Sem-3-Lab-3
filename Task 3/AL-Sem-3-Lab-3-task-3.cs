using System;

public class Currency
{
    public double Value { get; set; }

    public Currency(double value)
    {
        Value = value;
    }
}

public class CurrencyUSD : Currency
{
    public CurrencyUSD(double value) : base(value) { }

    // Оператор неявного преобразования из USD в EUR
    public static implicit operator CurrencyEUR(CurrencyUSD usd)
    {
        return new CurrencyEUR(usd.Value * 0.85); // Примерный курс USD к EUR
    }

    // Оператор неявного преобразования из USD в RUB
    public static implicit operator CurrencyRUB(CurrencyUSD usd)
    {
        return new CurrencyRUB(usd.Value * 75); // Примерный курс USD к RUB
    }
}

public class CurrencyEUR : Currency
{
    public CurrencyEUR(double value) : base(value) { }

    // Оператор неявного преобразования из EUR в USD
    public static implicit operator CurrencyUSD(CurrencyEUR eur)
    {
        return new CurrencyUSD(eur.Value * 1.18); // Примерный курс EUR к USD
    }

    // Оператор неявного преобразования из EUR в RUB
    public static implicit operator CurrencyRUB(CurrencyEUR eur)
    {
        return new CurrencyRUB(eur.Value * 88); // Примерный курс EUR к RUB
    }
}

public class CurrencyRUB : Currency
{
    public CurrencyRUB(double value) : base(value) { }

    // Оператор неявного преобразования из RUB в USD
    public static implicit operator CurrencyUSD(CurrencyRUB rub)
    {
        return new CurrencyUSD(rub.Value / 75); // Примерный курс RUB к USD
    }

    // Оператор неявного преобразования из RUB в EUR
    public static implicit operator CurrencyEUR(CurrencyRUB rub)
    {
        return new CurrencyEUR(rub.Value / 88); // Примерный курс RUB к EUR
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите сумму в USD: ");
        double usdValue = Convert.ToDouble(Console.ReadLine());
        CurrencyUSD usd = new CurrencyUSD(usdValue);

        // Преобразование USD в EUR
        CurrencyEUR eur = usd; // Неявное преобразование
        Console.WriteLine($"{usd.Value} USD = {eur.Value} EUR");

        // Преобразование USD в RUB
        CurrencyRUB rub = usd; // Неявное преобразование
        Console.WriteLine($"{usd.Value} USD = {rub.Value} RUB");

        Console.Write("Введите сумму в EUR: ");
        double eurValue = Convert.ToDouble(Console.ReadLine());
        CurrencyEUR eur2 = new CurrencyEUR(eurValue);

        // Преобразование EUR в USD
        CurrencyUSD usdFromEur = eur2; // Неявное преобразование
        Console.WriteLine($"{eur2.Value} EUR = {usdFromEur.Value} USD");

        // Преобразование EUR в RUB
        CurrencyRUB rubFromEur = eur2; // Неявное преобразование
        Console.WriteLine($"{eur2.Value} EUR = {rubFromEur.Value} RUB");

        Console.Write("Введите сумму в RUB: ");
        double rubValue = Convert.ToDouble(Console.ReadLine());
        CurrencyRUB rub3 = new CurrencyRUB(rubValue);

        // Преобразование RUB в USD
        CurrencyUSD usdFromRub = rub3; // Неявное преобразование
        Console.WriteLine($"{rub3.Value} RUB = {usdFromRub.Value} USD");

        // Преобразование RUB в EUR
        CurrencyEUR eurFromRub = rub3; // Неявное преобразование
        Console.WriteLine($"{rub3.Value} RUB = {eurFromRub.Value} EUR");
    }
}