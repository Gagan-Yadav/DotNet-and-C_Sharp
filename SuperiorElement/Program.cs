using System;
class SuperiorElement{
    static void Main(String[] args){
        Console.WriteLine("Enter size of an array - ");
        int size = Convert.ToInt16(Console.Read());
        int[] arr = new int[size];
        Console.WriteLine("Enter Array Elements - ");
        for(int i=0;i<arr.Length;i++){
            arr[i] = Convert.ToInt16(Console.Read());
        }
    }
}