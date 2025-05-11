using System;
using System.IO;

public static class TestDataGenerator
{
  private static readonly string _folderPath = "TestArrays";

  public static void GenerateTestData(int n = 10000, int k = 10)
  {
    Directory.CreateDirectory(_folderPath);
    Random rnd = new Random();

    for (int i = 0; i < k; i++)
    {
      int[] data = new int[n];
      for (int j = 0; j < n; j++)
        data[j] = rnd.Next(1000);

      string path = Path.Combine(_folderPath, $"test_{i + 1}.txt");
      File.WriteAllText(path, string.Join(" ", data));
    }
  }


}
