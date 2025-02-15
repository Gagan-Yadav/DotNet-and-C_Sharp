// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// Console.WriteLine("What is your name ?");
// var name = Console.ReadLine();
// var currentdate =  DateTime.Now;
// var age = Console.ReadLine();
// Console.WriteLine($"{Environment.NewLine} Hello, {name} {age}, on {currentdate}");
// Console.ReadKey(true);

using System.Linq.Expressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Size of Array - ");
        var size = int.TryParse(Console.ReadLine(), out var n);
        int[] arr = new int[n];
        Console.WriteLine("Enter Array elements - ");
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt16(Console.ReadLine());
        }
        Console.Write("Enter Element to be search in array - ");
        int t = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            if (arr[i] == t)
            {
                Console.Write("Found Element "+arr[i] + " at index "+i);
            }
        }


        Console.ReadLine();
    }
}
