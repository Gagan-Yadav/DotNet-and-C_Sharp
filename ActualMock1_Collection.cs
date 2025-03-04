using System;
using System.Globalization;
using System.Net.Http.Headers;
public class Contact{
    public int ContactId {get; set;}
    public string Name {get; set;}
    public int Age {get; set;}
    public string Gender {get; set;}
    public string PhoneNumber {get; set;}
    public string Email {get; set;}
    public Contact(){ }
    public Contact(int id, string n, int a, string g, string pn, string e){
        ContactId = id;
        Name = n;
        Age = a;
        Gender = g;
        PhoneNumber = pn;
        Email = e;
    }

    public void DisplayContactDetails(){
        Console.WriteLine($"Contact ID: {ContactId}, Name: {Name}, Age: {Age}, Gender: {Gender}, Phone Number: {PhoneNumber}, Email: {Email}");
    }
}
public class ContactManager{
    public List<Contact> contacts {get; set;} = new List<Contact>();
         
       public Contact ch = new Contact();
    public void AddContact(Contact contact){
        foreach(Contact item in contacts){
            if(item.ContactId==contact.ContactId){
                Console.WriteLine($"A contact with ID {contact.ContactId} already exists.");
                return;
            }
        }
        contacts.Add(contact);
        Console.WriteLine("Contact added successfully.");
    }

    public void DisplayContacts(){
        if(contacts.Count == 0){
            Console.WriteLine("No contacts available.");
            return;
        }

        Console.WriteLine("Contact List:");
        foreach(Contact item in contacts){
            item.DisplayContactDetails();
        }
    }
}
public class Program
{
    public static ContactManager cm = new ContactManager();
    public static void Main(string[] args)
    {
        while(true){
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Display Contacts");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch(choice){
                case 1:
                AddContact();
                break;

                case 2:
                cm.DisplayContacts();
                break;

                case 3:
                Console.WriteLine("Exiting program...");
                return;
                break;

                default:
                Console.WriteLine("Invalid choice, please try again.");
                break;

            }
        }
    }

    public static void AddContact(){
        Console.Write("Enter Contact ID: ");
        int id =  int.Parse(Console.ReadLine());
        Console.Write("Enter Name: ");
        string n = Console.ReadLine();
        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter Gender: ");
        string g = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        string p =  Console.ReadLine();
        Console.Write("Enter Email: ");
        string e =  Console.ReadLine();

        Contact ch = new Contact(id, n, age, g, p, e);
        cm.AddContact(ch);
    }
}
