using System;

class Program
{
  static void Main(string[] args)
  {
    Func<double, double>[] funcs = new Func<double, double>[3];

    funcs[0] = x => Math.Sqrt(Math.Abs(x));
    funcs[1] = x => Math.Pow(x, 3);
    funcs[2] = x => Math.Sin(x);

    Console.WriteLine("Формат вводу: \"F X\" де F - функція, X - її аргумент:");
    Console.WriteLine("Підтримувані функції: 0 - sqrt(abs(x))");
    Console.WriteLine("                      1 - x^3");
    Console.WriteLine("                      2 - sin(x)");

    while (true)
    {
      try
      {
        string[] parts = Console.ReadLine().Trim().Split();
        int n = Convert.ToInt32(parts[0]);
        double x = Convert.ToDouble(parts[1]);

        Func<double, double> targetFunc = funcs[n];

        Console.WriteLine(targetFunc(x));
      }
      catch
      {
        Console.WriteLine("Yнеправильний ввід тому я зупиняю програму");
        break;
      }
    }
  }
}
