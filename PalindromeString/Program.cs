using System.Text;

class PalindromeString
{
    public static void Main(String[] args)
    {
        Console.Write("Enter String - ");
        string? input = Console.ReadLine();

        if (input.Length == 0)
        {
            Console.WriteLine("Please Enter Valid String!");
        }
        else
        {

            char[] arr = input.ToCharArray();
            StringBuilder reverse = new StringBuilder();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                // Console.Write(arr[i]);
                reverse = reverse.Append(Convert.ToString(arr[i]));
            }
            //  Console.WriteLine(reverse);
            if (reverse.Equals(input))
            {
                Console.WriteLine(input+" is Palindrome String");
            }
            else
            {
                Console.WriteLine(input+" is not a Palindrome String");
            }
        }
    }
}