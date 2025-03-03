using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
 
 
public class Information
{
    public int InformationId { get; set; }
    public string FirstName { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
 
    public void DisplayInformationDetails()
    {
        Console.WriteLine($"Information ID: {InformationId}, FirstName: {FirstName}, Age: {Age}, Gender: {Gender}, Phone Number: {PhoneNumber}, Email: {Email}");
    }
}
 
public class InformationManager
{
    public static List<Information> Informations { get; set; } = new List<Information>();
 
 
    public void AddInformation(Information info)
    {
        foreach (Information item in Informations)
        {
            if (item.InformationId == info.InformationId) //info.InformationId is the user input and item.InformationId is the item from the list gotten while running for loop.
            {
                Console.WriteLine($"An information with ID {info.InformationId} already exist.");
                return;
            }
        }
        Informations.Add(info);
        Console.WriteLine("Information added successfully!");
    }
 
    public void DisplayInformation()
    {
        if (Informations.Count == 0)
        {
            Console.WriteLine("No information available.");
            return;
        }
 
        Console.WriteLine("Information List:");
        foreach (Information item in Informations)
        {
            item.DisplayInformationDetails();
        }
    }
}
 
public class Program
{
    public static InformationManager im = new InformationManager();
 
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Add Information");
            Console.WriteLine("2. Display Information");
            Console.WriteLine("3. Exit");
 
            int choice = int.Parse(Console.ReadLine());
 
            switch (choice)
            {
                case 1:
                    AddInformation();
                break;
           
 
                case 2:
                    im.DisplayInformation();
                break;
 
                case 3:
                    return;
                break;
 
                default:
                    Console.WriteLine("Invalid Option.");
                break;
            }
        }
    }
 
    public static void AddInformation()
    {
        Console.Write("Enter Id: ");
        int id = int.Parse(Console.ReadLine());
 
        Console.Write("Enter FirstName: ");
        string fn = Console.ReadLine();
 
        Console.Write("Enter Age: ");
        int a = int.Parse(Console.ReadLine());
 
        Console.Write("Enter Gender: ");
        string grd = Console.ReadLine();
 
        Console.Write("Enter Email: ");
        string em = Console.ReadLine();
 
        Console.Write("Enter PhoneNumber: ");
        string pn = Console.ReadLine();
 
        Information info = new Information
        {
            InformationId = id,
            FirstName = fn,
            Age = a,
            Gender = grd,
            Email = em,
            PhoneNumber = pn
        };
 
        im.AddInformation(info);
    }
}
