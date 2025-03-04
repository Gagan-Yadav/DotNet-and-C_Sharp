using System;
using System.Collections.Generic;

public class Toy
{
    public int ToyID { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Cost { get; set; }

    public Toy() { }

    public Toy(int id, string name, string type, int cost)
    {
        this.ToyID = id;
        this.Name = name;
        this.Type = type;
        this.Cost = cost;
    }
}

public class ToyManager
{
    public Dictionary<int, Toy> toys = new Dictionary<int, Toy>();

public void Show(){
    if(toys.Count==0){
        Console.WriteLine("Record not Found");
    }
    
    foreach(Toy item in toys.Values){
        Console.WriteLine($"ToyID: {item.ToyID}, Name: {item.Name}, Type: {item.Type}, Cost: {item.Cost}");
    }
}

public void SearchToy(int id){
    if(toys.ContainsKey(id)){
    Console.WriteLine("Record Found with ID :"+id);
    Show();
    }else{
    
    Console.WriteLine("No Record Available with Id: "+id);
    }
}

    public void AddToy(Toy toy)
    {
        if (toys.ContainsKey(toy.ToyID))
        {
            Console.WriteLine($"A toy with ID {toy.ToyID} already exists");
            return;
        }

        toys.Add(toy.ToyID, toy);
        Console.WriteLine("Toy added successfully.");
    }

    public void EditToy(int id, string name, string newtype, int newcost)
    {
        if (toys.ContainsKey(id))
        {
            Toy ti = new Toy(id, name, newtype, newcost);
            toys[id] = ti; // values assign (id, name, type, cost);
            Console.WriteLine("Toy updated successfully.");
            return;
        }

        Console.WriteLine($"No toy with ID {id} found");
    }
}

public class Program
{
    public static ToyManager m = new ToyManager();

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Edit");
            Console.WriteLine("3. Show");
            Console.WriteLine("4. Search by Id");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    AddToy();
                    break;
                case 2:
                    EditToy();
                    break;
                    case 3:
                    m.Show();
                    break;
                    case 4:
                    Console.Write("Enter id to search: ");
                   int id = int.Parse(Console.ReadLine());
                    m.SearchToy(id);
                    break;
                case 5:
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }

    public static void AddToy()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Type: ");
        string type = Console.ReadLine();
        Console.Write("Cost: ");
        int cost = int.Parse(Console.ReadLine());

        Toy tt = new Toy(id, name, type, cost);
        m.AddToy(tt);
    }

    public static void EditToy()
    {
        Console.Write("ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Type: ");
        string type = Console.ReadLine();
        Console.Write("Cost: ");
        int cost = int.Parse(Console.ReadLine());

        m.EditToy(id, name, type, cost);
    }
}
