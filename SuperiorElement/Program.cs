using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Enter the number of elements in the array: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        Console.WriteLine("Enter the elements of the array:");
        for (int i = 0; i < n; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        List<int> superiorElements = FindSuperiorElements(arr);
        
        Console.WriteLine("Superior elements in the array:");
        foreach (var elem in superiorElements)
        {
            Console.Write(elem + " ");
        }
    }

    static List<int> FindSuperiorElements(int[] arr)
    {
        List<int> superiorElements = new List<int>();
        int n = arr.Length;
        int maxRight = int.MinValue;

        for (int i = n - 1; i >= 0; i--)
        {
            if (arr[i] > maxRight)
            {
                superiorElements.Add(arr[i]);
                // Console.WriteLine("element - "+arr[i]);
                maxRight = arr[i];
            }
        }

        superiorElements.Reverse(); // To maintain the order of appearance in input
        return superiorElements;
    }
}
