using System;
using System.Collections.Generic;

class FrequencyOfCharacters{
    static void Main(){
        Console.WriteLine("Frequency  of Character!");
        Dictionary<char, int> frequency = new Dictionary<char, int>();
        Console.Write("Enter String : ");
        string? input = Console.ReadLine();
        foreach(char c in input){
            if(char.IsWhiteSpace(c))
            continue;

            if(frequency.ContainsKey(c)){
                frequency[c]++;
            }else{
                frequency[c] = 1;
            }

        }

        Console.WriteLine("Frequency of Characters - ");
        foreach(var item in frequency){
            Console.Write($"{item.Key}:{item.Value}"+" ");
        }

    }
}