using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

class Program
{
  static void Main(string[] args)
  {
    while (true)
    {
      Console.WriteLine("\nМеню:");
      Console.WriteLine("1. Згенерувати нові тести");
      Console.WriteLine("2. Перевірити Selection Sort");
      Console.WriteLine("3. Перевірити Shaker Sort");
      Console.WriteLine("4. Вихід");
      Console.Write("Ваш вибір: ");
      string choice = Console.ReadLine();

      switch (choice)
      {
        case "1":
          TestDataGenerator.GenerateTestData();
          break;
        case "2":
          SortingTester.VerifyMethod(SortingAlgorithms.SelectionSort, SortingAlgorithms.StudentSelectionSort);
          break;
        case "3":
          SortingTester.VerifyMethod(SortingAlgorithms.ShakerSort, SortingAlgorithms.StudentShakerSort);
          break;
        case "4":
          return;
        default:
          Console.WriteLine("Невірна опція.");
          break;
      }
    }
  }





}
