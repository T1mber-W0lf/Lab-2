using System;

/*class DistanceCalculator
{
    // Выбор системы координат и метода расчета
    public static void Main()
    {
        Console.WriteLine("Выберите систему координат:");
        Console.WriteLine("1. Декартова (2D/3D)");
        Console.WriteLine("2. Полярна (2D)");
        Console.WriteLine("3. Сферична (3D)");
        int choice = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                CalculateDistanceCartesian();
                break;
            case 2:
                CalculateDistancePolar();
                break;
            case 3:
                CalculateDistanceSpherical();
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }
    }

    // Расчет расстояния в декартовой системе координат
    public static void CalculateDistanceCartesian()
    {
        Console.WriteLine("Выберите пространство:");
        Console.WriteLine("1. Двумерное (2D)");
        Console.WriteLine("2. Трехмерное (3D)");
        int spaceChoice = Convert.ToInt32(Console.ReadLine());

        if (spaceChoice == 1)
        {
            // Ввод координат для 2D
            Console.WriteLine("Введите координаты первой точки (x1, y1):");
            double x1 = Convert.ToDouble(Console.ReadLine());
            double y1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите координаты второй точки (x2, y2):");
            double x2 = Convert.ToDouble(Console.ReadLine());
            double y2 = Convert.ToDouble(Console.ReadLine());

            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine($"Расстояние в 2D пространстве: {distance}");
        }
        else if (spaceChoice == 2)
        {
            // Ввод координат для 3D
            Console.WriteLine("Введите координаты первой точки (x1, y1, z1):");
            double x1 = Convert.ToDouble(Console.ReadLine());
            double y1 = Convert.ToDouble(Console.ReadLine());
            double z1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите координаты второй точки (x2, y2, z2):");
            double x2 = Convert.ToDouble(Console.ReadLine());
            double y2 = Convert.ToDouble(Console.ReadLine());
            double z2 = Convert.ToDouble(Console.ReadLine());

            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
            Console.WriteLine($"Расстояние в 3D пространстве: {distance}");
        }
    }

    // Расчет расстояния в полярной системе координат
    public static void CalculateDistancePolar()
    {
        Console.WriteLine("Введите полярные координаты первой точки (r1, θ1 в радианах):");
        double r1 = Convert.ToDouble(Console.ReadLine());
        double theta1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите полярные координаты второй точки (r2, θ2 в радианах):");
        double r2 = Convert.ToDouble(Console.ReadLine());
        double theta2 = Convert.ToDouble(Console.ReadLine());

        double distance = Math.Sqrt(Math.Pow(r1, 2) + Math.Pow(r2, 2) - 2 * r1 * r2 * Math.Cos(theta2 - theta1));
        Console.WriteLine($"Расстояние в полярной системе координат: {distance}");
    }

    // Расчет расстояния в сферической системе координат
    public static void CalculateDistanceSpherical()
    {
        Console.WriteLine("Выберите метод расчета в сферической системе:");
        Console.WriteLine("1. Прямая линия (объем сферы)");
        Console.WriteLine("2. По поверхности сферы (велика колова відстань)");
        int methodChoice = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите радиус сферы (R):");
        double R = Convert.ToDouble(Console.ReadLine());

        // Ввод сферических координат для обеих точек
        Console.WriteLine("Введите сферические координаты первой точки (r1, θ1 в радианах, φ1 в радианах):");
        double r1 = Convert.ToDouble(Console.ReadLine());
        double theta1 = Convert.ToDouble(Console.ReadLine());
        double phi1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введите сферические координаты второй точки (r2, θ2 в радианах, φ2 в радианах):");
        double r2 = Convert.ToDouble(Console.ReadLine());
        double theta2 = Convert.ToDouble(Console.ReadLine());
        double phi2 = Convert.ToDouble(Console.ReadLine());

        if (methodChoice == 1)
        {
            // Расчет прямой линии в 3D
            double distance = Math.Sqrt(Math.Pow(r2 * Math.Sin(phi2) * Math.Cos(theta2) - r1 * Math.Sin(phi1) * Math.Cos(theta1), 2)
                                      + Math.Pow(r2 * Math.Sin(phi2) * Math.Sin(theta2) - r1 * Math.Sin(phi1) * Math.Sin(theta1), 2)
                                      + Math.Pow(r2 * Math.Cos(phi2) - r1 * Math.Cos(phi1), 2));
            Console.WriteLine($"Прямое расстояние в 3D: {distance}");
        }
        else if (methodChoice == 2)
        {
            // Расчет по поверхности сферы (велика колова відстань)
            double distance = R * Math.Acos(Math.Sin(phi1) * Math.Sin(phi2) + Math.Cos(phi1) * Math.Cos(phi2) * Math.Cos(theta1 - theta2));
            Console.WriteLine($"Расстояние по поверхности сферы: {distance}");
        }
    }
}*/
