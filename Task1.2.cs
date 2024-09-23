using System;

class CoordinateConversion3D
{
    // Перевод из сферической в декартову систему координат
    public static (double, double, double) SphericalToCartesian(double r, double theta, double phi)
    {
        double x = r * Math.Sin(phi) * Math.Cos(theta);
        double y = r * Math.Sin(phi) * Math.Sin(theta);
        double z = r * Math.Cos(phi);
        return (x, y, z);
    }

    // Перевод из декартовой в сферическую систему координат
    public static (double, double, double) CartesianToSpherical(double x, double y, double z)
    {
        double r = Math.Sqrt(x * x + y * y + z * z);
        double theta = Math.Atan2(y, x);   // Азимут в радианах
        double phi = Math.Acos(z / r);     // Угол возвышения в радианах

        return (Math.Round(r, 2), theta, phi); // Округляем r до 2 знаков
    }

    public static void Main()
    {
        Console.WriteLine("Введите значения сферических координат (углы в радианах):");

        // Ввод радиуса r
        Console.Write("Введите радиус (r): ");
        double r = Convert.ToDouble(Console.ReadLine());

        // Ввод азимута theta в радианах
        Console.Write("Введите угол азимута (θ в радианах): ");
        double theta = Convert.ToDouble(Console.ReadLine());

        // Ввод угла возвышения phi в радианах
        Console.Write("Введите угол возвышения (φ в радианах): ");
        double phi = Convert.ToDouble(Console.ReadLine());

        // Перевод в декартову систему координат
        var cartesian = SphericalToCartesian(r, theta, phi);
        Console.WriteLine($"Декартовы координаты: x = {cartesian.Item1}, y = {cartesian.Item2}, z = {cartesian.Item3}");

        // Перевод обратно в сферическую систему координат
        var spherical = CartesianToSpherical(cartesian.Item1, cartesian.Item2, cartesian.Item3);
        Console.WriteLine($"Проверка обратного преобразования: r = {spherical.Item1}, θ = {spherical.Item2} радиан, φ = {spherical.Item3} радиан");
    }
}
