using System;
using System.Collections.Generic;

public class Information{
    public int InformationID {get;set;}
    public string FirstName{get;set;}
     public int Age {get;set;}
      public string Gender{get;set;} public string Email{get;set;} public string PhoneNumber{get;set;}
      
      public void DisplayInformationDetails(){
          Console.WriteLine($"Information ID: {InformationID}, FirstName: {FirstName}, Age: {Age}, Gender: {Gender}, Phone Number: {PhoneNumber}");
      }
}

public class InformationManager{
    public List<Information> Informations {get;set;} = new List<Information>();
    
    public void AddInformation(Information info){
        // in info object we passing user input and then checking in our list weather it exist or not by comparing info.ID == list.ID
        foreach(Information item in Informations){
            if(item.InformationID == info.InformationID){
                Console.WriteLine("ALready Exist");
                return;
            }
        }
        Informations.Add(info);
        Console.WriteLine("Added successfully");
    }
    
    public void DisplayInformation(){
        if(Informations.Count>0){
            Console.WriteLine("No reord found");
            return;
        }
        
        Console.WriteLine("List: ");
        foreach(Information item in Informations){
            item.DisplayInformationDetails();
        }
    }
}

public class Program{
    public static InformationManager im = new InformationManager();
    public static void Main(string[] args){
        
        try{
            while(true){
                Console.WriteLine("1. Add Information");
                Console.WriteLine("2. Display Information");
                Console.WriteLine("3. Exit");
                
                int choice = int.Parse(Console.ReadLine());
                switch(choice){
                    case 1:
                    AddInformation();
                    break;
                    case 2:
                    im.DisplayInformationDetails();
                    break;
                    case 3:
                    return;
                    break;
                    default:
                    Console.WriteLine("Invalid Option");
                    break;
                }
            }
        }catch(Exception e){
            Console.WriteLine(e);
        }
    }
    public static void AddInformation(){
        Console.WriteLine("Enter ID:");
        int id = int.Parse(Console.WriteLine());
        Console.WriteLine("Enter First Name:");
        string fn =  Console.ReadLine();
        Console.WriteLine("Enter Age:");
         int age = int.Parse(Console.WriteLine());
        Console.WriteLine("Enter Gender:");
        string g = Console.ReadLine();
        Console.WriteLine("Enter Email:");
         string em =  Console.ReadLine();
        Console.WriteLine("Enter PhoneNumber:");
         string pn =  Console.ReadLine();
         
         Information info = new Information{
             InformationID=id,
             FirstName= fn,
             Age = age,
             Gender = g,
             Email = em,
             PhoneNumber= pn
         };
             
             im.AddInformation(info);
    }
}
