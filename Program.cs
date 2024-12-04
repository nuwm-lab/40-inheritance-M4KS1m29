using System;

class HalfPlane
{
    protected double a1, a2, b;

    // Конструктор для встановлення коефіцієнтів
    public HalfPlane(double a1, double a2, double b)
    {
        this.a1 = a1;
        this.a2 = a2;
        this.b = b;
    }

    // Віртуальний метод для виведення коефіцієнтів
    public virtual void DisplayCoefficients()
    {
        Console.WriteLine($"Рівняння півплощини: {a1} * x1 + {a2} * x2 <= {b}");
    }

    // Віртуальний метод для перевірки належності точки
    public virtual bool IsPointInRegion(params double[] coordinates)
    {
        if (coordinates.Length != 2)
            throw new ArgumentException("Для півплощини потрібні 2 координати.");
        return (a1 * coordinates[0] + a2 * coordinates[1]) <= b;
    }
}

class HalfSpace : HalfPlane
{
    private double a3;

    // Конструктор для встановлення коефіцієнтів
    public HalfSpace(double a1, double a2, double a3, double b) : base(a1, a2, b)
    {
        this.a3 = a3;
    }

    // Перевизначення методу для виведення коефіцієнтів
    public override void DisplayCoefficients()
    {
        Console.WriteLine($"Рівняння півпростору: {a1} * x1 + {a2} * x2 + {a3} * x3 <= {b}");
    }

    // Перевизначення методу для перевірки належності точки
    public override bool IsPointInRegion(params double[] coordinates)
    {
        if (coordinates.Length != 3)
            throw new ArgumentException("Для півпростору потрібні 3 координати.");
        return (a1 * coordinates[0] + a2 * coordinates[1] + a3 * coordinates[2]) <= b;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Динамічне створення об'єктів та використання віртуальних методів
        HalfPlane[] regions = new HalfPlane[2];
        regions[0] = new HalfPlane(1, 2, 5); // Об'єкт півплощини
        regions[1] = new HalfSpace(1, 2, 3, 10); // Об'єкт півпростору

        // Демонстрація роботи віртуальних методів
        foreach (var region in regions)
        {
            region.DisplayCoefficients();
            if (region is HalfSpace)
            {
                Console.WriteLine("Точка (1, 1, 1) належить регіону: " + region.IsPointInRegion(1, 1, 1));
            }
            else
            {
                Console.WriteLine("Точка (1, 1) належить регіону: " + region.IsPointInRegion(1, 1));
            }
        }
    }
}
