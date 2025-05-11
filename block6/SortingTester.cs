using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

public static class SortingTester
{
  private static readonly string _folderPath = "TestArrays";
  public delegate void SortMethod(int[] array);
  public delegate bool TimeVerifier(long etalonTime, long studentTime);

  // тайм-ліміт не повільніше ніж у 2 рази + 50 мс
  private static readonly TimeVerifier _defaultTimeVerifier = (etalonTime, studentTime) =>
    studentTime <= etalonTime * 2 + 50;

  public static bool TestSorting(SortMethod etalon, SortMethod student, int[] input, out long studentTime, out bool timeLimitExceeded)
  {
    int[] etalonCopy = (int[])input.Clone();
    int[] studentCopy = (int[])input.Clone();

    long etalonTime = MeasureTime(etalon, etalonCopy);
    studentTime = MeasureTime(student, studentCopy);

    bool correct = etalonCopy.SequenceEqual(studentCopy);
    timeLimitExceeded = !_defaultTimeVerifier(etalonTime, studentTime);

    return correct && !timeLimitExceeded;
  }

  private static long MeasureTime(SortMethod method, int[] array)
  {
    Stopwatch sw = new Stopwatch();
    sw.Start();
    try
    {
      method(array);
    }
    catch
    {
      return long.MaxValue;
    }
    sw.Stop();
    return sw.ElapsedMilliseconds;
  }

  public static void VerifyMethod(SortMethod etalon, SortMethod student)
  {
    string[] files = Directory.GetFiles(_folderPath, "*.txt");
    int passed = 0;

    for (int i = 0; i < files.Length; i++)
    {
      string content = File.ReadAllText(files[i]);
      int[] input = content.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

      Console.WriteLine($"\n--- Тест #{i + 1} ---");

      bool result = TestSorting(etalon, student, input, out long studentTime, out bool timeLimitExceeded);

      if (result)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"OK  | Час: {studentTime} мс");
        passed++;
      }
      else if (studentTime == long.MaxValue)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"CE | Час: {studentTime} мс");
      }
      else if (timeLimitExceeded)
      {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"TL | Перевищено час: {studentTime} мс");
      }


      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"WA | Час: {studentTime} мс");
      }

      Console.ResetColor();
    }

    int score = (int)Math.Round((double)passed / files.Length * 100);
    Console.WriteLine($"\nПідсумок: {score}/100");
  }
}
