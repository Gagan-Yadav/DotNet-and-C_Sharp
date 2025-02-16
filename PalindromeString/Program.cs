using System;

class PalindromeString
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        if (IsPalindrome(input))
        {
            Console.WriteLine($"'{input}' is a palindrome.");
        }
        else
        {
            Console.WriteLine($"'{input}' is not a palindrome.");
        }
    }

    static bool IsPalindrome(string str)
    {
        int left = 0, right = str.Length - 1;

        while (left < right)
        {
            if (str[left] != str[right])
                return false;

            left++;
            right--;
        }

        return true;
    }
}

//           !!! Alternative Approach !!!
// static bool IsPalindrome(string str)
// {
//     string reversed = new string(str.Reverse().ToArray());
//     return str.Equals(reversed, StringComparison.OrdinalIgnoreCase);
// }
