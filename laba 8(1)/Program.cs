Console.WriteLine("Введите координаты первой точки:");
Console.Write("X: ");
double x1 = double.Parse(Console.ReadLine());
Console.Write("Y: ");
double y1 = double.Parse(Console.ReadLine());

Console.WriteLine("Введите координаты второй точки:");
Console.Write("X: ");
double x2 = double.Parse(Console.ReadLine());
Console.Write("Y: ");
double y2 = double.Parse(Console.ReadLine());

IPoint point1 = new Point(x1, y1);
IPoint point2 = new Point(x2, y2);

Console.WriteLine($"Координаты первой точки: ({point1.GetX()}, {point1.GetY()})");
Console.WriteLine($"Координаты второй точки: ({point2.GetX()}, {point2.GetY()})");
Console.WriteLine($"Расстояние от первой точки до начала координат: {point1.DistanceToStart()}");
Console.WriteLine($"Расстояние от второй точки до начала координат: {point2.DistanceToStart()}");
Console.WriteLine($"Расстояние между двумя точками: {point1.DistanceTo(point2)}");
Console.WriteLine();
Console.Write("Введите расстояние для перемещения первой точки по оси X: ");
double moveXDistance = double.Parse(Console.ReadLine());
point1.MoveX(moveXDistance);

Console.Write("Введите расстояние для перемещения первой точки по оси Y: ");
double moveYDistance = double.Parse(Console.ReadLine());
point1.MoveY(moveYDistance);

Console.WriteLine($"Новые координаты первой точки: ({point1.GetX()}, {point1.GetY()})");
interface IPoint
{
    double GetX();
    double GetY();
    void MoveX(double distance);
    void MoveY(double distance);
    double DistanceToStart();
    double DistanceTo(IPoint otherPoint);
}

abstract class Shape : IPoint
{
    protected double x;
    protected double y;

    public virtual double GetX()
    {
        return x;
    }

    public virtual double GetY()
    {
        return y;
    }

    public virtual void MoveX(double distance)
    {
        x += distance;
    }

    public virtual void MoveY(double distance)
    {
        y += distance;
    }

    public virtual double DistanceToStart()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public virtual double DistanceTo(IPoint otherPoint)
    {
        double dx = x - otherPoint.GetX();
        double dy = y - otherPoint.GetY();
        return Math.Sqrt(dx * dx + dy * dy);
    }
}
class Point : Shape
{
    public Point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public override void MoveX(double distance)
    {
        base.MoveX(distance);
    }

    public override void MoveY(double distance)
    {
        base.MoveY(distance);
    }

    public override double DistanceToStart()
    {
        return base.DistanceToStart();
    }

    public override double DistanceTo(IPoint otherPoint)
    {
        return base.DistanceTo(otherPoint);
    }
}