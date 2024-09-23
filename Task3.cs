using System;
using System.Diagnostics;
using System.IO;
using OfficeOpenXml;

class Benchmark
{
    static Random random = new Random();

    // Генерация массива точек в декартовой системе координат
    static (double, double, double)[] GenerateCartesianPoints(int size)
    {
        var points = new (double, double, double)[size];
        for (int i = 0; i < size; i++)
        {
            points[i] = (random.NextDouble() * 100, random.NextDouble() * 100, random.NextDouble() * 100);
        }
        return points;
    }

    // Генерация массива точек в полярной системе координат (r, theta в радианах)
    static (double, double)[] GeneratePolarPoints(int size)
    {
        var points = new (double, double)[size];
        for (int i = 0; i < size; i++)
        {
            points[i] = (random.NextDouble() * 100, random.NextDouble() * 2 * Math.PI);  // r, θ
        }
        return points;
    }

    // Генерация массива точек в сферической системе координат (r, theta, phi в радианах)
    static (double, double, double)[] GenerateSphericalPoints(int size)
    {
        var points = new (double, double, double)[size];
        for (int i = 0; i < size; i++)
        {
            points[i] = (random.NextDouble() * 100, random.NextDouble() * 2 * Math.PI, random.NextDouble() * Math.PI); // r, θ, φ
        }
        return points;
    }

    // Расчет расстояний в декартовой системе координат
    static void CalculateCartesianDistances((double, double, double)[] points)
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                double x1 = points[i].Item1, y1 = points[i].Item2, z1 = points[i].Item3;
                double x2 = points[j].Item1, y2 = points[j].Item2, z2 = points[j].Item3;
                double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
            }
        }
    }

    // Расчет расстояний в полярной системе координат
    static void CalculatePolarDistances((double, double)[] points)
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                double r1 = points[i].Item1, theta1 = points[i].Item2;
                double r2 = points[j].Item1, theta2 = points[j].Item2;
                double distance = Math.Sqrt(r1 * r1 + r2 * r2 - 2 * r1 * r2 * Math.Cos(theta2 - theta1));
            }
        }
    }

    // Расчет расстояний в сферической системе координат
    static void CalculateSphericalDistances((double, double, double)[] points)
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            for (int j = i + 1; j < points.Length; j++)
            {
                double r1 = points[i].Item1, theta1 = points[i].Item2, phi1 = points[i].Item3;
                double r2 = points[j].Item1, theta2 = points[j].Item2, phi2 = points[j].Item3;

                double x1 = r1 * Math.Sin(phi1) * Math.Cos(theta1);
                double y1 = r1 * Math.Sin(phi1) * Math.Sin(theta1);
                double z1 = r1 * Math.Cos(phi1);

                double x2 = r2 * Math.Sin(phi2) * Math.Cos(theta2);
                double y2 = r2 * Math.Sin(phi2) * Math.Sin(theta2);
                double z2 = r2 * Math.Cos(phi2);

                double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
            }
        }
    }

    public static void Main()
    {
        // Установка контекста лицензии
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        Console.WriteLine("Введите размер массива (от 10,000 до 100,000):");
        string input = Console.ReadLine();

        int arraySize;
        if (!int.TryParse(input, out arraySize) || arraySize < 10000 || arraySize > 100000)
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите число от 10,000 до 100,000.");
            return;
        }

        Console.WriteLine($"Вы ввели размер массива: {arraySize}");
        Console.WriteLine("Генерация данных...");

        // Генерация точек
        var cartesianPoints = GenerateCartesianPoints(arraySize);
        var polarPoints = GeneratePolarPoints(arraySize);
        var sphericalPoints = GenerateSphericalPoints(arraySize);

        // Таймер для бенчмаркинга
        Stopwatch stopwatch = new Stopwatch();

        // Расчет и измерение времени для декартовой системы координат
        stopwatch.Start();
        CalculateCartesianDistances(cartesianPoints);
        stopwatch.Stop();
        long cartesianTime = stopwatch.ElapsedMilliseconds;

        // Сброс таймера
        stopwatch.Reset();

        // Расчет и измерение времени для полярной системы координат
        stopwatch.Start();
        CalculatePolarDistances(polarPoints);
        stopwatch.Stop();
        long polarTime = stopwatch.ElapsedMilliseconds;

        // Сброс таймера
        stopwatch.Reset();

        // Расчет и измерение времени для сферической системы координат
        stopwatch.Start();
        CalculateSphericalDistances(sphericalPoints);
        stopwatch.Stop();
        long sphericalTime = stopwatch.ElapsedMilliseconds;

        // Путь к файлу
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "BenchmarkResults.xlsx");

        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            // Если файл существует, загружаем его
            if (File.Exists(filePath))
            {
                // Здесь не нужно загружать, просто продолжим работу с пакетом
            }
            else
            {
                var worksheet = package.Workbook.Worksheets.Add("Benchmark Results");
                worksheet.Cells[1, 1].Value = "Array Size";
                worksheet.Cells[1, 2].Value = "Coordinate System";
                worksheet.Cells[1, 3].Value = "Time (ms)";
            }

            // Находим следующую пустую строку
            var row = package.Workbook.Worksheets[0].Dimension?.End.Row + 1 ?? 2;

            // Запись данных
            package.Workbook.Worksheets[0].Cells[row, 1].Value = arraySize;
            package.Workbook.Worksheets[0].Cells[row, 2].Value = "Cartesian";
            package.Workbook.Worksheets[0].Cells[row, 3].Value = cartesianTime;

            row++;
            package.Workbook.Worksheets[0].Cells[row, 1].Value = arraySize;
            package.Workbook.Worksheets[0].Cells[row, 2].Value = "Polar";
            package.Workbook.Worksheets[0].Cells[row, 3].Value = polarTime;

            row++;
            package.Workbook.Worksheets[0].Cells[row, 1].Value = arraySize;
            package.Workbook.Worksheets[0].Cells[row, 2].Value = "Spherical";
            package.Workbook.Worksheets[0].Cells[row, 3].Value = sphericalTime;

            // Сохранение файла
            package.Save();
        }

        Console.WriteLine($"Результаты сохранены в: {filePath}");
    }

}
