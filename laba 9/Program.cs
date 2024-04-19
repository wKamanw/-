using System;

interface IShape
{
    double Area(); // Метод для вычисления площади
}

abstract class Shape : IShape // Базовый абстрактный класс для всех фигур
{
    public abstract double Area(); // Абстрактный метод для вычисления площади
}

class Quadrilateral : Shape // Класс для четырехугольника
{
    protected double side1;
    protected double side2;
    protected double side3;
    protected double side4;

    public Quadrilateral(double s1, double s2, double s3, double s4) // Конструктор
    {
        if (!IsValidQuadrilateral(s1, s2, s3, s4))
            throw new ArgumentException("Невозможно создать четырехугольник с заданными сторонами.");

        side1 = s1;
        side2 = s2;
        side3 = s3;
        side4 = s4;
    }

    public override double Area() // Переопределение метода вычисления площади
    {
        // Предполагаем, что это общий четырехугольник, а не конкретный прямоугольник или квадрат
        // Вычисление площади для общего четырехугольника может быть сложным и зависит от конкретной формы
        // Этот метод должен быть переопределен в производных классах для конкретных четырехугольников
        throw new NotImplementedException("Расчет площади для общего четырехугольника не реализован.");
    }

    private bool IsValidQuadrilateral(double s1, double s2, double s3, double s4)
    {
        // Проверяем, что сумма длин любых двух сторон больше длины третьей стороны
        return s1 + s2 > s3 && s1 + s3 > s2 && s2 + s3 > s1 &&
               s1 + s4 > s3 && s1 + s3 > s4 && s3 + s4 > s1 &&
               s2 + s4 > s3 && s2 + s3 > s4 && s3 + s4 > s2 &&
               s1 + s4 > s2 && s1 + s2 > s4 && s2 + s4 > s1;
    }
}

class Triangle : Shape // Класс для треугольника
{
    protected double side1;
    protected double side2;
    protected double side3;

    public Triangle(double s1, double s2, double s3) // Конструктор
    {
        if (!IsValidTriangle(s1, s2, s3))
            throw new ArgumentException("Невозможно создать треугольник с заданными сторонами.");

        side1 = s1;
        side2 = s2;
        side3 = s3;
    }

    public override double Area() // Переопределение метода вычисления площади
    {
        // Реализация формулы Герона для вычисления площади треугольника
        double s = (side1 + side2 + side3) / 2;
        return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
    }

    private bool IsValidTriangle(double s1, double s2, double s3)
    {
        // Проверяем, что сумма длин любых двух сторон больше длины третьей стороны
        return s1 + s2 > s3 && s1 + s3 > s2 && s2 + s3 > s1;
    }
}

class Square : Quadrilateral // Класс для квадрата
{
    public Square(double side) : base(side, side, side, side) { } // Конструктор

    public override double Area() // Переопределение метода вычисления площади
    {
        return side1 * side1;
    }
}

class IsoscelesTriangle : Triangle // Класс для равнобедренного треугольника
{
    public IsoscelesTriangle(double baseSide, double equalSide) : base(baseSide, equalSide, equalSide) { } // Конструктор
}

class RightTriangle : Triangle // Класс для прямоугольного треугольника
{
    public RightTriangle(double baseSide, double height) : base(baseSide, height, Math.Sqrt(baseSide * baseSide + height * height)) { } // Конструктор
}

class EquilateralTriangle : Triangle // Класс для равностороннего треугольника
{
    public EquilateralTriangle(double side) : base(side, side, side) { } // Конструктор
}

class Program
{
    static void Main(string[] args)
    {
        double squareSide, isoscelesBase, isoscelesEqual, rightBase, rightHeight, equilateralSide;

        Console.WriteLine("Введите длины сторон для квадрата:");
        if (!double.TryParse(Console.ReadLine(), out squareSide))
        {
            Console.WriteLine("Ошибка: Введите числовое значение для длины стороны квадрата.");
            return;
        }

        Console.WriteLine("Введите основание и равные стороны для равнобедренного треугольника:");
        if (!double.TryParse(Console.ReadLine(), out isoscelesBase) || !double.TryParse(Console.ReadLine(), out isoscelesEqual))
        {
            Console.WriteLine("Ошибка: Введите числовые значения для основания и равных сторон треугольника.");
            return;
        }

        Console.WriteLine("Введите основание и высоту для прямоугольного треугольника:");
        if (!double.TryParse(Console.ReadLine(), out rightBase) || !double.TryParse(Console.ReadLine(), out rightHeight))
        {
            Console.WriteLine("Ошибка: Введите числовые значения для основания и высоты треугольника.");
            return;
        }

        Console.WriteLine("Введите длину стороны для равностороннего треугольника:");
        if (!double.TryParse(Console.ReadLine(), out equilateralSide))
        {
            Console.WriteLine("Ошибка: Введите числовое значение для длины стороны равностороннего треугольника.");
            return;
        }

        try
        {
            IShape[] shapes = new IShape[] // Используем интерфейс в массиве
            {
                new Square(squareSide),
                new IsoscelesTriangle(isoscelesBase, isoscelesEqual),
                new RightTriangle(rightBase, rightHeight),
                new EquilateralTriangle(equilateralSide)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine("Площадь: " + shape.Area());
                Console.WriteLine();
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}
