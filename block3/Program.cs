using System;

internal class Program
{
  static void Main(string[] args)
  {
    Console.Write("Введіть n для кожного ряду (к-сть ітерацій): ");
    int n = Convert.ToInt32(Console.ReadLine());

    Func<int, double> series1 = n => 1.0 / Math.Pow(2, n);
    Func<int, double> series2 = n => 1.0 / FastFactorial(n + 1);
    Func<int, double> series3 = n => 1.0 * Math.Pow(-1, n + 1) / Math.Pow(2, n);

    Console.WriteLine($"Ряд №1: {CalculateResultOfSeries(series1, n)}");
    Console.WriteLine($"Ряд №2: {CalculateResultOfSeries(series2, n)}");
    Console.WriteLine($"Ряд №3: {CalculateResultOfSeries(series3, n)}");

  }

  static double CalculateResultOfSeries(Func<int, double> unit, int n)
  {
    double result = 0.0;
    for (int i = 0; i <= n; ++i)
    {
      result += unit(i);
    }
    return result;
  }
  static double FastFactorial(int n)
  {
    double result = 1.0;
    for (int i = 2; i <= n; i++)
    {
      result *= i;
    }
    return result;
  }

}
