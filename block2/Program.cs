using System;
using System.Linq;
using System.Text;

class Program
{
  delegate bool Filter(int n);

  static void Main(string[] args)
  {
    Console.WriteLine("Введіть масив через пробіли:");
    // int[] arr = Array.ConvertAll(Console.ReadLine().Trim().Split(), Convert.ToInt32);
    int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    Console.Write("Введіть дільник: ");
    int k = Convert.ToInt32(Console.ReadLine());

    Filter filterMultiple = x => x % k == 0;

    Console.WriteLine($"Фільтрування за допомогою LINQ: {string.Join(", ", FilterUsingLinq(arr, filterMultiple))}");
    Console.WriteLine($"Ручне фільтрування: {string.Join(", ", FilterManually(arr, filterMultiple))}");
    FilterUsingLinq(arr, filterMultiple);
    FilterManually(arr, filterMultiple);
  }

  static int[] FilterUsingLinq(int[] arr, Filter filter)
  {
    return arr.Where((x) => filter(x)).ToArray();
  }

  static int[] FilterManually(int[] arr, Filter filter)
  {
    int length = 0;
    foreach (int num in arr)
      if (filter(num))
        length++;

    int[] filteredArr = new int[length];
    int j = 0;
    foreach (int num in arr)
    {
      if (filter(num))
        filteredArr[j++] = num;
    }

    return filteredArr;
  }

}
