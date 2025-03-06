using System;
using System.Collections.Generic;
// using System.Exceptions;

public class Book{
    public int bookId {get;set;}
    public string Name {get;set;}
    public string author {get;set;}
    
    public Book (){}
    public Book (int id, string n, string a){
        bookId = id;
        Name = n;
        author= a;
    }
    public void Display(){
        Console.WriteLine($"ID: {bookId} Name: {Name} Author: {author}");
    }
}

public class Manager{
    public Dictionary<int, Book> books = new Dictionary<int, Book>();
    
    public void Add(Book book){
        if(books.ContainsKey(book.bookId)){
            Console.WriteLine("Already Exist");
            throw new ArgumentException("Argument ");
        }
        
        books.Add(book.bookId, book);
        Console.WriteLine("Added!");
        Book b = new Book(book.bookId, book.Name, book.author);
        b.Display();
    }
    
    public void ShowAll(){
        if(books.Count>0){
            foreach(Book bt in books.Values){
                bt.Display();
            }
        }else{
            Console.WriteLine("Empty!");
        }
    }
}

public class Program{
    public static Manager m = new Manager();
    public static void Main(){
        while(true){
            Console.WriteLine("1. Add");
            Console.WriteLine("2. ShowAll");
            Console.WriteLine("11. Exit");
            
            Console.Write("Enter - ");
            int ch = int.Parse(Console.ReadLine());
            try{
            switch(ch){
                case 1:
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Name: ");
                string c =  Console.ReadLine();
                Console.Write("Enter Author: ");
                string a =  Console.ReadLine();
                Book b = new Book(id, c, a);
                m.Add(b);
                break;
                case 2:
                m.ShowAll();
                break;
                
                case 11:
                return;
                default :
                Console.WriteLine("Invalid Choice");
                break;
                
            }
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
        }
    }
}
