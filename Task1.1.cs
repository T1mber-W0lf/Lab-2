/*using System;

class CoordinateConversion
{
    // Перевод из полярной в декартову
    public static (double, double) PolarToCartesian(double r, double theta)
    {
        double x = r * Math.Cos(theta);
        double y = r * Math.Sin(theta);
        return (x, y);
    }

    // Перевод из декартовой в полярную
    public static (double, double) CartesianToPolar(double x, double y)
    {
        double r = Math.Sqrt(x * x + y * y);
        double theta = Math.Atan2(y, x);
        return (r, theta);
    }

    public static void Main()
    {
        Console.WriteLine("Введите значения полярных координат:");

        // Ввод радиуса r
        Console.Write("Введите радиус (r): ");
        double r = Convert.ToDouble(Console.ReadLine());

        // Ввод угла theta
        Console.Write("Введите угол (θ в радианах): ");
        double theta = Convert.ToDouble(Console.ReadLine());

        // Перевод в декартову систему координат
        var cartesian = PolarToCartesian(r, theta);
        Console.WriteLine($"Декартовы координаты: x = {cartesian.Item1}, y = {cartesian.Item2}");

        // Перевод обратно в полярную систему координат
        var polar = CartesianToPolar(cartesian.Item1, cartesian.Item2);
        Console.WriteLine($"Проверка обратного преобразования: r = {polar.Item1}, θ = {polar.Item2}");
    }
}
*/