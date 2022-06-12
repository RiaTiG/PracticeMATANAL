using System;
using System.Globalization;

class Program
{
    private delegate double Simple(double a);
    private static Simple[] Array = new Simple[]
    {
        a => 2,
        a => a + 4,
        a => -1 * Math.Pow(a, 2) + 3 * a - 2,
        a => Math.Pow(a, 3),
        a => Math.Pow(2, a),
        a => Math.Log(Math.Abs(a), 2),
        a => Math.Cos(a),
        a => Math.Sin(a) / a,
        a => Math.Atan(a + 3),
        a => Math.Atan(a + 3),
        a => Math.Log(Math.Sin(Math.Atan(Math.Pow(a, 3)) + 2) + 3, 3)
    };

    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("0 - Для выхода; 1 - Для выбора функции");

            int choice = GetNumberInt();

            if (choice == 0) break;
            else if (choice == 1)
            {
                Console.WriteLine();
                int num = GetNumberInLengthSpace();
                Console.WriteLine();
                Console.WriteLine("Введите нижний предел");
                double a = GetNumber();
                Console.WriteLine("Введите верхний предел");
                double b = GetNumber();
                Console.WriteLine("Введите шаг");
                double n = GetNumber();
                double h = (b - a) / n;

                

                DoFunc(num, a, b, n, h);
            }
        }
    }
    private static int GetNumberInLengthSpace()
    {
        Console.WriteLine("Введите номер функции от 0 до 9");
        Console.WriteLine("0. y = 2" +
			"1. y = x + 4" +
			"2. y = -x^2 + 3x - 2" +
			"3. y = x^3" +
			"4. y = 2^x" +
			"5. y = log(x,2)" +
			"6. y = cos(x)" +
			"7. y = sin(x)/x" +
			"8. y = atan(x+3)" +
			"9. y = log(sin(atan(x^3) + 2)+3,3)");

        int num = GetNumberInt();

        if (num < 0 || num >= Array.Length)
            return GetNumberInLengthSpace();
        else
            return num;
    }
    private static int GetNumberInt()
    {
        try
        {
            return int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Что-то пошло не так, введите число еще раз");
            return GetNumberInt();
        }
    }
    private static double GetNumber()
    {
        try
        {
            string temp = Console.ReadLine();
            temp = temp.Replace(',', '.');

            return double.Parse(temp, CultureInfo.InvariantCulture);
        }
        catch
        {
            Console.WriteLine("Что-то пошло не так, введите число еще раз");
            return GetNumber();
        }
    }
    private static void DoFunc(int num, double a, double b, double n, double h)
    {
        double s = 0;

        for (int i = 0; i < n; i++)
        {
            double left = a + i * h;
            double right = left + h;

            s += (Array[num](left) + Array[num](right)) * h / 2;
        }

        Console.WriteLine($"Результат: {s:f4}");
      
    }
}