public static class SortingAlgorithms
{
  public static void SelectionSort(int[] array)
  {
    for (int i = 0; i < array.Length - 1; i++)
    {
      int min = i;
      for (int j = i + 1; j < array.Length; j++)
        if (array[j] < array[min]) min = j;

      (array[i], array[min]) = (array[min], array[i]);
    }
  }

  public static void ShakerSort(int[] array)
  {
    int left = 0, right = array.Length - 1;

    while (left < right)
    {
      for (int i = left; i < right; i++)
        if (array[i] > array[i + 1])
          (array[i], array[i + 1]) = (array[i + 1], array[i]);

      right--;

      for (int i = right; i > left; i--)
        if (array[i] < array[i - 1])
          (array[i], array[i - 1]) = (array[i - 1], array[i]);

      left++;
    }
  }

  public static void StudentSelectionSort(int[] array)
  {
    for (int i = 0; i < array.Length - 1; i++)
    {
      int min = i;
      for (int j = i + 1; j < array.Length; j++)
        if (array[j] < array[min]) min = j;

      (array[i], array[min]) = (array[min], array[i]);
    }
  }

  public static void StudentShakerSort(int[] array)
  {
    int left = 0, right = array.Length - 1;

    while (left < right)
    {
      for (int i = left; i < right; i++)
        if (array[i] > array[i + 1])
          (array[i], array[i + 1]) = (array[i + 1], array[i]);

      right -= 2;

      for (int i = right; i > left; i--)
        if (array[i] < array[i - 1])
          (array[i], array[i - 1]) = (array[i - 1], array[i]);

      left++;
    }
  }
}
